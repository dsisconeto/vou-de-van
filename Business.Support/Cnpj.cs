namespace Business.Support
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