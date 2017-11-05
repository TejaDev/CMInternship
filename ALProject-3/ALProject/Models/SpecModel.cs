using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ALProject.Models
{
    public class SpecModel
    {
        public SpecModel()
        {
            SpecCollection = new List<tblSpec>();
            SpecSelectList = new List<SelectListItem>();
            SelectSpecID = new Int32();

            ModelSelectList = new List<SelectListItem>();

        }

        public List<tblSpec> SpecCollection { get; set; }
        public List<SelectListItem> SpecSelectList { get; set; }
        public Int32 SelectSpecID { get; set; }
        public string SelectedCondition { get; set; }
        public string SelectedPosition { get; set; }
        public List<SelectListItem> ModelSelectList { get; set; }
        public class tblSpec
        {
            public Int32 SpecID { get; set; }
            public Int32 ModelID { get; set; }
            public string SpecName { get; set; }
 
        }

    }
}