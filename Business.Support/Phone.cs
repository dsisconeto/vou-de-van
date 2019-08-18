namespace Business.Support
{
    public class Phone
    {
        private readonly string _value;

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