using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace devtools_api.Services
{
    public class ExcelService 
    {
       
        public string WriteTsv<T>(JArray data)
        {
            if (data.Count == 0)
            {
                return "";
            }
            JToken inner = data[0];
            JToken dataValue = data;
            StringBuilder output = new StringBuilder();
            foreach (var item in inner)
            {
                string header = ((JProperty)item).Name;
                output.Append(header);
                output.Append("\t");
            }
            output.AppendLine();
            foreach (var token in data)
            {
                foreach (var item in token)
                {
                    var rowValue = ((JValue)((JProperty)item).Value).Value;
                    output.Append(rowValue);
                    output.Append("\t");
                }
                output.AppendLine();
            }
            return output.ToString();
        }
    }
}