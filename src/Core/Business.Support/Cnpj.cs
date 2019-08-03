namespace VouDeVan.Core.Business.Support
{
    public class Cnpj
    {
        private string _number;



        public Cnpj(string number)
        {
            Number = number;
        }

        public string Number
        {
            get => _number;
            private set
            {
                //Guard.IsNullOrWhiteSpace(_number);
                
                //value = value.Replace(".", "")
                //    .Replace("/", "")
                //    .Replace("-", "");
                
                //Guard.Business(value.Length == 14, "Tamanho do CNPJ deve ser 14 digitos");

                _number = value;
            }
        }
    }
}
