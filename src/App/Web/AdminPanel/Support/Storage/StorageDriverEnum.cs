using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VouDeVan.App.Web.AdminPainel.Support.Storage
{
    public enum StorageDriverEnum
    {
        Azure,
        File
    }

    static class StorageDriverEnumExtension
    {
        public static bool IsAzure(this StorageDriverEnum storageDriver)
        {
            return storageDriver == StorageDriverEnum.Azure;
        }

        public static bool IsFile(this StorageDriverEnum storageDriver)
        {
            return storageDriver == StorageDriverEnum.File;
        }
    }
}