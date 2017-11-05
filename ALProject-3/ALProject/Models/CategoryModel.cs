using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ALProject.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            CategoryCollection = new List<tblCategory>();

        }

        public List<tblCategory> CategoryCollection { get; set; }

        public class tblCategory
        {
            [Display(Name = "Category")]
            public string CategoryName { get; set; }
            public Int32 CategoryID { get; set; }
        }
    }
}