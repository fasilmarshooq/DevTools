using System.Collections.Generic;


namespace devtools_api.Models
{
    public class RegressionTestStatus
    {
        public List<string> Labels { get; set; } = new List<string>();
        public List<int> PassedCounts { get; set; } = new List<int>();
        public List<int> FailedCounts { get; set; } = new List<int>();
        public List<decimal> TimeTaken { get; set; } = new List<decimal>();

        public decimal AverageTimeTaken { get; set; }
        public decimal TimeTakenForLastExecution { get; set; }
        public decimal AverageFailures { get; set; }

    }
}