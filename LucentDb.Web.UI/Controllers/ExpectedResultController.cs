using System.Linq;
using System.Web.Mvc;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers
{
    public class ExpectedResultController : Controller
    {
        private readonly IAssertTypeRepository _dbAssertTypeRepository;
        private readonly IExpectedResultRepository _dbExpectedResultRepository;
        private readonly IExpectedResultTypeRepository _dbExpectedResultTypeRepository;
        private readonly ITestRepository _dbTestRepository;

        public ExpectedResultController(IExpectedResultRepository dbExpectedResultRepository,
            ITestRepository dbTestRepository, IExpectedResultTypeRepository dbExpectedResultTypeRepository,
            IAssertTypeRepository dbAssertTypeRepository)
        {
            _dbExpectedResultRepository = dbExpectedResultRepository;
            _dbTestRepository = dbTestRepository;
            _dbExpectedResultTypeRepository = dbExpectedResultTypeRepository;
            _dbAssertTypeRepository = dbAssertTypeRepository;
        }

        // GET: ExpectedResult
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExpectedResult/Details/5
        [Route("ExpectedResult/Details/{id}", Name = "GetExpectedResultDetails")]
        public ActionResult Details(int id)
        {
            return View(_dbExpectedResultRepository.GetDataById(id).FirstOrDefault());
        }

        // GET: ExpectedResult/Create
        public ActionResult Create()
        {
            ViewBag.Tests = new SelectList(_dbTestRepository.GetData(), "Id", "Name");
            ViewBag.ExpectedResultTypes = new SelectList(_dbExpectedResultTypeRepository.GetData(), "Id", "Name");
            ViewBag.AssertTypes = new SelectList(_dbAssertTypeRepository.GetData(), "Id", "Name");

            return View();
        }

        // POST: ExpectedResult/Create
        [HttpPost]
        public ActionResult Create(ExpectedResult expectedResult)
        {
            try
            {
                _dbExpectedResultRepository.Insert(expectedResult);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(expectedResult);
            }
        }

        // GET: ExpectedResult/Edit/5
        [Route("ExpectedResult/Edit/{id}", Name = "GetExpectedResultEdit")]
        public ActionResult Edit(int id)
        {
            var expectedResult = _dbExpectedResultRepository.GetDataById(id).FirstOrDefault();
            if (expectedResult != null)
                ViewBag.Tests = new SelectList(_dbTestRepository.GetData(), "Id", "Name", expectedResult.TestId);
            if (expectedResult != null)
                ViewBag.ExpectedResultTypes = new SelectList(_dbExpectedResultTypeRepository.GetData(), "Id", "Name",
                    expectedResult.ExpectedResultTypeId);
            if (expectedResult != null)
                ViewBag.AssertTypes = new SelectList(_dbAssertTypeRepository.GetData(), "Id", "Name",
                    expectedResult.AssertTypeId);

            return View(expectedResult);
        }

        // POST: ExpectedResult/Edit/5
        [Route("ExpectedResult/Edit/{id}", Name = "PostExpectedResultEdit")]
        [HttpPost]
        public ActionResult Edit(int id, ExpectedResult expectedResult)
        {
            try
            {
                _dbExpectedResultRepository.Update(expectedResult);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(expectedResult);
            }
        }
    }
}