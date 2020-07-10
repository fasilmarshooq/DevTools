using devtools_api.Models;
using devtools_api.Services;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace devtools_api.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class FileUtilController : ApiController
    {
        [HttpPost]
        [ActionName("EncryptFile")]
        public HttpResponseMessage PostFileForEncryption()
        {
            HttpResponseMessage result = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                try
                {
                    var EncryptedContent = CryptoService.Encrypt(GetByteArray(httpRequest));
                    var filecontent = new FileContent() { FileName = httpRequest.Files[0].FileName, Content = EncryptedContent };
                    result.StatusCode = HttpStatusCode.OK;
                    result.Content = new StringContent(JsonConvert.SerializeObject(filecontent));

                }
                catch (Exception ex)
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest, "something went wrong During Encryption :" + ex.Message);
                }

            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "No files to process!!");
            }
            return result;
        }


        [HttpPost]
        [ActionName("DecryptFile")]
        public HttpResponseMessage PostFileForDecryption()
        {

            HttpResponseMessage result = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                try
                {
                    var EncryptedContent = CryptoService.Decrypt(GetByteArray(httpRequest));
                    var filecontent = new FileContent() { FileName = httpRequest.Files[0].FileName, Content = EncryptedContent };
                    result.StatusCode = HttpStatusCode.OK;
                    result.Content = new StringContent(JsonConvert.SerializeObject(filecontent));

                }
                catch (Exception ex)
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid File for decryption : " + ex.Message);
                }

            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "No files to process!!");
            }
            return result;
        }

        [HttpPost]
        [ActionName("GeneratePapReturn")]
        public HttpResponseMessage PostFileForPapReturnGeneration()
        {

            HttpResponseMessage result = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                try
                {

                    var ProcessedFile = PapReturnService.getPapReturn(GetByteArray(httpRequest));

                    var filecontent = new FileContent() { FileName = httpRequest.Files[0].FileName, Content = ProcessedFile };
                    result.StatusCode = HttpStatusCode.OK;
                    result.Content = new StringContent(JsonConvert.SerializeObject(filecontent));

                }
                catch (Exception ex)
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest, "Something went wrong : " + ex.Message);
                }

            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "No files to process!!");
            }
            return result;
        }

        private static byte[] GetByteArray(HttpRequest httpRequest)
        {
            MemoryStream ms = new MemoryStream();
            httpRequest.Files[0].InputStream.CopyTo(ms);
            byte[] fileData = ms.ToArray();
            return fileData;
        }
    }
}
