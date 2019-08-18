using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Support;
using Microsoft.EntityFrameworkCore;
using VouDeVan.Core.Business.Support;

namespace Business.TransportationCompanies
{
    public class TransportationCompanyServices
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly IMapper _mapper;

        public TransportationCompanyServices(DataBaseContext dataBaseContext, IMapper mapper)
        {
            _dataBaseContext = dataBaseContext;
            _mapper = mapper;
        }

        public async Task<TransportationCompany> Create(TransportationCompany transportationCompany)
        {
            if (HasCompanySameCpnj(transportationCompany.CNPJ))
            {
                throw new BusinessException("Não pode existir duas empresas com o mesmo CNPJ.");
            }

            transportationCompany.Id = Guid.NewGuid();
            transportationCompany.Status = Status.Active;

            _dataBaseContext.TransportationCompanies.Add(transportationCompany);

            await _dataBaseContext.SaveChangesAsync();

            return transportationCompany;
        }

        public async Task<TransportationCompany> Update(TransportationCompany transportationCompany)
        {
            if (HasCompanySameCpnj(transportationCompany.CNPJ, transportationCompany.Id))
            {
                throw new BusinessException("Não pode existir duas empresas com o mesmo CNPJ.");
            }

            _dataBaseContext.TransportationCompanies.Update(transportationCompany);

            await _dataBaseContext.SaveChangesAsync();

            return transportationCompany;
        }


        public async Task Delete(Guid id)
        {
            // TODO verificar relações quando tiver.

            var transportationCompany = await FindById(id);


            if (transportationCompany == null)
            {
                throw new BusinessException("Empresa de transporte não encontrada");
            }

            _dataBaseContext.TransportationCompanies.Remove(transportationCompany);

            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task<TransportationCompany> FindById(Guid id)
        {
            return await _dataBaseContext.TransportationCompanies.FirstOrDefaultAsync(tc => tc.Id == id);
        }

        public async Task<Paginate<TransportationCompany>> FindAllToGrid(int page, int rowsPerPage = 10)
        {
            var query = _dataBaseContext.TransportationCompanies.OrderByDescending(tc => tc.CreatedAt);


            return await query.ToPaginate(page, rowsPerPage);
        }


        public bool HasCompanySameCpnj(string cnpj, Guid? id = null)
        {
            var query = _dataBaseContext.TransportationCompanies.Where(tc => tc.CNPJ == cnpj);

            if (id != null)
            {
                query = query.Where(tc => tc.Id != id);
            }

            return query.Any();
        }
    }
}