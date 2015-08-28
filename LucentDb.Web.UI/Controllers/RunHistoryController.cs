using System.Linq;
using System.Web.Mvc;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers
{
    public class RunHistoryController : Controller
    {
        private readonly IRunHistoryRepository _dbRunHistoryRepository;
        private readonly ITestRepository _dbTestRepository;

        public RunHistoryController(IRunHistoryRepository dbRunHistoryRepository, ITestRepository dbTestRepository)
        {
            _dbRunHistoryRepository = dbRunHistoryRepository;
            _dbTestRepository = dbTestRepository;
        }

        // GET: RunHistory
        public ActionResult Index()
        {
            return View();
        }

        // GET: RunHistory/Details/5
        [Route("RunHistory/Details/{id}", Name = "GetRunHistoryDetails")]
        public ActionResult Details(long id)
        {
            return View(_dbRunHistoryRepository.GetDataById(id).FirstOrDefault());
        }

        // GET: RunHistory/Create
        public ActionResult Create()
        {
            ViewBag.Tests = new SelectList(_dbTestRepository.GetData(), "Id", "Id");

            return View();
        }

        // POST: RunHistory/Create
        [HttpPost]
        public ActionResult Create(RunHistory runHistory)
        {
            try
            {
                _dbRunHistoryRepository.Insert(runHistory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(runHistory);
            }
        }

        // GET: RunHistory/Edit/5
        [Route("RunHistory/Edit/{id}", Name = "GetRunHistoryEdit")]
        public ActionResult Edit(long id)
        {
            var runHistory = _dbRunHistoryRepository.GetDataById(id).FirstOrDefault();
            if (runHistory != null)
                ViewBag.Tests = new SelectList(_dbTestRepository.GetData(), "Id", "Id", runHistory.TestId);

            return View(runHistory);
        }

        // POST: RunHistory/Edit/5
        [Route("RunHistory/Edit/{id}", Name = "PostRunHistoryEdit")]
        [HttpPost]
        public ActionResult Edit(long id, RunHistory runHistory)
        {
            try
            {
                _dbRunHistoryRepository.Update(runHistory);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(runHistory);
            }
        }
    }
}