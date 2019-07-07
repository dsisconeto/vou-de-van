using AutoMapper;
using VouDeVan.Core.Business.TransportationCompanies;


namespace VouDeVan.Infrastructure.Database.TransportationCompanies
{
    internal class TransportationCompanyDataMapper : IDataMapper<TransportationCompany, TransportationCompanyDataRow>
    {
        private readonly TransportationCompanyFactory _transportationCompanyFactory;
        private readonly IMapper _mapper;

        public TransportationCompanyDataMapper(TransportationCompanyFactory transportationCompanyFactory,
            IMapper mapper)
        {
            _transportationCompanyFactory = transportationCompanyFactory;
            _mapper = mapper;
        }

        public Core.Business.TransportationCompanies.TransportationCompany ToEntity(
            TransportationCompanyDataRow dataRow)
        {
            var dto = _mapper.Map<TransportationCompanyDto>(dataRow);

            return _transportationCompanyFactory.MakeByDto(dto);
        }

        public TransportationCompanyDataRow ToRow(TransportationCompany entity)
        {
            return _mapper.Map<TransportationCompanyDataRow>(entity);
        }
    }
}