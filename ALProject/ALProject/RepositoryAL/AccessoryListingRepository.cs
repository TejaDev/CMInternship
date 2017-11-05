using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ALProject.Models;
using ALProject.ViewModels;
using ALProject.DataAccessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ALProject.RepositoryAL
{
    public class AccessoryListingRepository
    {
        public AccessoryListingRepository()
        {
            //ConnectionString = WebConfigurationManager.ConnectionStrings["ENTERCONNECTIONSTRINGNAME"].ConnectionString; ;
            //DAL = new daDescriptionListing();
        }

        //private string ConnectionString;
        //private daDescriptionListing DAL;


        #region "Get Methods"
        
        public SpecModel GetSpecbySerialNumber(string SerialNumber)
        {
            SpecModel model = new SpecModel();

            if (SerialNumber == "100085")
            {
                model.SpecCollection.Add(new SpecModel.tblSpec { SpecID = 1, ModelID = 1, SpecName = "I0550N27B" });
            }

            else if (SerialNumber == "100086")
            {
                model.SpecCollection.Add(new SpecModel.tblSpec { SpecID = 2, ModelID = 1, SpecName = "I0550N28B" });
            }
            else if (SerialNumber == "100087")
            {
                model.SpecCollection.Add(new SpecModel.tblSpec { SpecID = 3, ModelID = 2, SpecName = "I0220N28B" });
            }
            else if (SerialNumber == "100088")
            {
                model.SpecCollection.Add(new SpecModel.tblSpec { SpecID = 4, ModelID = 1, SpecName = "I0550N29B" });
            }

            return model;
        }

        public EngineModelModel GetEngineModel()
        {
            return GetEngineModel(null);
        }
        public EngineModelModel GetEngineModel(int? ModelID)
        {

            EngineModelModel model = new EngineModelModel();
            //will call data access layer to call SQL stored procedure to return Engine model with Engine Collection populated with all model id's and model names.
            //UNCOMMENT WHEN DAL SET UP

            //DataTable dtEngineModel = DAL.GetEngineModelModel(ConnectionString);

            //foreach (DataRow row in dtEngineModel.Rows)
            //{
            //    model.ModelCollection.Add(new EngineModelModel.tblEngineModel
            //    {
            //        ModelID = Convert.ToInt32(row["ModelID"]),
            //        ModelName = row["ModelName"].ToString()             
            //    });

            //COMMENT REGION WHEN DAL SET UP
            #region Engine Model unit test values
            model.ModelCollection.Add(new EngineModelModel.tblEngineModel { ModelName = "I0550N", ModelID = 1 });
            model.ModelCollection.Add(new EngineModelModel.tblEngineModel { ModelName = "I0220N", ModelID = 2 });
            #endregion
            model.ModelCollection.RemoveAll(item => (item.ModelID != ModelID && ModelID != null));
            return model;
        }

        public SpecModel GetSpecModel()
        {
            return GetSpecModel(null);
        }

        public SpecModel GetSpecModel(int? SpecID)
        {
            SpecModel model = new SpecModel();
            //UNCOMMENT WHEN DAL SET UP
            //DataTable dtSpec = DAL.GetSpecModel(ConnectionString);

            //foreach (DataRow row in dtSpec.Rows)
            //{
            //    model.SpecCollection.Add(new SpecModel.tblSpec
            //    {
            //        SpecID = Convert.ToInt32(row["SpecID"]),
            //        ModelID = Convert.ToInt32(row["ModelID"]),
            //        SpecName = row["SpecName"].ToString()
            //    });

            //COMMENT REGION WHEN DAL SET UP
            #region Spec unit test values
            model.SpecCollection.Add(new SpecModel.tblSpec { SpecID = 1, ModelID = 1, SpecName = "I0550N27B" });
            model.SpecCollection.Add(new SpecModel.tblSpec { SpecID = 2, ModelID = 1, SpecName = "I0550N28B" });
            model.SpecCollection.Add(new SpecModel.tblSpec { SpecID = 3, ModelID = 2, SpecName = "I0220N28B" });
            model.SpecCollection.Add(new SpecModel.tblSpec { SpecID = 4, ModelID = 1, SpecName = "I0550N29B" });
            #endregion
            model.SpecCollection.RemoveAll(item => (item.SpecID != SpecID && SpecID != null));
            return model;
        }

        public CategoryModel GetCategoryModel()
        {
            return GetCategoryModel(null);
        }
        public CategoryModel GetCategoryModel(int? CategoryID)
        {
            CategoryModel model = new CategoryModel();
            //UNCOMMENT WHEN DAL SET UP
            //DataTable dtCategory = DAL.GetCategoryModel(ConnectionString);

            //foreach (DataRow row in dtCategory.Rows)
            //{
            //    model.CategoryCollection.Add(new CategoryModel.tblCategory
            //    {
            //        CategoryID = Convert.ToInt32(row["CategoryID"]),
            //        CategoryName = row["CategoryName"].ToString()
            //    });

            //COMMENT OUT REGION WHEN DAL SET UP
            #region Category unit test values
            model.CategoryCollection.Add(new CategoryModel.tblCategory { CategoryID = 1, CategoryName = "Magneto" });
            model.CategoryCollection.Add(new CategoryModel.tblCategory { CategoryID = 2, CategoryName = "Alternator" });
            model.CategoryCollection.Add(new CategoryModel.tblCategory { CategoryID = 3, CategoryName = "Starter" });
            #endregion
            return model;
        }

        public DescriptionModel GetDescriptionModel()
        {
            return GetDescriptionModel(null);
        }

        public DescriptionModel GetDescriptionModel(int? DescriptionID)
        {
            DescriptionModel model = new DescriptionModel();
            //UNCOMMENT WHEN DAL SET UP
            //DataTable dtDescription = DAL.GetDescriptionModel(ConnectionString);

            //foreach (DataRow row in dtDescription.Rows)
            //{
            //    model.DescriptionCollection.Add(new DescriptionModel.tblDescription
            //    {
            //        DescriptionID = Convert.ToInt32(row["DescriptionID"]),
            //        DescriptionName = row["DescriptionName"].ToString()
            //    });

            //COMMENT OUT REGION WHEN DAL SET UP
            #region Description Unit test values
            model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 1, DescriptionName = "Magneto1" });
            model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 2, DescriptionName = "Magneto2" });
            model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 3, DescriptionName = "Magneto3" });
            model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 4, DescriptionName = "Alternator1" });
            model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 5, DescriptionName = "Alternator2" });
            model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 6, DescriptionName = "Alternator3" });
            model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 7, DescriptionName = "Starter1" });
            model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 8, DescriptionName = "Starter2" });
            model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 9, DescriptionName = "Starter3" });
            #endregion

            return model;
        }
    
        public StatusModel GetStatusModel()
        {
            StatusModel model = new StatusModel();
            //UNCOMMENT WHEN DAL SET UP
            //DataTable dtStatud = DAL.GetStatusModel(ConnectionString);

            //foreach (DataRow row in dtStatus.Rows)
            //{
            //    model.StatusCollection.Add(new StatusModel.tblStatus
            //    {
            //        StatusID = Convert.ToInt32(row["StatusID"]),
            //        StatusName = row["StatusName"].ToString()
            //    });

            //COMMENT OUT REGION WHEN DAL SET UP
            #region Status Unit test values
            model.StatusCollection.Add(new StatusModel.tblStatus { StatusID = 1, StatusName = "New" });
            model.StatusCollection.Add(new StatusModel.tblStatus { StatusID = 2, StatusName = "Rebuilt" });
            #endregion
            return model;

        }

        public PositionModel GetPositionModel()
        {
            PositionModel model = new PositionModel();
            //UNCOMMENT WHEN DAL SET UP
            //DataTable dtPosition = DAL.GetPositionModel(ConnectionString);

            //foreach (DataRow row in dtPosition.Rows)
            //{
            //    model.PositionCollection.Add(new PositionModel.tblPosition
            //    {
            //        PositionID = Convert.ToInt32(row["PositionID"]),
            //        PositionName = row["PositionName"].ToString()
            //    });

            //COMMENT OUT REGION WHEN DAL SET UP
            #region Position Unit test values
            model.PositionCollection.Add(new PositionModel.tblPosition { PositionID = 1, PositionName = "Single" });
            model.PositionCollection.Add(new PositionModel.tblPosition { PositionID = 2, PositionName = "Left" });
            #endregion
            return model;

        }

        public CategoryDescriptionModel GetCategoryDescriptionModel()
        {


            CategoryDescriptionModel model = new CategoryDescriptionModel();
            //UNCOMMENT WHEN DAL SET UP
            //DataTable dtSpecCategoryDescription = DAL.GetCategoryDescriptionModel(ConnectionString);

            //foreach (DataRow row in dtSpecCategory.Rows)
            //{
            //    model.CategoryDescriptionCollection.Add(new SpecCategoryModel.tblSpecCategory
            //{
            //    SpecCategoryID = Convert.ToInt32(row["CategoryDescriptionID"]),
            //    CategoryID = Convert.ToInt32(row["CategoryID"]),
            //    DescriptionID = Convert.ToInt32(row["DescriptionID"]),
            //});

            //COMMENT OUT REGION WHEN DAL SET UP
            #region CategoryDescription Unit test values
            model.CategoryDescriptionCollection.Add(new CategoryDescriptionModel.tblCategoryDescription { CategoryDescriptionID = 1, CategoryID = 1, DescriptionID = 1 });
            model.CategoryDescriptionCollection.Add(new CategoryDescriptionModel.tblCategoryDescription { CategoryDescriptionID = 2, CategoryID = 1, DescriptionID = 2 });
            model.CategoryDescriptionCollection.Add(new CategoryDescriptionModel.tblCategoryDescription { CategoryDescriptionID = 3, CategoryID = 1, DescriptionID = 3 });
            model.CategoryDescriptionCollection.Add(new CategoryDescriptionModel.tblCategoryDescription { CategoryDescriptionID = 4, CategoryID = 2, DescriptionID = 4 });
            model.CategoryDescriptionCollection.Add(new CategoryDescriptionModel.tblCategoryDescription { CategoryDescriptionID = 5, CategoryID = 2, DescriptionID = 5 });
            model.CategoryDescriptionCollection.Add(new CategoryDescriptionModel.tblCategoryDescription { CategoryDescriptionID = 6, CategoryID = 2, DescriptionID = 6 });
            model.CategoryDescriptionCollection.Add(new CategoryDescriptionModel.tblCategoryDescription { CategoryDescriptionID = 7, CategoryID = 3, DescriptionID = 7 });
            model.CategoryDescriptionCollection.Add(new CategoryDescriptionModel.tblCategoryDescription { CategoryDescriptionID = 8, CategoryID = 3, DescriptionID = 8 });
            model.CategoryDescriptionCollection.Add(new CategoryDescriptionModel.tblCategoryDescription { CategoryDescriptionID = 9, CategoryID = 3, DescriptionID = 9 });
            model.CategoryDescriptionCollection.Add(new CategoryDescriptionModel.tblCategoryDescription { CategoryDescriptionID = 10, CategoryID = 4, DescriptionID = 10 });
            #endregion

            return model;

        }

        public SpecCategoryDescriptionModel GetSpecCategoryDescriptionModel()
        {
            SpecCategoryDescriptionModel model = new SpecCategoryDescriptionModel();
            //UNCOMMENT WHEN DAL SET UP
            //DataTable dtSpecCategoryDescription = DAL.GetSpecCategoryDescriptionModel(ConnectionString);

            //foreach (DataRow row in dtSpecCategoryDescription.Rows)
            //{
            //    model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription
            //{
            //    SpecCategoryDescriptionID = Convert.ToInt32(row["SpecCategoryDescriptionID"]),
            //    SpecCategoryID = Convert.ToInt32(row["SpecCategoryID"]),
            //    DescriptionID = Convert.ToInt32(row["DescriptionID"]),
            //});

            //COMMENT OUT REGION WHEN DAL SET UP
            #region SpecCategoryDescription Unit test values
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 1, CategoryDescriptionID = 1, SpecID = 1 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 2, CategoryDescriptionID = 2, SpecID = 1 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 3, CategoryDescriptionID = 4, SpecID = 1 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 4, CategoryDescriptionID = 7, SpecID = 1 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 5, CategoryDescriptionID = 2, SpecID = 2 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 6, CategoryDescriptionID = 5, SpecID = 2 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 7, CategoryDescriptionID = 8, SpecID = 2 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 8, CategoryDescriptionID = 3, SpecID = 3 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 9, CategoryDescriptionID = 6, SpecID = 3 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 10, CategoryDescriptionID = 1, SpecID = 4 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 11, CategoryDescriptionID = 4, SpecID = 4 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 12, CategoryDescriptionID = 7, SpecID = 4 });
            model.SpecCategoryDescriptionCollection.Add(new SpecCategoryDescriptionModel.tblSpecCategoryDescription { SpecCategoryDescriptionID = 13, CategoryDescriptionID = 10, SpecID = 4 });
            #endregion

            return model;
        }

        #endregion

        #region "Get View Models"
        public SerialNumberEngineModelSpec GetSerialNumberEngineModelSpecViewModel()
        {
            SerialNumberEngineModelSpec model = new SerialNumberEngineModelSpec();
            //model.ESNViewModel.ESNCollection = GetSerialNumberModel().ESNCollection;
            model.SpecViewModel.SpecCollection = GetSpecModel().SpecCollection;
            model.EngineModelViewModel.ModelCollection = GetEngineModel().ModelCollection;

            return model;
        }

        #endregion

        public List<SelectListItem> GetModelSelectListItem()
        {
            return GetModelSelectListItem(null);
        }
        public List<SelectListItem> GetModelSelectListItem(string modelID)
        {
            EngineModelModel model = GetEngineModel();
            List<SelectListItem> ModelSelectList = new List<SelectListItem>();

            foreach (var item in model.ModelCollection)
            {

                ModelSelectList.Add(new SelectListItem()
                {
                    Text = item.ModelName,
                    Value = item.ModelID.ToString(),
                    //True(TT) if ModelName not null and values match
                    Selected = (modelID != null && item.ModelID.ToString() == modelID)
                    // Selected = false
                });

            }
            return ModelSelectList;
        }

        public List<SelectListItem> GetSpecSelectList(SpecModel model)
        {
            List<SelectListItem> SpecList = new List<SelectListItem>();

            foreach (var item in model.SpecCollection)
            {

                SpecList.Add(new SelectListItem()
                {
                    Text = item.SpecName,
                    Value = item.SpecID.ToString(),
                });
            }
            return SpecList;
        }

        public SpecModel FindSpecModelByEngineModel(int modelID)
        {
            SpecModel model = GetSpecModel();

            model.SpecCollection.RemoveAll(item => item.ModelID != modelID);

            return model;
        }

        #region all need get stored procedures
        public PositionModel GetPositionModelBySpecID(int id)
        {
            PositionModel model = new PositionModel();
            //Call stored procedure to get Position model based on SpecID
            if (id == 1)
            {
                model.PositionCollection.Add(new PositionModel.tblPosition { PositionID = 1, PositionName = "Single" });
            }

            else if (id == 2)
            {
                model.PositionCollection.Add(new PositionModel.tblPosition { PositionID = 1, PositionName = "Single" });
            }

            else if (id == 3)
            {
                model.PositionCollection.Add(new PositionModel.tblPosition { PositionID = 1, PositionName = "Right" });
                model.PositionCollection.Add(new PositionModel.tblPosition { PositionID = 1, PositionName = "Left" });
            }
            return model;
        }
        public StatusModel GetStatusModelBySpecID(int id)
        {
            StatusModel model = new StatusModel();
            //Call stored procedure to get Status model based on SpecID
            if (id == 1)
            {
                model.StatusCollection.Add(new StatusModel.tblStatus { StatusID = 1, StatusName = "New" });
            }

            else if (id == 2)
            {
                model.StatusCollection.Add(new StatusModel.tblStatus { StatusID = 1, StatusName = "Rebuilt" });
            }

            else if (id == 3)
            {
                model.StatusCollection.Add(new StatusModel.tblStatus { StatusID = 1, StatusName = "New" });
                model.StatusCollection.Add(new StatusModel.tblStatus { StatusID = 1, StatusName = "Rebuilt" });
            }
            return model;
        }
        public SpecCategoryDescriptionViewModel GetSpecCategoryDescriptionViewModelBySpecID(int id)
        {
            SpecCategoryDescriptionViewModel model = new SpecCategoryDescriptionViewModel();

            model.SpecViewModel = GetSpecModel(id);
            model = GetCategoryDescriptionListBySpecID(id, model);

            //populates the category model based on specID to get category names to display on view
            model.CategoryViewModel = GetCategoryModelBySpecID(id);

            //populates the description model based on specID to get description names to use to set default value in drop down list
            model.DescriptionViewModel = GetDescriptionModelBySpecID(id);

            //returns view model with category and description model populated specific to single spec and
            //categorydescription collection populated for the list of specs in model for drop down list

            return model;
        }
        public CategoryModel GetCategoryModelBySpecID(int id)
        {
            CategoryModel model = new CategoryModel();
            //Call stored procedure to get Category model based on SpecID
            if (id == 1)
            {
                model.CategoryCollection.Add(new CategoryModel.tblCategory { CategoryID = 1, CategoryName = "Magneto" });
                model.CategoryCollection.Add(new CategoryModel.tblCategory { CategoryID = 2, CategoryName = "Alternator" });
                model.CategoryCollection.Add(new CategoryModel.tblCategory { CategoryID = 3, CategoryName = "Starter" });

            }

            else if (id == 2)
            {
                model.CategoryCollection.Add(new CategoryModel.tblCategory { CategoryID = 1, CategoryName = "Magneto" });
                model.CategoryCollection.Add(new CategoryModel.tblCategory { CategoryID = 2, CategoryName = "Alternator" });
                model.CategoryCollection.Add(new CategoryModel.tblCategory { CategoryID = 3, CategoryName = "Starter" });
            }

            else if (id == 3)
            {
                model.CategoryCollection.Add(new CategoryModel.tblCategory { CategoryID = 2, CategoryName = "Alternator" });
                model.CategoryCollection.Add(new CategoryModel.tblCategory { CategoryID = 3, CategoryName = "Starter" });
            }
            return model;
        }
        public DescriptionModel GetDescriptionModelBySpecID(int id)
        {
            DescriptionModel model = new DescriptionModel();
            //Call stored procedure to get Description model based on SpecID
            if (id == 1)
            {
                model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 1, DescriptionName = "Magneto1" });
                model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 2, DescriptionName = "Magneto2" });
                model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 4, DescriptionName = "Alternator1" });
                model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 7, DescriptionName = "Starter1" });
            }

            else if (id == 2)
            {
                model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 2, DescriptionName = "Magneto2" });
                model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 5, DescriptionName = "Alternator2" });
                model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 8, DescriptionName = "Starter2" });
            }

            else if (id == 3)
            {
                model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 6, DescriptionName = "Alternator3" });
                model.DescriptionCollection.Add(new DescriptionModel.tblDescription { DescriptionID = 9, DescriptionName = "Starter3" });
            }
            return model;
        }

        public SpecCategoryDescriptionViewModel GetDescriptionListBySpecID(int id)
        {
            var model = new SpecCategoryDescriptionViewModel();
            //returns spec model with single spec in collection to use to get the modelID(FK) of the spec
            //model.SpecViewModel = GetSpecModel(id);

            if (id == 1)
            {
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 1, CategoryName = "Magneto", DescriptionName = "Magneto1", DescriptionID = 1, DefaultValue = 1 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 1, CategoryName = "Magneto", DescriptionName = "Magneto2", DescriptionID = 2, DefaultValue = 1 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 2, CategoryName = "Alternator", DescriptionName = "Alternator1", DescriptionID = 4, DefaultValue = 4 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 3, CategoryName = "Starter", DescriptionName = "Starter1", DescriptionID = 7, DefaultValue = 7 });

            }

            else if (id == 2)
            {
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 1, CategoryName = "Magneto", DescriptionName = "Magneto2", DescriptionID = 2, DefaultValue = 2 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 2, CategoryName = "Alternator", DescriptionName = "Alternator2", DescriptionID = 5, DefaultValue = 5 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 3, CategoryName = "Starter", DescriptionName = "Starter2", DescriptionID = 8, DefaultValue = 8 });
            }

            else if (id == 3)
            {
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 2, CategoryName = "Alternator", DescriptionName = "Alternator3", DescriptionID = 6, DefaultValue = 6 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 3, CategoryName = "Starter", DescriptionName = "Starter3", DescriptionID = 9, DefaultValue = 9 });
            }


            return model;
        }
        public SpecCategoryDescriptionViewModel GetCategoryDescriptionListBySpecID(int id, SpecCategoryDescriptionViewModel model)
        {

            //returns spec model with single spec in collection to use to get the modelID(FK) of the spec
            //model.SpecViewModel = GetSpecModel(id);

            if (id == 1 || id == 4)
            {
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 1, CategoryName = "Magneto", DescriptionName = "Magneto1", DescriptionID = 1, DefaultValue = 1 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 1, CategoryName = "Magneto", DescriptionName = "Magneto2", DescriptionID = 2, DefaultValue = 1 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 2, CategoryName = "Alternator", DescriptionName = "Alternator1", DescriptionID = 4, DefaultValue = 4 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 2, CategoryName = "Alternator", DescriptionName = "Alternator2", DescriptionID = 5, DefaultValue = 4 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 3, CategoryName = "Starter", DescriptionName = "Starter1", DescriptionID = 7, DefaultValue = 7 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 3, CategoryName = "Starter", DescriptionName = "Starter2", DescriptionID = 8, DefaultValue = 7 });
            }

            else if (id == 2)
            {
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 1, CategoryName = "Magneto", DescriptionName = "Magneto1", DescriptionID = 1, DefaultValue = 2 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 1, CategoryName = "Magneto", DescriptionName = "Magneto2", DescriptionID = 2, DefaultValue = 2 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 2, CategoryName = "Alternator", DescriptionName = "Alternator1", DescriptionID = 4, DefaultValue = 5 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 2, CategoryName = "Alternator", DescriptionName = "Alternator2", DescriptionID = 5, DefaultValue = 5 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 3, CategoryName = "Starter", DescriptionName = "Starter1", DescriptionID = 7, DefaultValue = 8 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 3, CategoryName = "Starter", DescriptionName = "Starter2", DescriptionID = 8, DefaultValue = 8 });
            }

            else if (id == 3)
            {
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 2, CategoryName = "Alternator", DescriptionName = "Alternator3", DescriptionID = 6, DefaultValue = 6 });
                model.CategoryDescriptionCollection.Add(new SpecCategoryDescriptionViewModel.tblCategoryDescription { CategoryID = 3, CategoryName = "Starter", DescriptionName = "Starter3", DescriptionID = 9, DefaultValue = 9 });
            }


            return model;
        }
        #endregion
        public List<SelectListItem> GetDescriptionDDLSelectList(SpecCategoryDescriptionViewModel model, int Pid)
        {
            List<SelectListItem> DescriptionList = new List<SelectListItem>();


            foreach (var item in model.CategoryDescriptionCollection)
            {
                //populates drop down list by only adding rows from the CategoryDescriptionCollection that match
                // the value in the CategoryCollection
                if (item.CategoryID == model.CategoryViewModel.CategoryCollection[Pid].CategoryID)
                {
                    DescriptionList.Add(new SelectListItem()
                    {
                        Text = item.DescriptionName,
                        Value = item.DescriptionID.ToString(),
                        //True(TT) if DescriptionID from CategoryDescriptionCollection matches DescriptionCollection
                        Selected = (item.DescriptionID == item.DefaultValue)
                    });
                }
            }
            return DescriptionList;
        }

        public SpecCategoryDescriptionViewModel GetMatchingSpecList(SpecCategoryDescriptionViewModel model)
        {
            model.SpecViewModel.SpecCollection.Clear();
            //test value, would need to call stored procedure to get matching spec list
            if (model.DDLSelectIDs.Contains(1) && model.DDLSelectIDs.Contains(4) && model.DDLSelectIDs.Contains(7))
            {
                model.SpecViewModel.SpecCollection.Add(new SpecModel.tblSpec { SpecID = 1, ModelID = 1, SpecName = "I0550N27B" });
            }
            if (model.DDLSelectIDs.Contains(2) && model.DDLSelectIDs.Contains(5) && model.DDLSelectIDs.Contains(8))
            {
                model.SpecViewModel.SpecCollection.Add(new SpecModel.tblSpec { SpecID = 1, ModelID = 1, SpecName = "I0550N28B" });
            }
            return model;
        }

    }
}



