using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALProject.RepositoryAL;
using ALProject.ViewModels;

namespace ALProject.Controllers
{
    public class EngineModelController : Controller
    {
        private AccessoryListingRepository rpAL = new AccessoryListingRepository();

        // GET: EngineModel
        public ActionResult Index()
        {
            var model = rpAL.GetEngineModel();
            return View(model);
        }

        // GET: EngineModel
        public ActionResult EditModel(int modelID)
        {
            var model = rpAL.GetEngineModel();
            return View(model);
        }
    }
}