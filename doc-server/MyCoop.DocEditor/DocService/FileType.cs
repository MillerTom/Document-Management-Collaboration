using System.Collections.Generic;
using System.IO;

namespace DocService
{
    internal static class FileType
    {
        public static readonly List<string> ExtsSpreadsheet = new List<string>
            {
                ".xls", ".xlsx",
                ".ods", ".csv"
            };

        public static readonly List<string> ExtsPresentation = new List<string>
            {
                ".pps", ".ppsx",
                ".ppt", ".pptx",
                ".odp"
            };

        public static readonly List<string> ExtsDocument = new List<string>
            {
                ".docx", ".doc", ".odt", ".rtf", ".txt",
                ".html", ".htm", ".mht", ".pdf", ".djvu",
                ".fb2", ".epub", ".xps"
            };

        public static string GetInternalExtension(string extension)
        {
            extension = Path.GetExtension(extension).ToLower();
            if (ExtsDocument.Contains(extension)) return ".docx";
            if (ExtsSpreadsheet.Contains(extension)) return ".xlsx";
            if (ExtsPresentation.Contains(extension)) return ".pptx";
            return string.Empty;
        }
    }
}