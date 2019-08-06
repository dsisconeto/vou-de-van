﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.Core.Business.Domains.TransportationCompanies
{
    public class TransportationCompanyServices
    {
        private readonly DataBaseContext _dataBaseContext;

        public TransportationCompanyServices(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
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


        public async void Delete(TransportationCompany transportationCompany)
        {
            // TODO verificar relações quando tiver.

            _dataBaseContext.TransportationCompanies.Remove(transportationCompany);
            await _dataBaseContext.SaveChangesAsync();
        }

        public async Task<TransportationCompany> FindById(Guid id)
        {
            return await _dataBaseContext.TransportationCompanies.FirstOrDefaultAsync(tc => tc.Id == id);
        }

        public async Task<List<TransportationCompany>> Paginate(int page, int perPage)
        {
            var skip = (page - 1) * perPage;

            return await _dataBaseContext.TransportationCompanies
                .Skip(skip)
                .Take(perPage)
                .OrderByDescending(tc => tc.CreatedAt)
                .ToListAsync();
        }

        public bool HasCompanySameCpnj(string cnpj, Guid? id = null)
        {
            var query = _dataBaseContext.TransportationCompanies.Where(tc => tc.CNPJ == cnpj);

            if (id != null)
            {
                query = query.Where(tc => tc.Id == id);
            }

            return query.Any();
        }
    }
}