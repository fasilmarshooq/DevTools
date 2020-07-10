using System.Configuration;
using System.Data.SqlClient;
using devtools_api.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace devtools_api.Services
{
    public class DbService
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["AutomationRepository"]?.ConnectionString;
        private ExcelService _excelService = new ExcelService();

        public RegressionTestStatus getRegressionTestStatus(string runname, string url, int datasetcount)
        {

            var testStatus = new RegressionTestStatus();

            string[] queryParams = new string[] { datasetcount.ToString(), runname, url };
            string query = QueryHelperService.QueryDictionary["GetRegressionStatus"] ;

            var parsedQuery = string.Format(query, queryParams);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(parsedQuery, conn))
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                testStatus.Labels.Add(reader.GetString(0));
                                testStatus.PassedCounts.Add(reader.GetInt32(1));
                                testStatus.FailedCounts.Add(reader.GetInt32(2));
                                testStatus.TimeTaken.Add(reader.GetDecimal(3));
                            }
                            reader.NextResult();
                        }
                    }

                }
            }

            testStatus.AverageTimeTaken = Math.Round(testStatus.TimeTaken.Average(), 2);
            testStatus.TimeTakenForLastExecution = testStatus.TimeTaken.FirstOrDefault();
            testStatus.AverageFailures = (decimal)Math.Round(testStatus.FailedCounts.Average(), 2);

            return testStatus;
        }

        public List<ScenarioStatus> getScenarioStatus(string runName)
        {

            List<ScenarioStatus> scenarioStatuses = new List<ScenarioStatus>();
           

            string[] queryParams = new string[] { runName };
            string query = QueryHelperService.QueryDictionary["GetScenarioStatus"];

            var parsedQuery = string.Format(query, queryParams);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(parsedQuery, conn))
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.HasRows)
                        {
                           
                            while (reader.Read())
                            {
                                var scenarioStatus = new ScenarioStatus();
                                scenarioStatus.ScenarioName = reader.GetString(0); 
                                scenarioStatus.ModuleName = reader.GetString(1); 
                                scenarioStatus.TimeTakenInMinutes = reader.GetDecimal(2); 
                                 scenarioStatuses.Add(scenarioStatus);
                            }
                            reader.NextResult();
                           
                        }
                    }

                }
            }


            return scenarioStatuses;

        }

        public string getRegressionReport(string runName)
        {

            List<RegressionReport> RegressionReports = new List<RegressionReport>();


            string[] queryParams = new string[] { runName };
            string query = QueryHelperService.QueryDictionary["GetRegressionReport"];

            var parsedQuery = string.Format(query, queryParams);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(parsedQuery, conn))
                {
                    conn.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                var regressionReport = new RegressionReport();
                                regressionReport.ScenarioHeaderId = reader.GetInt32(0);
                                regressionReport.ScenarioName = reader.GetString(1);
                                regressionReport.ModuleName = reader.GetString(2);
                                regressionReport.ScenarioRunStatus = reader.GetString(3);
                                regressionReport.LogType = reader.GetString(4);
                                regressionReport.Log = reader.GetString(5).Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
                                RegressionReports.Add(regressionReport);
                            }
                            reader.NextResult();

                        }
                    }

                }
            }
            string jsonstring = JsonConvert.SerializeObject(RegressionReports);
            JArray json = JArray.Parse(jsonstring);
            jsonstring = _excelService.WriteTsv<JArray>(json);


            return jsonstring;

        }

    }
}