using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ALProject.Models
{
    public class SpecStatusModel
    {
            public SpecStatusModel()
            {
                SpecStatusCollection = new List<tblSpecStatus>();
            }

            public List<tblSpecStatus> SpecStatusCollection { get; set; }

            public class tblSpecStatus
            {
                public Int32 SpecStatusID { get; set; }
                public Int32 SpecID { get; set; }

                public Int32 StatusID { get; set; }
            }
        

    }
}