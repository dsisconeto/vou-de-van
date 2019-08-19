using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Support;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Storage;
using VouDeVan.Core.Business.Support;

namespace Business.TransportationCompanies
{
    public class TransportationCompanyServices
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly IMapper _mapper;
        private readonly IStorage _storage;

        public TransportationCompanyServices(DataBaseContext dataBaseContext, IMapper mapper, IStorage storage)
        {
            _dataBaseContext = dataBaseContext;
            _mapper = mapper;
            _storage = storage;
        }

        public async Task<TransportationCompany> Create(TransportationCompany transportationCompany,
            IFormFile logoFormFile)
        {
            if (HasCompanySameCpnj(transportationCompany.CNPJ))
            {
                throw new BusinessException("Não pode existir duas empresas com o mesmo CNPJ.");
            }

            transportationCompany.Id = Guid.NewGuid();
            transportationCompany.Status = Status.Active;
            transportationCompany.Logo = await _storage.Store<Logo>(logoFormFile);

            _dataBaseContext.TransportationCompanies.Add(transportationCompany);

            await _dataBaseContext.SaveChangesAsync();

            return transportationCompany;
        }

        public async Task<TransportationCompany> Update(TransportationCompany transportationCompany,
            IFormFile logoFormFile = null)
        {
            if (HasCompanySameCpnj(transportationCompany.CNPJ, transportationCompany.Id))
            {
                throw new BusinessException("Não pode existir duas empresas com o mesmo CNPJ.");
            }


            var oldLogo = transportationCompany.Logo;

            if (logoFormFile != null)
            {
                transportationCompany.Logo = await _storage.Store<Logo>(logoFormFile);
            }

            _dataBaseContext.TransportationCompanies.Update(transportationCompany);

            await _dataBaseContext.SaveChangesAsync();

            if (logoFormFile != null)
            {
                await _storage.Destroy(oldLogo);
            }


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

            var logo = transportationCompany.Logo;

            _dataBaseContext.TransportationCompanies.Remove(transportationCompany);

            await _dataBaseContext.SaveChangesAsync();



            await _storage.Destroy(logo);

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
                query = query.Where(tc => tc.Id != id.Value);
            }

            return query.Any();
        }
    }
}