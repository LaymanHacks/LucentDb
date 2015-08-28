using System.Linq;
using System.Web.Mvc;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers
{
    public class ConnectionController : Controller
    {
        private readonly IConnectionRepository _dbConnectionRepository;

        public ConnectionController(IConnectionRepository dbConnectionRepository)
        {
            _dbConnectionRepository = dbConnectionRepository;
        }

        // GET: Connection
        public ActionResult Index()
        {
            return View();
        }

        // GET: Connection/Details/5
        [Route("Connection/Details/{connectionId}", Name = "GetConnectionDetails")]
        public ActionResult Details(int connectionId)
        {
            return View(_dbConnectionRepository.GetDataByConnectionId(connectionId).FirstOrDefault());
        }

        // GET: Connection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Connection/Create
        [HttpPost]
        public ActionResult Create(Connection connection)
        {
            try
            {
                _dbConnectionRepository.Insert(connection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(connection);
            }
        }

        // GET: Connection/Edit/5
        [Route("Connection/Edit/{connectionId}", Name = "GetConnectionEdit")]
        public ActionResult Edit(int connectionId)
        {
            var connection = _dbConnectionRepository.GetDataByConnectionId(connectionId).FirstOrDefault();

            return View(connection);
        }

        // POST: Connection/Edit/5
        [Route("Connection/Edit/{connectionId}", Name = "PostConnectionEdit")]
        [HttpPost]
        public ActionResult Edit(int connectionId, Connection connection)
        {
            try
            {
                _dbConnectionRepository.Update(connection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(connection);
            }
        }
    }
}