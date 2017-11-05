using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ALProject.Models
{
    public class DescriptionModel
    {
        public DescriptionModel()
        {
            DescriptionCollection = new List<tblDescription>();

            DescriptionSelectList = new List<SelectListItem>();
            SelectDescriptionID = new Int32();

        }

        public List<tblDescription> DescriptionCollection { get; set; }


        public List<SelectListItem> DescriptionSelectList { get; set; }
        public Int32 SelectDescriptionID { get; set; }

        public class tblDescription
        {
            public Int32 DescriptionID { get; set; }

            [Display(Name = "Description")]
            public string DescriptionName { get; set; }
        }

    }
}
