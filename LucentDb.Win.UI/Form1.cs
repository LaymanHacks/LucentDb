using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using LucentDb.Domain;
using LucentDb.Domain.Entities;

namespace LucentDb.Win.UI
{
    public partial class Form1 : Form
    {
        private readonly DbRepositoryContext _dataRepository;
        private Project _selectedProject;

        public Form1()
        {
            _dataRepository = new DbRepositoryContext();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var activeProjects = _dataRepository.ProjectRepository.GetActiveData();
            cboProjects.DataSource = activeProjects;
            cboProjects.DisplayMember = "Name";
            cboProjects.ValueMember = "ProjectId";
        }

        private void cboProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedProject = (Project) cboProjects.SelectedItem;
            //_selectedProject.Tests = (Collection<Test>) _dataRepository.TestRepository.GetActiveDataByProjectId(_selectedProject.ProjectId);
            //cboTests.DataSource = _selectedProject.Tests;
            //cboTests.DisplayMember = "Name";
            //cboTests.ValueMember = "Id";


            _selectedProject.Tests =
                (Collection<Test>) _dataRepository.TestRepository.GetActiveDataByProjectId(_selectedProject.ProjectId);

            foreach (var test in _selectedProject.Tests)
            {
                test.TestType =
                    _dataRepository.TestTypeRepository.GetDataById(test.TestTypeId).FirstOrDefault();
                test.RunHistories =
                    (Collection<RunHistory>)
                        _dataRepository.RunHistoryRepository.GetDataByTestIdPageable(test.Id, "Id Desc", 1,
                            5).Results;
                test.ExpectedResults =
                    (Collection<ExpectedResult>) _dataRepository.ExpectedResultRepository.GetDataByTestId(test.Id);

                foreach (var expResult in test.ExpectedResults)
                {
                    if (expResult == null) continue;
                    if (expResult.AssertTypeId != null)
                        expResult.AssertType =
                            _dataRepository.AssertTypeRepository.GetDataById((int) expResult.AssertTypeId)
                                .FirstOrDefault();
                }
            }
            viewProjectTest1.DataSource = _selectedProject;
        }

        private void cboTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            // scriptDataGridView.DataSource = selectedTest.Scripts;
            //scriptBindingSource.DataSource = selectedTest.Scripts.FirstOrDefault();

            //scriptGroup1.DataSource = selectedTest.Scripts;
            // scriptGroup1.DataBind();
        }

        private void cboTests_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }
    }
}