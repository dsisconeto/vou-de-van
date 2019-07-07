using System;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.Core.Business.TransportationCompanies
{
    public interface ITransportationCompanyRepository : IRepository<TransportationCompany>
    {
        bool DoesNotHaveSameCnpj(Cnpj cnpj, Guid? id = null);
    }
}