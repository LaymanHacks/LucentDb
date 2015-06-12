﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using LucentDb.Domain.Entities;

namespace LucentDb.Win.UI.Controls
{
    public partial class TestGroup : UserControl
    {
        public TestGroup()
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
                    //AutoSize = true
                    Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom)
                              | AnchorStyles.Left)
                             | AnchorStyles.Right
                };
                tlpScripts.Controls.Add(scriptViewer, 1, row++);
              }
          

        }

       
    }
}