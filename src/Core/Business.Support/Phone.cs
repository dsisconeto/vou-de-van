namespace VouDeVan.Core.Business.Support
{
    public class Phone
    {
        private string _ddd;
        private string _number;

        public Phone(string completeNumber)
        {
            Guard.IsNullOrWhiteSpace(completeNumber);
            completeNumber = completeNumber.Replace(".", "")
                .Replace(")", "")
                .Replace("(", "")
                .Trim();

            Ddd = completeNumber.Substring(0, 2);
            //Number = completeNumber.Substring(3, completeNumber.Length);
        }

        public Phone(string ddd, string number)
        {
            Ddd = ddd;
            Number = number;
        }

        public string Number
        {
            get => _number;
            private set
            {
                //Guard.IsNullOrWhiteSpace(value);
                //Guard.Argument(
                //    value.Length == 8 || value.Length == 9,
                //    "Número do telefone tem que ter entre 8 e 9 digitos");

                _number = value;
            }
        }

        public string Ddd
        {
            get => _ddd;
            private set
            {
                //Guard.IsNullOrWhiteSpace(value);
                //Guard.Argument(
                //    value.Length == 2,
                //    "DDD do telefone tem que ser 2 digitos");

                _ddd = value;
            }
        }

        public override string ToString()
        {
            return _ddd + _number;
        }
    }
}