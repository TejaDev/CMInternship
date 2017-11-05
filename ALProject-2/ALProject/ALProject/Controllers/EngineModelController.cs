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
        // GET: Model/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Post: Model/Create
        [HttpPost]
        public ActionResult Create(ALProject.Models.EngineModelModel ModelModel)
        {

            rpAL.AddModel(ModelModel);

            return RedirectToAction("Index","Spec","Create");
            //return View();
        }

        // GET: EngineModel/1(id)
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Request.QueryString["mode"] == "redirect")
            {
                return RedirectToAction("Edit", "Spec", new { id = id });
            }

            //Retrieve entire collection

            var model = rpAL.GetModelSpecViewModel();

            model.EngineViewModel = rpAL.GetEngineModel(id);
            model.SpecViewModel = rpAL.FindSpecModelByEngineModel(id);
            return View(model);

        }
        //Post: Model/Edit
        [HttpPost, ActionName("Edit")]
        public ActionResult Editmethod(int id, ALProject.ViewModels.ModelSpec ViewModel)// FormCollection Collection)
        {
            

            rpAL.UpdateEngineSpecModel(ViewModel);

               return RedirectToAction("Index");
            
        }

            // GET: EngineModel/Delete/1(id)
        [HttpGet]
        public ActionResult Delete(int id)
        {

            if (Request.QueryString["mode"] == "redirect")
            {
                return RedirectToAction("Delete", "Spec", new { id = id });
            }

            //Retrieve entire collection

            var model = rpAL.GetModelSpecViewModel();
            model.SpecViewModel = rpAL.FindSpecModelByEngineModel(id);
            return View(model);
        }
        // POST: EngineModel/Delete/1(id)
        [HttpPost,ActionName("Delete")]
        public ActionResult Deletemethod(int id)
        {
            //Retrieve entire collection

            rpAL.DeleteEngineModel(id);

            return RedirectToAction("Index");
        }
    }
}