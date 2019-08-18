using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Storage
{
    public class StorageFile : Storage
    {
        private readonly string _folder;
        private readonly string _pathRoot;
        private readonly string _url;

        public StorageFile(string folder, string pathRoot, string url)
        {
            _folder = folder;
            _pathRoot = pathRoot;
            _url = url;
        }


        protected override async Task<string> CopyFileTo(string directory, string fileName, IFormFile file)
        {


            var absolutePathDirectory = Path.Combine(_pathRoot, _folder, directory);


            MakeDirectory(absolutePathDirectory);

            var path = Path.Combine(absolutePathDirectory, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"{_url}/{_folder}/{directory}/{fileName}";
        }


        protected void MakeDirectory(string path)
        {
            if (Directory.Exists(path))
            {
             return;
            }

            Directory.CreateDirectory(path);

        }
    }
}