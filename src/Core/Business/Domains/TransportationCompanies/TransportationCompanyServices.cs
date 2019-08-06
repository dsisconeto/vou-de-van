using System;

namespace VouDeVan.Core.Business.Domains.TransportationCompanies
{
    public class TransportationCompanyServices
    {
        private readonly DataBaseContext _dataBaseContext;

        public TransportationCompanyServices(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public TransportationCompany Create(TransportationCompany transportationCompany)
        {

            _dataBaseContext.TransportationCompany.Add(transportationCompany);

            return null;
        }

        public TransportationCompany Update(TransportationCompany transportationCompany)
        {



            return null;
        }


        public TransportationCompany Delete(TransportationCompany transportationCompany)
        {



            return null;
        }
    }
}
