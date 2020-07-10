using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace devtools_api.Services
{
    public static class PapReturnEntryDetailGenerationService
    {
        public static string GetPapReturnEntryDetailRecords(List<string> inputFileData)
        {
            var entryDetailRecordsInUpdateFile = inputFileData.Where(x => x.Substring(0, 1) == "6").ToList();

            StringBuilder EntryDetails = new StringBuilder();

            foreach (var entryDetail in entryDetailRecordsInUpdateFile)
            {
                EntryDetails.Append("1");
                EntryDetails.Append("000");
                EntryDetails.Append(entryDetail.Substring(13, 10));
                EntryDetails.Append("0");
                EntryDetails.Append("010");
                EntryDetails.Append("0");
                EntryDetails.Append(inputFileData[1].Substring(29, 4));
                EntryDetails.Append("  ");
                EntryDetails.Append("D");
                EntryDetails.Append("0");
                EntryDetails.Append("           ");
                EntryDetails.Append("CustomerNumber     ");
                EntryDetails.Append("      ");
                EntryDetails.Append(entryDetail.Substring(54, 22));
                EntryDetails.Append("        ");
                EntryDetails.Append("19000000");
                EntryDetails.Append("00");
                EntryDetails.Append("99");
                EntryDetails.Append("     ");
                EntryDetails.Append(entryDetail.Substring(3, 4));
                EntryDetails.Append(entryDetail.Substring(7, 5));
                EntryDetails.Append(entryDetail.Substring(12, 17));
                EntryDetails.Append(" ");
                EntryDetails.Append("CAD");
                EntryDetails.Append("CAN");
                EntryDetails.Append("0000");
                EntryDetails.Append(entryDetail.Substring(29, 10)); //amount
                EntryDetails.Append("00000000");
                EntryDetails.Append(entryDetail.Substring(79, 15)); //ach tracenumber
                EntryDetails.Append("U");
                EntryDetails.Append("905");
                EntryDetails.Append("      ");
                EntryDetails.AppendLine();

            }


            return EntryDetails.ToString();
        }
    }
}