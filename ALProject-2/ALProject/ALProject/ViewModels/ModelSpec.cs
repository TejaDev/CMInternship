using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ALProject.Models;

namespace ALProject.ViewModels
{
    public class ModelSpec
    {


        public ModelSpec()
        {

            EngineViewModel = new EngineModelModel();
            SpecViewModel = new SpecModel();
        }


        public EngineModelModel EngineViewModel { get; set; }
        public SpecModel SpecViewModel { get; set; }


    }
}