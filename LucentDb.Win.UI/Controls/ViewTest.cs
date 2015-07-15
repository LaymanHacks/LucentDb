using System;
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
            var scriptVal = new SqlScriptValidator();
            var valResult =
                scriptVal.Validate(
                    new Connection(1, 1, "Chinook",
                        @"Data Source=.\sqlexpress;Initial Catalog=Chinook;Integrated Security=True;", true), _test);
            var repo = new WebApiRepositoryContext("http://localhost:60205/");
            
            repo.RunHistoryRepository.Insert(_test.Id, valResult.RunDateTime, valResult.IsValid, valResult.RunLog, valResult.ResultMessage);
            MessageBox.Show(valResult.IsValid.ToString());
        }
    }
}