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
        // GET: Spec/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = rpAL.GetEngineModel();
            List<SelectListItem> ModelList = new List<SelectListItem>();
            ModelList.Add(new SelectListItem()
            {
                Text = "Select a Model",
                Value = "0",
                Selected = true
            });


            foreach (var item in model.ModelCollection)
            {

                ModelList.Add(new SelectListItem()
                {
                    Text = item.ModelName,
                    Value = item.ModelID.ToString(),
                    Selected = false
                });
                ViewBag.ModelList = ModelList;
                  
            }
            return View();
        }

        // Post: Spec/Create
        [HttpPost]
        public ActionResult Create(ALProject.Models.SpecModel SpecModel,
                                   FormCollection FormCollection)
        {
            if (FormCollection["ModelList"] == "0")
            {

                return RedirectToAction("Create");

            }

            SpecModel.SpecCollection[0].ModelID = Convert.ToInt32(FormCollection["ModelList"]);
            rpAL.AddSpec(SpecModel);

             return RedirectToAction("Index");
            //return View();
        }

        // GET: Spec/Edit/1(id)
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = rpAL.GetSpecModel(id);


            var ModelCollection = rpAL.GetEngineModel().ModelCollection;

            ViewBag.ModelList = new SelectList(ModelCollection, "ModelID", "ModelName", model.SpecCollection[0].ModelID);

            return View(model);

        }

        //Post: Spec/Edit
        [HttpPost, ActionName("Edit")]
        public ActionResult Editmethod(ALProject.Models.SpecModel model,
                           FormCollection FormCollection)
        {

            model.SpecCollection[0].ModelID = Convert.ToInt32(FormCollection["ModelList"]);

            rpAL.UpdateSpecModel(model);

            return RedirectToAction("Index");

        }

        // GET: Spec/Delete/1(id)
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = rpAL.GetSpecModel(id);
            return View(model);

        }
        // POST: Spec/Delete/1(id)
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteSpec(int id)
        {
            //Retrieve entire collection

            rpAL.DeleteSpecModel(id);

            return RedirectToAction("Index");
        }

    }
}