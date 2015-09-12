//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Web.Mvc;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers
{
    public class ProjectDetailsViewController : Controller
    {
        private readonly IProjectDetailsViewRepository _dbProjectDetailsViewRepository;
        

        public ProjectDetailsViewController(IProjectDetailsViewRepository dbProjectDetailsViewRepository)
        {
            _dbProjectDetailsViewRepository = dbProjectDetailsViewRepository;
            
        }
        
        // GET: ProjectDetailsView
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProjectDetailsView/Details/5
        [Route("ProjectDetailsView/Details/", Name = "GetProjectDetailsViewDetails")]
        public ActionResult Details()
        {
            return View(_dbProjectDetailsViewRepository.GetDataBy().FirstOrDefault());
        }

        // GET: ProjectDetailsView/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: ProjectDetailsView/Create
        [HttpPost]
        public ActionResult Create(ProjectDetailsView projectDetailsView)
        {
            try
            {
                _dbProjectDetailsViewRepository.Insert(projectDetailsView);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(projectDetailsView);
            }
        }

        // GET: ProjectDetailsView/Edit/5
        [Route("ProjectDetailsView/Edit/", Name = "GetProjectDetailsViewEdit")]
        public ActionResult Edit()
        {
        	var projectDetailsView = _dbProjectDetailsViewRepository.GetDataBy().FirstOrDefault();    
            
            return View(projectDetailsView);
        }

        // POST: ProjectDetailsView/Edit/5
        [Route("ProjectDetailsView/Edit/", Name = "PostProjectDetailsViewEdit")]
        [HttpPost]
        public ActionResult Edit(ProjectDetailsView projectDetailsView)
        {
            try
            {
                _dbProjectDetailsViewRepository.Update(projectDetailsView);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(projectDetailsView);
            }
        }
   }
}
