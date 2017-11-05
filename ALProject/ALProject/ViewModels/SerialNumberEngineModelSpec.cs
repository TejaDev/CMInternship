using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ALProject.Models;

namespace ALProject.ViewModels
{
    public class SerialNumberEngineModelSpec
    {
        public SerialNumberModel SerialNumberViewModel { get; set; }
        public SpecModel SpecViewModel { get; set; }
        public EngineModelModel EngineModelViewModel { get; set; }
        

        public SerialNumberEngineModelSpec()
        {
            EngineModelViewModel = new EngineModelModel();
            SpecViewModel = new SpecModel();
            SerialNumberViewModel = new SerialNumberModel();
        }
    }
}