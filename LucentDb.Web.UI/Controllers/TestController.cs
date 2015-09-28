//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System.Linq;
using System.Web.Mvc;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers
{
    public class TestController : Controller
    {
        private readonly IProjectRepository _dbProjectRepository;
        private readonly ITestGroupRepository _dbTestGroupRepository;
        private readonly ITestRepository _dbTestRepository;
        private readonly ITestTypeRepository _dbTestTypeRepository;

        public TestController(ITestRepository dbTestRepository, ITestTypeRepository dbTestTypeRepository,
            IProjectRepository dbProjectRepository, ITestGroupRepository dbTestGroupRepository)
        {
            _dbTestRepository = dbTestRepository;
            _dbTestTypeRepository = dbTestTypeRepository;
            _dbProjectRepository = dbProjectRepository;
            _dbTestGroupRepository = dbTestGroupRepository;
        }

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        // GET: Test/Details/5
        [Route("Test/Details/{id}")]
        public ActionResult Details(int id)
        {
            var test = _dbTestRepository.GetDataById(id).FirstOrDefault();
            ViewBag.TestTypes = _dbTestTypeRepository.GetData().ToList();
            ViewBag.Projects = _dbProjectRepository.GetData().ToList();
            ViewBag.TestGroups = _dbTestGroupRepository.GetData().ToList();

            return View(test);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            ViewBag.TestTypes = _dbTestTypeRepository.GetData();
            ViewBag.Projects = _dbProjectRepository.GetData();
            ViewBag.TestGroups = _dbTestGroupRepository.GetData();
       
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(Test test)
        {
            try
            {
                _dbTestRepository.Insert(test);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(test);
            }
        }

        // GET: Test/Edit/5
        [Route("Test/Edit/{id}", Name = "GetTestEdit")]
        [Route("Test/{id}")]
        public ActionResult Edit(int id = 0)
        {
            if (id == 0) return View("Index");
            var test = _dbTestRepository.GetDataById(id).FirstOrDefault();
            ViewBag.TestTypes = _dbTestTypeRepository.GetData().ToList();
            ViewBag.Projects = _dbProjectRepository.GetData().ToList();
            ViewBag.TestGroups = _dbTestGroupRepository.GetData().ToList();

            return View(test);
        }

        // POST: Test/Edit/5
        [Route("Test/Edit/{id}", Name = "PostTestEdit")]
        [HttpPost]
        public ActionResult Edit(int id, Test test)
        {
            try
            {
                _dbTestRepository.Update(test);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(test);
            }
        }
    }
}