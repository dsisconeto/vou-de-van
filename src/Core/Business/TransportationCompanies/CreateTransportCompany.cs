using System;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.Core.Business.TransportationCompanies
{
    public class CreateTransportationCompanies
    {
        private readonly ITransportationCompanyRepository _transportationCompanyRepository;
        private readonly TransportationCompanyFactory _transportationCompanyFactory;


        public CreateTransportationCompanies(ITransportationCompanyRepository transportationCompanyRepository,
            TransportationCompanyFactory transportationCompanyFactory)
        {
            _transportationCompanyRepository = transportationCompanyRepository;
            _transportationCompanyFactory = transportationCompanyFactory;
        }

        public TransportationCompany Create(TransportationCompanyDto transportationCompanyDto)
        {
            transportationCompanyDto.Status = Status.Active;
            transportationCompanyDto.Id = Guid.NewGuid();
            var transportationCompany = _transportationCompanyFactory.MakeByDto(transportationCompanyDto);

            Guard.Business(
                _transportationCompanyRepository.DoesNotHaveSameCnpj(transportationCompany.Cnpj),
                "Não pode existir duas empresas com o mesmo cnpj");

            _transportationCompanyRepository.Store(transportationCompany);

            return transportationCompany;
        }
    }
}