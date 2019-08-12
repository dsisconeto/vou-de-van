using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.App.Web.AdminPainel.Support.Storage
{
    public interface IStorage
    {
        Task<T> Store<T>(IFormFile file) where T : StoreableFile, new();
    }
}