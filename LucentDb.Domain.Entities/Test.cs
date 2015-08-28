using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace LucentDb.Domain.Entities
{
    [Serializable]
    public class TestList : Collection<Test>
    {
        public Test First()
        {
            return Count > 0 ? base[0] : null;
        }
    }

    [DataContract]
    public class Test
    {
        private int? _groupId;
        private int _id;
        private bool _isActive;
        private string _name;
        private int? _projectId;
        private int _testTypeId;
        private string _testValue;

        public Test()
        {
        }

        public Test(int id, int testTypeId, int? projectId, int? groupId, string name, string testValue, bool isActive)
        {
            _id = id;
            _testTypeId = testTypeId;
            _projectId = projectId;
            _groupId = groupId;
            _name = name;
            _testValue = testValue;
            _isActive = isActive;
        }

        /// <summary>
        ///     Public Property Id
        /// </summary>
        /// <returns>Id as Int32</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        ///     Public Property TestTypeId
        /// </summary>
        /// <returns>TestTypeId as Int32</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int TestTypeId
        {
            get { return _testTypeId; }
            set { _testTypeId = value; }
        }

        /// <summary>
        ///     Public Property ProjectId
        /// </summary>
        /// <returns>ProjectId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int? ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        /// <summary>
        ///     Public Property GroupId
        /// </summary>
        /// <returns>GroupId as Nullable<Int32></returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual int? GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        /// <summary>
        ///     Public Property Name
        /// </summary>
        /// <returns>Name as String</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        ///     Public Property TestValue
        /// </summary>
        /// <returns>TestValue as String</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual string TestValue
        {
            get { return _testValue; }
            set { _testValue = value; }
        }

        /// <summary>
        ///     Public Property IsActive
        /// </summary>
        /// <returns>IsActive as Boolean</returns>
        /// <remarks></remarks>
        [DataMember]
        public virtual bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        [DataMember]
        public virtual Collection<ExpectedResult> ExpectedResults { get; set; }

        [DataMember]
        public virtual Collection<RunHistory> RunHistories { get; set; }

        [DataMember]
        public virtual Project Project { get; set; }

        [DataMember]
        public virtual TestGroup TestGroup { get; set; }

        [DataMember]
        public virtual TestType TestType { get; set; }
    }
}