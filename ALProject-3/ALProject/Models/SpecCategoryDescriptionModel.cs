using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALProject.Models
{
    public class SpecCategoryDescriptionModel
    {
        public SpecCategoryDescriptionModel()
        {
            SpecCategoryDescriptionCollection = new List<tblSpecCategoryDescription>();

        }

        public List<tblSpecCategoryDescription> SpecCategoryDescriptionCollection { get; set; }

        public class tblSpecCategoryDescription
        {
            public Int32 SpecCategoryDescriptionID { get; set; }

            public Int32 CategoryDescriptionID { get; set; }

            public Int32 SpecID { get; set; }
        }
    }
}
