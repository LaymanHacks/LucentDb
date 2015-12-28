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
        [Route("connections/{connectionId}/testgroups/{groupId}/validate")]
        public ActionResult ValidateTestGroup(int groupId, int connectionId = 0)
        {
            ViewBag.GroupId = groupId;
            ViewBag.ConnectionId = connectionId;
            return View();
        }

    }
}