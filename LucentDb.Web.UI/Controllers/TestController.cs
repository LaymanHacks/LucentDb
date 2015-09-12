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
        [Route("Test/Details/{id}", Name = "GetTestDetails")]
        public ActionResult Details(int id)
        {
            return View(_dbTestRepository.GetDataById(id).FirstOrDefault());
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            ViewBag.TestTypes = new SelectList(_dbTestTypeRepository.GetData(), "Id", "Name");
            ViewBag.Projects = new SelectList(_dbProjectRepository.GetData(), "ProjectId", "Name");
            ViewBag.TestGroups = new SelectList(_dbTestGroupRepository.GetData(), "Id", "Name");

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
        public ActionResult Edit(int id)
        {
            var test = _dbTestRepository.GetDataById(id).FirstOrDefault();
            if (test != null)
                ViewBag.TestTypes = new SelectList(_dbTestTypeRepository.GetData(), "Id", "Name", test.TestTypeId);
            if (test != null)
                ViewBag.Projects = new SelectList(_dbProjectRepository.GetData(), "ProjectId", "Name",
                    test.ProjectId);
            if (test != null)
                ViewBag.TestGroups = new SelectList(_dbTestGroupRepository.GetData(), "Id", "Name", test.GroupId);

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