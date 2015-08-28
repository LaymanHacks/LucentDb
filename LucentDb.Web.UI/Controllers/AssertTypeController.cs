using System.Linq;
using System.Web.Mvc;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers
{
    public class AssertTypeController : Controller
    {
        private readonly IAssertTypeRepository _dbAssertTypeRepository;

        public AssertTypeController(IAssertTypeRepository dbAssertTypeRepository)
        {
            _dbAssertTypeRepository = dbAssertTypeRepository;
        }

        // GET: AssertType
        public ActionResult Index()
        {
            return View();
        }

        // GET: AssertType/Details/5
        [Route("AssertType/Details/{id}", Name = "GetAssertTypeDetails")]
        public ActionResult Details(int id)
        {
            return View(_dbAssertTypeRepository.GetDataById(id).FirstOrDefault());
        }

        // GET: AssertType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssertType/Create
        [HttpPost]
        public ActionResult Create(AssertType assertType)
        {
            try
            {
                _dbAssertTypeRepository.Insert(assertType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(assertType);
            }
        }

        // GET: AssertType/Edit/5
        [Route("AssertType/Edit/{id}", Name = "GetAssertTypeEdit")]
        public ActionResult Edit(int id)
        {
            var assertType = _dbAssertTypeRepository.GetDataById(id).FirstOrDefault();

            return View(assertType);
        }

        // POST: AssertType/Edit/5
        [Route("AssertType/Edit/{id}", Name = "PostAssertTypeEdit")]
        [HttpPost]
        public ActionResult Edit(int id, AssertType assertType)
        {
            try
            {
                _dbAssertTypeRepository.Update(assertType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(assertType);
            }
        }
    }
}