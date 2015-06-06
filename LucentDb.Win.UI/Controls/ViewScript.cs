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
    public partial class ViewScript : UserControl
    {

        private Script _script;

        public ViewScript()
        {
            
            InitializeComponent();
        }

        public ViewScript(Script script)
        {
            _script = script;
            InitializeComponent();
            txtScriptValue.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("SQL");

            BindData();

        }

        private void BindData()
        {
            txtScriptValue.Text = _script.ScriptValue;
            lblName.Text = _script.Name;
            lblAssertType.Text = _script.Script_ExpectedResult[0].ExpectedResult.AssertType.Name;
            lblAssertValue.Text = _script.Script_ExpectedResult[0].ExpectedResult.ExpectedValue;
            isActiveCheckBox.Checked = _script.IsActive;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }
    }
}
