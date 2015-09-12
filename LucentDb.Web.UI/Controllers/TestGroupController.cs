//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Web.Mvc;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers
{
    public class TestGroupController : Controller
    {
        private readonly ITestGroupRepository _dbTestGroupRepository;
        private readonly IProjectRepository _dbProjectRepository;


        public TestGroupController(ITestGroupRepository dbTestGroupRepository, IProjectRepository dbProjectRepository)
        {
            _dbTestGroupRepository = dbTestGroupRepository;
            _dbProjectRepository = dbProjectRepository;
            
        }

        // GET: TestGroup
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestGroup/Details/5
        [Route("TestGroup/Details/{id}", Name = "GetTestGroupDetails")]
        public ActionResult Details(Int32 id)
        {
            return View(_dbTestGroupRepository.GetDataById(id).FirstOrDefault());
        }

        // GET: TestGroup/Create
        public ActionResult Create()
        {
            ViewBag.Projects = new SelectList(_dbProjectRepository.GetData(), "ProjectId", "Name");

            return View();
        }

        // POST: TestGroup/Create
        [HttpPost]
        public ActionResult Create(TestGroup testGroup)
        {
            try
            {
                _dbTestGroupRepository.Insert(testGroup);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(testGroup);
            }
        }

        // GET: TestGroup/Edit/5
        [Route("TestGroup/Edit/{id}", Name = "GetTestGroupEdit")]
        public ActionResult Edit(Int32 id)
        {
            var testGroup = _dbTestGroupRepository.GetDataById(id).FirstOrDefault();
            if (testGroup != null)
                ViewBag.Projects = new SelectList(_dbProjectRepository.GetData(), "ProjectId", "Name",
                    testGroup.ProjectId);

            return View(testGroup);
        }

        // POST: TestGroup/Edit/5
        [Route("TestGroup/Edit/{id}", Name = "PostTestGroupEdit")]
        [HttpPost]
        public ActionResult Edit(Int32 id, TestGroup testGroup)
        {
            try
            {
                _dbTestGroupRepository.Update(testGroup);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(testGroup);
            }
        }
    }
}