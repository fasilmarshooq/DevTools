using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace devtools_api.Services
{
    public static class PapReturnService
    {
        public static byte[] getPapReturn(byte[] papUpdateFile)
        {
            var papupdateFileString = Encoding.ASCII.GetString(papUpdateFile);

            List<string> papupdateFileStringWithLineBreaks = new List<string>(
                          papupdateFileString.Split(new string[] { "\r\n" },
                          StringSplitOptions.RemoveEmptyEntries));

            var GenreatedPAPReturnFile = GenerateReturnFile(papupdateFileStringWithLineBreaks);

            return Encoding.ASCII.GetBytes(GenreatedPAPReturnFile);
        }

        public static string GenerateReturnFile(List<string> _updateFileContent)
        {
            StringBuilder ReturnFile = new StringBuilder();

            ReturnFile.Append(PapReturnHeaderGenerationService.GetPAPReturnHeader(_updateFileContent));
            ReturnFile.Append(PapReturnEntryDetailGenerationService.GetPapReturnEntryDetailRecords(_updateFileContent));
            ReturnFile.Append(PapReturnAccountTrailerGenerationService.GetPapReturnAccountTrailer(_updateFileContent));

            return ReturnFile.ToString();
        }
    }
}