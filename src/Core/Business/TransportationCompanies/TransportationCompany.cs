using System;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.Core.Business.TransportationCompanies
{
    public class TransportationCompany
    {
        private string _fantasyName;
        private string _socialName;
        private Cnpj _cnpj;
        private string _address;
        private Representative _representative;
        private string _observation;

        public TransportationCompany(Guid id, string fantasyName, string socialName, Cnpj cnpj, string address,
            Representative representative, string observation, Status status)
        {
            Id = id;
            FantasyName = fantasyName;
            SocialName = socialName;
            Cnpj = cnpj;
            Address = address;
            Representative = representative;
            Observation = observation;
            Status = status;
        }

        public Guid Id { get; set; }

        public string FantasyName
        {
            get => _fantasyName;
            set
            {
                //Guard.IsNullOrWhiteSpace(_fantasyName);
                //Guard.Argument(value.Length <= 100,
                //    "Tamanho máximo do Nome Fantasia é 100 caracteres");

                _fantasyName = value;
            }
        }

        public string SocialName
        {
            get => _socialName;
            set
            {
                //Guard.IsNullOrWhiteSpace(_socialName);
                //Guard.Argument(
                //    value.Length <= 50,
                //    "Tamanho máximo da Razão Social é 50 caracteres");

                _socialName = value;
            }
        }

        public Cnpj Cnpj
        {
            get => _cnpj;
            set
            {
                //Guard.IsNotNull(_cnpj);
                _cnpj = value;
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                //Guard.IsNotNull(_address);
                //Guard.Argument(
                //    value.Length <= 400,
                //    "Tamanho máximo do endereço é 400 caracteres");
                _address = value;
            }
        }

        public Representative Representative
        {
            get => _representative;
            set
            {
                //Guard.IsNotNull(_representative);
                _representative = value;
            }
        }

        public string Observation
        {
            get => _observation;
            set
            {
                //Guard.Argument(value.Length <= 10000, "Tamanho máximo da observação é 10000 caracteres");
                //Guard.IsNotNull(_observation);
                _observation = value;
            }
        }

        public Status Status { get; }

        public bool IsActive => Status == Status.Active;
        public bool IsDisabled => Status == Status.Disabled;
        public bool IsCreated => Status == Status.Created;
    }
}