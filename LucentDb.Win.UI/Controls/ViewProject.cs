using System.Windows.Forms;
using LucentDb.Domain.Entities;

namespace LucentDb.Win.UI.Controls
{
    public partial class ViewProject : UserControl
    {
        private Project _selectedProject;
       

        public ViewProject()
        {
            
            InitializeComponent();
        }
        public ViewProject(Project selectedProject)
        {
            _selectedProject = selectedProject;
            InitializeComponent();
            DataBind();
        }

        public Project DataSource
        {
            get { return _selectedProject; }
            set { _selectedProject = value; DataBind();}
        }

        private void DataBind()
        {
            lblProjectName.Text = _selectedProject.Name;
            
                 //lblTestName.Text = _selectedProject.Name;
                 scriptGroup.DataSource = _selectedProject.Tests;
                 scriptGroup.DataBind();
            
        }
    }
}
