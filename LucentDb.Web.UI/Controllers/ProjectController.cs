using System.Linq;
using System.Web.Mvc;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _dbProjectRepository;

        public ProjectController(IProjectRepository dbProjectRepository)
        {
            _dbProjectRepository = dbProjectRepository;
        }

        // GET: Project
        public ActionResult Index()
        {
            return View();
        }

        // GET: Project/Details/5
        [Route("Project/Details/{projectId}", Name = "GetProjectDetails")]
        public ActionResult Details(int projectId)
        {
            return View(_dbProjectRepository.GetDataByProjectId(projectId).FirstOrDefault());
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(Project project)
        {
            try
            {
                _dbProjectRepository.Insert(project);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(project);
            }
        }

        // GET: Project/Edit/5
        [Route("Project/Edit/{projectId}", Name = "GetProjectEdit")]
        public ActionResult Edit(int projectId)
        {
            var project = _dbProjectRepository.GetDataByProjectId(projectId).FirstOrDefault();

            return View(project);
        }

        // POST: Project/Edit/5
        [Route("Project/Edit/{projectId}", Name = "PostProjectEdit")]
        [HttpPost]
        public ActionResult Edit(int projectId, Project project)
        {
            try
            {
                _dbProjectRepository.Update(project);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(project);
            }
        }
    }
}