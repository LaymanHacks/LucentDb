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
         [Route("Tests")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Tests/{id}/Details")]
        public ActionResult Details(int id)
        {
            var test = _dbTestRepository.GetDataById(id).FirstOrDefault();
            ViewBag.TestTypes = _dbTestTypeRepository.GetData().ToList();
            ViewBag.Projects = _dbProjectRepository.GetData().ToList();
            ViewBag.TestGroups = _dbTestGroupRepository.GetData().ToList();

            return View(test);
        }

        [Route("Projects/{projectId}/Tests")]
        public ActionResult GetTestsByProject(int projectId)
        {
            var test = _dbTestRepository.GetActiveDataByProjectId(projectId);
          

            return View(test);
        }

        [Route("Tests/Create")]
        public ActionResult Create()
        {
            ViewBag.TestTypes = _dbTestTypeRepository.GetData();
            ViewBag.Projects = _dbProjectRepository.GetData();
            ViewBag.TestGroups = _dbTestGroupRepository.GetData();
       
            return View();
        }

         [Route("Tests/Create")]
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

       [Route("Tests/{id}")]
        public ActionResult Edit(int id = 0)
        {
            if (id == 0) return View("Index");
            var test = _dbTestRepository.GetDataById(id).FirstOrDefault();
            ViewBag.TestTypes = _dbTestTypeRepository.GetData().ToList();
            ViewBag.Projects = _dbProjectRepository.GetData().ToList();
            ViewBag.TestGroups = _dbTestGroupRepository.GetData().ToList();

            return View(test);
        }

        [Route("Tests/{id}")]
        [HttpPost]
        public ActionResult Edit(int id, Test test)
        {
            try
            {
                test.TestValueTypeId = 1;
                _dbTestRepository.Update(test);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.TestTypes = _dbTestTypeRepository.GetData().ToList();
                ViewBag.Projects = _dbProjectRepository.GetData().ToList();
                ViewBag.TestGroups = _dbTestGroupRepository.GetData().ToList();
                return View(test);
            }
        }
    }
}