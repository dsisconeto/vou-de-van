using System;
using System.Collections.Generic;
using System.Text;

namespace VouDeVan.Core.Support
{
    public class Phone
    {
        private string _value;

        public Phone(string value)
        {
            _value = value.Replace("-", "")
                .Replace(")", "")
                .Replace("(", "")
                .Replace(" ", "");
        }

        public override string ToString()
        {
            return _value;
        }
    }
}