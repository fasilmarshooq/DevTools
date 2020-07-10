using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace devtools_api.Models
{
    public class RegressionReport
    {
        public int ScenarioHeaderId { get; set; }
        public string ScenarioName { get; set; }
        public string ModuleName { get; set; }
        public string ScenarioRunStatus { get; set; }
        public string LogType { get; set; }
        public string Log { get; set; }



    }
}