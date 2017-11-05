using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALProject.Models
{
    public class CategoryDescriptionModel
    {
        public CategoryDescriptionModel()
        {
            CategoryDescriptionCollection = new List<tblCategoryDescription>();
        }

    public List<tblCategoryDescription> CategoryDescriptionCollection { get; set; }

    public class tblCategoryDescription
        {
        public Int32 CategoryDescriptionID { get; set; }

        public Int32 CategoryID { get; set; }

        public Int32 DescriptionID { get; set; }
    }

}
}