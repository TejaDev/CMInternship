using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALProject.RepositoryAL;
using ALProject.ViewModels;

namespace ALProject.Controllers
{
    public class DescriptionController : Controller

    {
        private AccessoryListingRepository rpAL = new AccessoryListingRepository();

        // GET: Description
        public ActionResult Index()
        {
            var model = rpAL.GetDescriptionModel();
            return View(model);
        }
    }
}