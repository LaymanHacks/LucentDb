using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LucentDb.Web.UI.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Validation
        public ActionResult Index()
        {
            return View();
        }

        [Route("testgroups/{groupId}/validate")]
        [Route("testgroups/{groupId}/connections/{connectionId}/validate")]
        public ActionResult ValidateTestGroup(int groupId, int connectionId = 0)
        {
            ViewBag.GroupId = groupId;
            ViewBag.ConnectionId = connectionId;
            return View();
        }


        [Route("tests/{testId}/validate")]
        [Route("tests/{testId}/connections/{connectionId}/validate")]
        public ActionResult ValidateTest(int testId, int connectionId = 0)
        {
            ViewBag.testId = testId;
            ViewBag.ConnectionId = connectionId;
            return View();
        }

         [Route("projects/{projectId}/validate")]
         [Route("projects/{projectId}/connections/{connectionId}/validate")]
        public ActionResult ValidateProject(int projectId, int connectionId = 0)
        {
            ViewBag.projectId = projectId;
            ViewBag.ConnectionId = connectionId;
            return View();
        }
    
    }
}