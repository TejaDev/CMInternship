using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALProject.Models
{
    public class EngineModelModel
    {
        public EngineModelModel()
        {
            ModelCollection = new List<tblEngineModel>();
            ModelSelectList = new List<SelectListItem>();
        }

        public List<tblEngineModel> ModelCollection { get; set; }
        public List<SelectListItem> ModelSelectList { get; set; }
        public String SelectedModel { get; set; }
        public int SelectModelID { get; set; }
        public class tblEngineModel
        {
            public int ModelID { get; set; }
            public string ModelName { get; set; }

        }
    }
}