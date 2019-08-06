using System;

namespace VouDeVan.Core.Business.Support
{
    public class BusinessException : Exception
    {
        public BusinessException(string message): base(message)
        {
        }
    }
}
