using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using LucentDb.Domain.Entities;

namespace LucentDb.Win.UI.Controls
{
    public partial class ViewTest : UserControl
    {

        private  Test _test;

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
            MessageBox.Show("Test Run!");
        }
    }
}
