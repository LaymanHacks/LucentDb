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
    public class Script_ExpectedResultController : Controller
    {
        private readonly IScript_ExpectedResultRepository _dbScript_ExpectedResultRepository;
        private readonly IScriptRepository _dbScriptRepository;
        private readonly IExpectedResultRepository _dbExpectedResultRepository;
        

        public Script_ExpectedResultController(IScript_ExpectedResultRepository dbScript_ExpectedResultRepository, IScriptRepository dbScriptRepository, IExpectedResultRepository dbExpectedResultRepository)
        {
            _dbScript_ExpectedResultRepository = dbScript_ExpectedResultRepository;
            _dbScriptRepository = dbScriptRepository; 
            _dbExpectedResultRepository = dbExpectedResultRepository; 
            
        }
        
        // GET: Script_ExpectedResult
        public ActionResult Index()
        {
            return View();
        }

        // GET: Script_ExpectedResult/Details/5
        [Route("Script_ExpectedResult/Details/{scriptId}/{expectedResultId}", Name = "GetScript_ExpectedResultDetails")]
        public ActionResult Details(Int32 scriptId, Int32 expectedResultId)
        {
            return View(_dbScript_ExpectedResultRepository.GetDataByScriptIdExpectedResultId(scriptId, expectedResultId).FirstOrDefault());
        }

        // GET: Script_ExpectedResult/Create
        public ActionResult Create()
        {
            ViewBag.Scripts = new SelectList(_dbScriptRepository.GetData(), "Id", "Id");
            ViewBag.ExpectedResults = new SelectList(_dbExpectedResultRepository.GetData(), "Id", "Id");
            
            return View();
        }

        // POST: Script_ExpectedResult/Create
        [HttpPost]
        public ActionResult Create(Script_ExpectedResult script_ExpectedResult)
        {
            try
            {
                _dbScript_ExpectedResultRepository.Insert(script_ExpectedResult);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(script_ExpectedResult);
            }
        }

        // GET: Script_ExpectedResult/Edit/5
        [Route("Script_ExpectedResult/Edit/{scriptId}/{expectedResultId}", Name = "GetScript_ExpectedResultEdit")]
        public ActionResult Edit(Int32 scriptId, Int32 expectedResultId)
        {
        	var script_ExpectedResult = _dbScript_ExpectedResultRepository.GetDataByScriptIdExpectedResultId(scriptId, expectedResultId).FirstOrDefault();    
            if (script_ExpectedResult != null) ViewBag.Scripts = new SelectList(_dbScriptRepository.GetData(), "Id", "Id", script_ExpectedResult.ScriptId);
            if (script_ExpectedResult != null) ViewBag.ExpectedResults = new SelectList(_dbExpectedResultRepository.GetData(), "Id", "Id", script_ExpectedResult.ExpectedResultId);
            
            return View(script_ExpectedResult);
        }

        // POST: Script_ExpectedResult/Edit/5
        [Route("Script_ExpectedResult/Edit/{scriptId}/{expectedResultId}", Name = "PostScript_ExpectedResultEdit")]
        [HttpPost]
        public ActionResult Edit(Int32 scriptId, Int32 expectedResultId, Script_ExpectedResult script_ExpectedResult)
        {
            try
            {
                _dbScript_ExpectedResultRepository.Update(script_ExpectedResult);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(script_ExpectedResult);
            }
        }
   }
}
