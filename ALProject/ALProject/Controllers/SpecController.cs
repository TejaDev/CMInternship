using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALProject.RepositoryAL;
using ALProject.ViewModels;

namespace ALProject.Controllers
{
    public class SpecController : Controller
    {
        private AccessoryListingRepository rpAL = new AccessoryListingRepository();

        // GET: Spec
        public ActionResult Index()
        {
            var model = rpAL.GetSpecModel();
            return View(model);
        }
    }
}