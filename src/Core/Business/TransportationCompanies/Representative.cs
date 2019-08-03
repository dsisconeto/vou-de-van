using VouDeVan.Core.Business.Support;

namespace VouDeVan.Core.Business.TransportationCompanies
{
    public class Representative
    {
        private string _name;
        private Phone _phone;

        public Representative(string name, Phone phone)
        {
            Name = name;
            Phone = phone;
        }

        public string Name
        {
            get => _name;
            set
            {
                //Guard.IsNullOrWhiteSpace(_name);

                //Guard.Argument(value.Length <= 100, 
                //    "Nome do representante tem que ser no máximo 100");

                _name = value;
            }
        }

        public Phone Phone { get => _phone;
            set
            {
                //Guard.IsNotNull(value, "Telefone do representante é obrigatório");

                _phone = value;
            }
        }
    }
}
