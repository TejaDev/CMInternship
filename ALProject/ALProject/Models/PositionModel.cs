using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ALProject.Models
{
    public class PositionModel
    {
        public PositionModel()
        {
            PositionCollection = new List<tblPosition>();

        }

        public List<tblPosition> PositionCollection { get; set; }

        public class tblPosition
        {
            [Display(Name = "Position")]
            public string PositionName { get; set; }
            public Int32 PositionID { get; set; }
        }

    }
}