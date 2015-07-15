using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using LucentDb.Domain.Entities;

namespace LucentDb.Win.UI.Controls
{
    public partial class TestList : UserControl
    {
        public TestList()
        {
            InitializeComponent();
        }

        public Collection<Test> DataSource { get; set; }

        private void ScriptGroup_Load(object sender, EventArgs e)
        {
        }

        public void DataBind()
        {
            var row = 0;
            if (DataSource == null) return;
            foreach (var script in DataSource)
            {
                tlpScripts.RowCount = DataSource.Count;
                var scriptViewer = new ViewTest(script)
                {
                    Dock = DockStyle.Top,
                    Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                              | AnchorStyles.Left)
                             | AnchorStyles.Right
                };
                tlpScripts.Controls.Add(scriptViewer, 1, row++);
            }
        }
    }
}