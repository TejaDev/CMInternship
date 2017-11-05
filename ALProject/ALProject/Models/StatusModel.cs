using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ALProject.Models
{
    public class StatusModel
    {
        public StatusModel()
        {
            StatusCollection = new List<tblStatus>();

        }

        public List<tblStatus> StatusCollection { get; set; }

        public class tblStatus
        {
            [Display(Name = "Status")]
            public string StatusName { get; set; }
            public Int32 StatusID { get; set; }
        }

    }
}