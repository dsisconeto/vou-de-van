using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.App.Web.AdminPainel.Support.Storage
{
    public abstract class Storage : IStorage
    {
        
        protected abstract Task<string> CopyFileTo(string directory, string fileName, IFormFile file);


        public async Task<T> Store<T>(IFormFile file) where T : StoreableFile, new()
        {
            var storableFile = new T();

            var path = storableFile.Path;

            var randomName = MakeRandomName(file);

            storableFile.Uri = await CopyFileTo(path, randomName,  file);

            storableFile.FileName = randomName;
            storableFile.ContentType = file.ContentType;
            storableFile.Extension = MakeExtension(file);
       

            return storableFile;
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