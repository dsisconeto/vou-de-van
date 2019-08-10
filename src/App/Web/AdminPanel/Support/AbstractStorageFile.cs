using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.App.Web.AdminPainel.Support
{
    public abstract class AbstractStorageFile
    {
        protected readonly string _folder;

        protected AbstractStorageFile(string folder)
        {
            _folder = folder;
        }

        protected abstract Task CopyFileTo(string path, IFormFile file);

        protected abstract void MakeDirectory(string path);

        public async Task<T> Store<T>(IFormFile file) where T : StoreableFile, new()
        {
            var storableFile = new T();
            var path = MakePath(storableFile.Path);
            MakeDirectory(path);
            var randomName = MakeRandomName(file);
            path = Path.Combine(path, randomName);

            await CopyFileTo(path, file);

            storableFile.FileName = randomName;
            storableFile.ContentType = file.ContentType;
            storableFile.Extension = MakeExtension(file);

            return storableFile;
        }

        private string MakePath(string path)
        {
            return Path.Combine(_folder, path);
        }

        public string MakeRandomName(IFormFile file)
        {
            var extension = MakeExtension(file);
            var randomName = Guid.NewGuid().ToString();

            return extension == null ? randomName : $"{randomName}.{extension}";
        }

        public string MakeExtension(IFormFile file)
        {
            return file.FileName.Split('.').Last();
        }
    }
}