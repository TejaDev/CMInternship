using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ALProject.RepositoryAL;
using ALProject.ViewModels;

namespace ALProject.Controllers
{
    public class ALController : Controller
    {
        private AccessoryListingRepository rpAL = new AccessoryListingRepository();


        //GET: /AL/SelectByModelOrSerialNumber/ (modelName)
        [HttpGet]
        public ActionResult SelectByModelOrSerialNumber()
        {
            var model = rpAL.GetSerialNumberEngineModelSpecViewModel();
            model.EngineModelViewModel.ModelSelectList = rpAL.GetModelSelectListItem();

            return View(model);
        }

        //POST: /AL/SelectByModelOrSerialNumber/ (modelID)
        [HttpPost]
        public ActionResult SelectByModelOrSerialNumber(int modelID)
        {

            var model = new SerialNumberEngineModelSpec();

            model.SpecViewModel = rpAL.FindSpecModelByEngineModel(modelID); ;
            model.SpecViewModel.SpecSelectList = rpAL.GetSpecSelectList(model.SpecViewModel);

            return PartialView("_GetSpecsFor", model);
        }

        //POST: /AL/GetSpecsFor/ (SpecID)
        [HttpPost]
        public ActionResult GetSpecsFor(int SpecID)
        {

            var model = rpAL.GetSpecModel();

            model.SelectSpecID = (int)SpecID;

            return PartialView("_SelectButton", model);

        }

        //POST: /AL/SearchWithSerialNumber/ (SerialNumber from Form Collection)
        [HttpPost]
        public ActionResult SearchWithSerialNumber(FormCollection fc)
        {
            String serialNumber = fc["SerialNumber"];
            var model = new SerialNumberEngineModelSpec();
            model.SpecViewModel = rpAL.GetSpecbySerialNumber(serialNumber);
            if (model.SpecViewModel.SpecCollection.Count == 0)
            {
                TempData["SerialNumberError"] = "Invalid Serial Number";
                return RedirectToAction("SelectByModelOrSerialNumber");
            }
            else
            {
                return RedirectToAction("AccessoryList", model.SpecViewModel.SpecCollection[0].SpecID);
            }
        }

        // GET: AL/AccessoryList
        public ActionResult AccessoryList(int? id = 2)
        {
            var model = rpAL.GetDescriptionListBySpecID((int)id);
            model.SpecViewModel = rpAL.GetSpecModel(id);
            model.PositionViewModel = rpAL.GetPositionModelBySpecID((int)id);
            model.StatusViewModel = rpAL.GetStatusModelBySpecID((int)id);

            return View(model);
        }

        // GET: AL/ChangeAccessoryList
        public ActionResult ChangeAccessoryList(int? id = 1)
        {

            var model = rpAL.GetSpecCategoryDescriptionViewModelBySpecID((int)id);
            int Pid = 0;

            foreach (var item in model.CategoryViewModel.CategoryCollection)
            {
                model.dict[item.CategoryName] = new List<SelectListItem>();
                model.dict[item.CategoryName] = rpAL.GetDescriptionDDLSelectList(model, Pid);
                Pid += 1;
            }
            model.DDLSelectIDs = model.CategoryDescriptionCollection.Select(o => o.DefaultValue).Distinct().ToList();
            return View(model);

        }

        // Post: AL/ChangeAccessoryList
        [HttpPost]
        public ActionResult ChangeAccessoryList(SpecCategoryDescriptionViewModel model)
        {

            model = rpAL.GetMatchingSpecList(model);



            return PartialView("_SpecList", model);
        }

       


        
    }
}