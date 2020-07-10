using System.Collections.Generic;
using System.Xml;
using System;

namespace devtools_api.Services
{
    public class QueryHelperService
    {
        public static readonly Dictionary<string, string> QueryDictionary = new Dictionary<string, string>();

        public QueryHelperService()
        {

            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "queries.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (!QueryDictionary.ContainsKey(node.Attributes[0].Value))
                {
                    QueryDictionary.Add(node.Attributes[0].Value, node.InnerText);
                }
            }
        }

     
    }

}
