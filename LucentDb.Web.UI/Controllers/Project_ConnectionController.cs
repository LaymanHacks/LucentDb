

using System.Linq;
using System.Web.Mvc;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers
{
    public class Project_ConnectionController : Controller
    {
        private readonly IConnectionRepository _dbConnectionRepository;
        private readonly IProject_ConnectionRepository _dbProject_ConnectionRepository;
        private readonly IProjectRepository _dbProjectRepository;

        public Project_ConnectionController(IProject_ConnectionRepository dbProject_ConnectionRepository,
            IProjectRepository dbProjectRepository, IConnectionRepository dbConnectionRepository)
        {
            _dbProject_ConnectionRepository = dbProject_ConnectionRepository;
            _dbProjectRepository = dbProjectRepository;
            _dbConnectionRepository = dbConnectionRepository;
        }

        // GET: Project_Connection
        public ActionResult Index()
        {
            return View();
        }

        // GET: Project_Connection/Details/5
        [Route("Project_Connection/Details/{projectId}/{connectionId}", Name = "GetProject_ConnectionDetails")]
        public ActionResult Details(int projectId, int connectionId)
        {
            return
                View(
                    _dbProject_ConnectionRepository.GetDataByProjectIdConnectionId(projectId, connectionId)
                        .FirstOrDefault());
        }

        // GET: Project_Connection/Create
        public ActionResult Create()
        {
            ViewBag.Projects = new SelectList(_dbProjectRepository.GetData(), "ProjectId", "ProjectId");
            ViewBag.Connections = new SelectList(_dbConnectionRepository.GetData(), "ConnectionId", "ConnectionId");

            return View();
        }

        // POST: Project_Connection/Create
        [HttpPost]
        public ActionResult Create(Project_Connection project_Connection)
        {
            try
            {
                _dbProject_ConnectionRepository.Insert(project_Connection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(project_Connection);
            }
        }

        // GET: Project_Connection/Edit/5
        [Route("Project_Connection/Edit/{projectId}/{connectionId}", Name = "GetProject_ConnectionEdit")]
        public ActionResult Edit(int projectId, int connectionId)
        {
            var project_Connection =
                _dbProject_ConnectionRepository.GetDataByProjectIdConnectionId(projectId, connectionId).FirstOrDefault();
            if (project_Connection != null)
                ViewBag.Projects = new SelectList(_dbProjectRepository.GetData(), "ProjectId", "ProjectId",
                    project_Connection.ProjectId);
            if (project_Connection != null)
                ViewBag.Connections = new SelectList(_dbConnectionRepository.GetData(), "ConnectionId", "ConnectionId",
                    project_Connection.ConnectionId);

            return View(project_Connection);
        }

        // POST: Project_Connection/Edit/5
        [Route("Project_Connection/Edit/{projectId}/{connectionId}", Name = "PostProject_ConnectionEdit")]
        [HttpPost]
        public ActionResult Edit(int projectId, int connectionId, Project_Connection project_Connection)
        {
            try
            {
                _dbProject_ConnectionRepository.Update(project_Connection, projectId, connectionId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(project_Connection);
            }
        }
    }
}