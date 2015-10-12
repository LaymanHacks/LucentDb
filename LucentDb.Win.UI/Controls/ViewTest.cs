using System;
using System.Linq;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using LucentDb.Domain;
using LucentDb.Domain.Entities;
using LucentDb.Validator;

namespace LucentDb.Win.UI.Controls
{
    public partial class ViewTest : UserControl
    {
        private readonly Test _test;

        public ViewTest()
        {
            InitializeComponent();
        }

        public ViewTest(Test test)
        {
            _test = test;
            InitializeComponent();
            txtScriptValue.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("SQL");

            BindData();
        }

        private void BindData()
        {
            txtScriptValue.Text = _test.TestValue;
            lblName.Text = _test.Name;
            lblAssertType.Text = _test.ExpectedResults[0].AssertType.Name;
            lblAssertValue.Text = _test.ExpectedResults[0].ExpectedValue;
            isActiveCheckBox.Checked = _test.IsActive;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var repo = new WebApiRepositoryContext("http://localhost:60205/");
            var scriptVal = new SqlScriptValidator();
            var connection = new Connection(1, 1, 1, "Chinook",
                @"Data Source=(localdb)\V11.0;Initial Catalog=Chinook;Integrated Security=True;", true, true);
            if (connection.ConnectionProviderId != null)
                connection.ConnectionProvider =
                    repo.ConnectionProviderRepository.GetDataById(connection.ConnectionProviderId).FirstOrDefault();
            var valResult =
                scriptVal.Validate(connection
                    , _test);


            repo.RunHistoryRepository.Insert(_test.Id,  null, null, connection.ConnectionId, valResult.RunDateTime, valResult.Duration, valResult.IsValid, valResult.RunLog);
            MessageBox.Show(valResult.IsValid.ToString());
        }
    }
}