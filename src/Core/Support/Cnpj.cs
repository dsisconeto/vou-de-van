using System;
using System.Collections.Generic;
using System.Text;

namespace VouDeVan.Core.Support
{
    public class Cnpj
    {
        private string _value;

        public Cnpj(string value)
        {
            _value = value.Replace(".", "")
                .Replace("-", "")
                .Replace("/", "");
        }


        public override string ToString()
        {
            return _value;
        }
    }
}