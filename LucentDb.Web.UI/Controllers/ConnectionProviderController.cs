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
    public class ConnectionProviderController : Controller
    {
        private readonly IConnectionProviderRepository _dbConnectionProviderRepository;

        public ConnectionProviderController(IConnectionProviderRepository dbConnectionProviderRepository)
        {
            _dbConnectionProviderRepository = dbConnectionProviderRepository;
        }

        // GET: ConnectionProvider
        public ActionResult Index()
        {
            return View();
        }

        // GET: ConnectionProvider/Details/5
        [Route("ConnectionProvider/Details/{id}", Name = "GetConnectionProviderDetails")]
        public ActionResult Details(int id)
        {
            return View(_dbConnectionProviderRepository.GetDataById(id).FirstOrDefault());
        }

        // GET: ConnectionProvider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConnectionProvider/Create
        [HttpPost]
        public ActionResult Create(ConnectionProvider connectionProvider)
        {
            try
            {
                _dbConnectionProviderRepository.Insert(connectionProvider);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(connectionProvider);
            }
        }

        // GET: ConnectionProvider/Edit/5
        [Route("ConnectionProvider/Edit/{id}", Name = "GetConnectionProviderEdit")]
        public ActionResult Edit(int id)
        {
            var connectionProvider = _dbConnectionProviderRepository.GetDataById(id).FirstOrDefault();

            return View(connectionProvider);
        }

        // POST: ConnectionProvider/Edit/5
        [Route("ConnectionProvider/Edit/{id}", Name = "PostConnectionProviderEdit")]
        [HttpPost]
        public ActionResult Edit(int id, ConnectionProvider connectionProvider)
        {
            try
            {
                _dbConnectionProviderRepository.Update(connectionProvider);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(connectionProvider);
            }
        }
    }
}