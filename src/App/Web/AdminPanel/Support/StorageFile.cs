using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.App.Web.AdminPainel.Support
{
    public class StorageFile : AbstractStorageFile
    {

        public StorageFile(string folder) : base(folder)
        {
        }


        protected override async Task CopyFileTo(string path, IFormFile file)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }


        protected override void MakeDirectory(string path)
        {
            if (Directory.Exists(path))
            {
             return;
            }

            Directory.CreateDirectory(path);

        }
    }
}