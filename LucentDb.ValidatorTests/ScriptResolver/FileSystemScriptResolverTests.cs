using System.IO;
using Moq;
using NUnit.Framework;

namespace LucentDb.Validator.Tests
{
    [TestFixture]
    public class FileSystemScriptResolverTests
    {
        [SetUp]
        public void Init()
        {
            _fileServiceMock = new Mock<IFileService>();
        }

        private Mock<IFileService> _fileServiceMock;

        private static MemoryStream BuildScriptMemoryStream(string scriptValue)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(scriptValue);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        [Test]
        [ExpectedException("System.ArgumentNullException")]
        public void FileSystemScriptResolver_Throws_FileNotFoundException_If_Script_Is_Not_Found()
        {
            _fileServiceMock
                .Setup(it => it.Exists())
                .Returns(true);
            var fFileSysSctRes = new FileSystemScriptResolver(null, _fileServiceMock.Object);
        }

        [Test]
        public void GetSqlScript_Returns_File_Contents_As_String()
        {
            _fileServiceMock.Setup(it => it.Exists()).Returns(true);
            var scriptValue = "Select 1 From SomeTable";
            _fileServiceMock.Setup(it => it.OpenText()).Returns(new StreamReader(BuildScriptMemoryStream(scriptValue)));
            var fFileSysSctRes = new FileSystemScriptResolver("FilePath", _fileServiceMock.Object);
            Assert.AreEqual(scriptValue, fFileSysSctRes.GetSqlScript());
        }

        [Test]
        [ExpectedException("System.IO.FileNotFoundException")]
        public void GetSqlScript_Throws_FileNotFoundException_If_Script_Is_Not_Found()
        {
            _fileServiceMock
                .Setup(it => it.Exists())
                .Returns(false);
            var fFileSysSctRes = new FileSystemScriptResolver("FilePath", _fileServiceMock.Object);
            fFileSysSctRes.GetSqlScript();
        }
    }
}