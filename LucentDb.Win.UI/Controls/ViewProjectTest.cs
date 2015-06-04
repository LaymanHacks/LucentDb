using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LucentDb.Domain.Entities;

namespace LucentDb.Win.UI.Controls
{
    public partial class ViewProjectTest : UserControl
    {
        private Test _selectedTest;
       

        public ViewProjectTest()
        {
            
            InitializeComponent();
        }
        public ViewProjectTest(Test selectedTest)
        {
            _selectedTest = selectedTest;
            InitializeComponent();
            DataBind();
        }

        public Test DataSource
        {
            get { return _selectedTest; }
            set { _selectedTest = value; DataBind();}
        }

        private void DataBind()
        {
            lblProjectName.Text = _selectedTest.Project.Name;
            
                 lblTestName.Text = _selectedTest.Name;
                 scriptGroup.DataSource = _selectedTest.Scripts;
                 scriptGroup.DataBind();
            
        }
    }
}
