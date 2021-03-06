﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Storage
{
    public abstract class Storage
    {
        
        protected abstract Task<string> CopyFileTo(string directory, string fileName, IFormFile file);


        public async Task<T> Store<T>(IFormFile file) where T : Storable, new()
        {
            var storableFile = new T();

            var path = storableFile.Directory;

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