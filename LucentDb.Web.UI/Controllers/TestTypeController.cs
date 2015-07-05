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
    public class TestTypeController : Controller
    {
        private readonly ITestTypeRepository _dbTestTypeRepository;

        public TestTypeController(ITestTypeRepository dbTestTypeRepository)
        {
            _dbTestTypeRepository = dbTestTypeRepository;
        }

        // GET: TestType
        public ActionResult Index()
        {
            return View();
        }

        // GET: TestType/Details/5
        [Route("TestType/Details/{id}", Name = "GetTestTypeDetails")]
        public ActionResult Details(int id)
        {
            return View(_dbTestTypeRepository.GetDataById(id).FirstOrDefault());
        }

        // GET: TestType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestType/Create
        [HttpPost]
        public ActionResult Create(TestType testType)
        {
            try
            {
                _dbTestTypeRepository.Insert(testType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(testType);
            }
        }

        // GET: TestType/Edit/5
        [Route("TestType/Edit/{id}", Name = "GetTestTypeEdit")]
        public ActionResult Edit(int id)
        {
            var testType = _dbTestTypeRepository.GetDataById(id).FirstOrDefault();

            return View(testType);
        }

        // POST: TestType/Edit/5
        [Route("TestType/Edit/{id}", Name = "PostTestTypeEdit")]
        [HttpPost]
        public ActionResult Edit(int id, TestType testType)
        {
            try
            {
                _dbTestTypeRepository.Update(testType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(testType);
            }
        }
    }
}