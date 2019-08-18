namespace Storage
{
    public abstract class File
    {
        public string FileName { get; set; }

        public string Extension { get; set; }

        public string ContentType { get; set; }

        public string Uri { get; set; }

        public virtual string Path { get; set; }
    }
}