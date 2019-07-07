using System;
using System.Linq;
using VouDeVan.Core.Business.Support;
using VouDeVan.Core.Business.TransportationCompanies;

namespace VouDeVan.Infrastructure.Database.TransportationCompanies
{
    internal class TransportationCompanyRepository :
        RepositoryEntity<TransportationCompany, TransportationCompanyDataRow>,
        ITransportationCompanyRepository
    {
        public TransportationCompanyRepository(DataBaseContext dataBaseContext,
            IDataMapper<TransportationCompany, TransportationCompanyDataRow> dataMapper)
            : base(dataBaseContext, dataMapper)
        {
        }

        public bool DoesNotHaveSameCnpj(Cnpj cnpj, Guid? id = null)
        {
            if (id == null)
            {
                return DbSet.Any(row => row.Cnpj == cnpj.Number);
            }

            return DbSet
                .Where(row => row.Cnpj == cnpj.Number)
                .Any(row => row.Id == id);
        }
    }
}