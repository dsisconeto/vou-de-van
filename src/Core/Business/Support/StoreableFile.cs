using System;
using System.Collections.Generic;
using System.Text;

namespace VouDeVan.Core.Business.Support
{
    public abstract class StoreableFile
    {
        public abstract string Path { get; }

        public string FileName { get; set; }

        public string Extension { get; set; }

        public string ContentType { get; set; }

        public string Uri { get; set; }
    }
}