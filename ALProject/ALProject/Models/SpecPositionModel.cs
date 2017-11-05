using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ALProject.Models
{
    public class SpecPositionModel
    {

            public SpecPositionModel()
            {
                SpecPositionCollection = new List<tblSpecPosition>();
            }

            public List<tblSpecPosition> SpecPositionCollection { get; set; }

            public class tblSpecPosition
            {
                public Int32 SpecPositionID { get; set; }
                public Int32 SpecID { get; set; }

                public Int32 PositionID { get; set; }
            }
  

    }
}