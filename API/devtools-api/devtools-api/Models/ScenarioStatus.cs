using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace devtools_api.Models
{
    public class ScenarioStatus
    {
        public string ScenarioName { get; set; }
        public string ModuleName { get; set; }
        public decimal TimeTakenInMinutes { get; set; }

    }
}