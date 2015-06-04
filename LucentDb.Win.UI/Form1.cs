using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LucentDb.Domain;
using LucentDb.Domain.Entities;

namespace LucentDb.Win.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            _dataRepository = new DataRepository();
            InitializeComponent();
        }

        private DataRepository _dataRepository;
        private Project _selectedProject;
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
            _selectedProject.Tests = (Collection<Test>) _dataRepository.TestRepository.GetActiveDataByProjectId(_selectedProject.ProjectId);
            cboTests.DataSource = _selectedProject.Tests;
            cboTests.DisplayMember = "Name";
            cboTests.ValueMember = "Id";
           
        }

        private void cboTests_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selectedTest = (Test) cboTests.SelectedItem;
            selectedTest.Project = (Project) cboProjects.SelectedItem;
            selectedTest.Scripts =  (Collection<Script>) _dataRepository.ScriptRepository.GetScriptsForTestByTestId((int)selectedTest.Id);

            foreach (var script in selectedTest.Scripts)
            {
                script.ScriptType =
                    _dataRepository.ScriptTypeRepository.GetDataById(script.ScriptTypeId).FirstOrDefault();
                script.RunHistories = (Collection<RunHistory>) _dataRepository.RunHistoryRepository.GetDataByScriptIdPageable(script.Id,
                    "Id Desc", 1, 5);
                script.Script_ExpectedResult =
                    (Collection<Script_ExpectedResult>) _dataRepository.ScriptExpectedResultRepository.GetDataByScriptId(script.Id);

                foreach (var scrExpResult in script.Script_ExpectedResult)
                {
                    scrExpResult.ExpectedResult =
                        _dataRepository.ExpectedResultRepository.GetDataById(scrExpResult.ExpectedResultId)
                            .FirstOrDefault();
                    if (scrExpResult.ExpectedResult == null) continue;
                    if (scrExpResult.ExpectedResult.AssertTypeId != null)
                        scrExpResult.ExpectedResult.AssertType =
                            _dataRepository.AssertTypeRepository.GetDataById((int) scrExpResult.ExpectedResult.AssertTypeId).FirstOrDefault();
                }
            }
            viewProjectTest1.DataSource = selectedTest;
            // scriptDataGridView.DataSource = selectedTest.Scripts;
            //scriptBindingSource.DataSource = selectedTest.Scripts.FirstOrDefault();

            //scriptGroup1.DataSource = selectedTest.Scripts;
            // scriptGroup1.DataBind();
        }

       

       
    }
}
