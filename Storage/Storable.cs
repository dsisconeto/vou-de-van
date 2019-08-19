using System.IO;

namespace Storage
{
    public abstract class Storable
    {
        public string FileName { get; set; }

        public string Extension { get; set; }

        public string ContentType { get; set; }

        public string Uri { get; set; }

        public virtual string Directory { get; set; }

        public string DirectoryWithFileName => Path.Combine(Directory, FileName);
    }
}