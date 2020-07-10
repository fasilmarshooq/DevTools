using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace devtools_api.Services
{
    public static class PapReturnAccountTrailerGenerationService
    {
        public static string GetPapReturnAccountTrailer(List<string> inputFileData)
        {
            StringBuilder AccountTrailer = new StringBuilder();
            var TotalDebitRecords = inputFileData.Where(x => x.Substring(0, 1) == "6").Count().ToString();

            AccountTrailer.Append("3");
            AccountTrailer.Append("000");
            AccountTrailer.Append(inputFileData[1].Substring(13, 10));
            AccountTrailer.Append("0");
            AccountTrailer.Append("0100");
            AccountTrailer.Append(inputFileData[1].Substring(29, 4));
            AccountTrailer.Append("  ");
            AccountTrailer.Append("0000000000000000000000000000000000000000000000000000");
            AccountTrailer.Append("   ");
            AccountTrailer.Append("00000000");
            AccountTrailer.Append("000000000000000000");
            AccountTrailer.Append("00000000000000000000000000");
            AccountTrailer.Append(TotalDebitRecords.PadLeft(8, '0'));
            AccountTrailer.Append(TotalDebitRecords.PadLeft(18, '0'));
            AccountTrailer.Append("  ");
            AccountTrailer.Append("0999");
            AccountTrailer.Append("99999");
            AccountTrailer.Append("000000000000");
            AccountTrailer.Append("         ");
            AccountTrailer.AppendLine();

            return AccountTrailer.ToString();
        }
    }
}