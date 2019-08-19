using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Storage
{
    public class StorageFile : Storage, IStorage
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
            var absolutePathDirectory = MakeAbsolutePath(directory);

            MakeDirectory(absolutePathDirectory);

            var path = Path.Combine(absolutePathDirectory, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"{_url}/{_folder}/{directory}/{fileName}";
        }

        public async Task Destroy(Storable storable)
        {
           await Task.Run(() =>
            {
                var absolutePath = MakeAbsolutePath(storable.DirectoryWithFileName);

                if (File.Exists(absolutePath))
                {
                    File.Delete(absolutePath);
                }
            });
        }

        private static void MakeDirectory(string path)
        { 
            if (Directory.Exists(path))
            {
                return;
            }

            Directory.CreateDirectory(path);
        }

        private string MakeAbsolutePath(string directory)
        {
            return Path.Combine(_pathRoot, _folder, directory);
        }
    }
}