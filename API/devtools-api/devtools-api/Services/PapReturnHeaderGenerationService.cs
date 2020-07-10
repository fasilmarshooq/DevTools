using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace devtools_api.Services
{
    public static class PapReturnHeaderGenerationService
    {
        public static string GetPAPReturnHeader(List<string> inputFileData)
        {
            var clientNumber = inputFileData[1].Substring(13, 10);
            var fileCreationDate = inputFileData[1].Substring(23, 5);

            StringBuilder ReturnHeader = new StringBuilder();
            ReturnHeader.Append("0");
            ReturnHeader.Append("000");
            ReturnHeader.Append(clientNumber);
            ReturnHeader.Append("0");
            ReturnHeader.Append("010");
            ReturnHeader.Append(fileCreationDate);
            ReturnHeader.Append("  ");
            ReturnHeader.Append(DateTime.Now.ToString("MMddyyyy"));
            ReturnHeader.Append(clientNumber);
            ReturnHeader.Append("03");
            ReturnHeader.Append("                                                                                                                                                 ");
            ReturnHeader.AppendLine();
            return ReturnHeader.ToString();
        }
    }
}