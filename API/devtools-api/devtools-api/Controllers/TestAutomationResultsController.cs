using devtools_api.Services;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace devtools_api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class TestAutomationResultsController : ApiController
    {
        [HttpGet]
        [ActionName("TestAutomationResults")]
        public HttpResponseMessage GetTestAutomationResults(string runname,string url,int datasetcount)
        {
            try
            {
                DbService db = new DbService();
                var queryResult = db.getRegressionTestStatus(runname, url, datasetcount);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(queryResult));
                return result;
            }
            catch (Exception ex)
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.BadRequest);
                result.Content = new StringContent(ex.StackTrace);
                return result;

            }

           
        }

        [HttpGet]
        [ActionName("ScenarioStatus")]
        public HttpResponseMessage GetScenarioStatus(string runname)
        {
            try
            {
                DbService db = new DbService();
                var queryResult = db.getScenarioStatus(runname);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(queryResult))
                };
                return result;
            }
            catch (Exception ex)
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.BadRequest);
                result.Content = new StringContent(ex.StackTrace);
                return result;

            }


        }

        [HttpGet]
        [ActionName("RegressionReport")]
        public HttpResponseMessage GetRegressionReport(string runname)
        {
            try
            {
                DbService db = new DbService();
                var queryResult = db.getRegressionReport(runname);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(queryResult);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = runname + "_Report.xls";
                return result;
            }
            catch (Exception ex)
            {
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.BadRequest);
                result.Content = new StringContent(ex.StackTrace);
                return result;

            }


        }


    }
}
