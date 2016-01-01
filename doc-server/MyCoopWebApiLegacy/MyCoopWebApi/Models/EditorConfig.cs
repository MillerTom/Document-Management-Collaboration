using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCoopWebApi.Models
{
    public class EditorConfig
    {
        public string type { get; set; }
        public string documentType { get; set; }
        public string fileName { get; set; }
        public string fileUri { get; set; }
        public string key { get; set; }
        public string validateKey { get; set; }
        public bool isEditable { get; set; }
    }
}