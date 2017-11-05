using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALProject.RepositoryAL;
using ALProject.ViewModels;

namespace ALProject.Controllers
{
    public class CategoryController : Controller
    {
        private AccessoryListingRepository rpAL = new AccessoryListingRepository();

        // GET: Category
        public ActionResult Index()
        {
            var model = rpAL.GetCategoryModel();
            return View(model);
        }
    }
}