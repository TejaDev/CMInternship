using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ALProject.Models;
using System.Web.Mvc;

namespace ALProject.ViewModels
{
    public class SpecCategoryDescriptionViewModel
    {
        public CategoryModel CategoryViewModel { get; set; }
        public DescriptionModel DescriptionViewModel { get; set; }
        public SpecModel SpecViewModel { get; set; }

        public PositionModel PositionViewModel { get; set; }
        public StatusModel StatusViewModel { get; set; }
        public List<tblCategoryDescription> CategoryDescriptionCollection { get; set; }
        public Dictionary<string, List<SelectListItem>> dict { get; set; }
        public List<int> DDLSelectIDs { get; set; }

        public SpecCategoryDescriptionViewModel()
        {
            CategoryViewModel = new CategoryModel();
            DescriptionViewModel = new DescriptionModel();
            SpecViewModel = new SpecModel();
            PositionViewModel = new PositionModel();
            StatusViewModel = new StatusModel();

            CategoryDescriptionCollection = new List<tblCategoryDescription>();
            DDLSelectIDs = new List<int>();

            dict = new Dictionary<string, List<SelectListItem>>();

        }
        public class tblCategoryDescription
        {
            public string CategoryName { get; set; }
            public Int32 CategoryID { get; set; }
            public string DescriptionName { get; set; }
            public Int32 DescriptionID { get; set; }
            public Int32 DefaultValue { get; set; }
        }

        public class DDLListSelectedIDs
        {
            public string SelectedIDName { get; set;}

            public Int32 SelectedID { get; set; }
        }
      

    }
}