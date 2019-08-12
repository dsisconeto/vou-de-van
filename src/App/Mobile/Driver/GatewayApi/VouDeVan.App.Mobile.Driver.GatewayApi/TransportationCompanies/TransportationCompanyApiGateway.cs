using System.Net.Http;
using System.Threading.Tasks;
using VouDeVan.Core.Support;
using VouDeVan.Core.Support.TransportationCompanies;


namespace VouDeVan.App.Mobile.Driver.GatewayApi.TransportationCompanies
{
    public class TransportationCompanyApiGateway : ApiGateway
    {
        public TransportationCompanyApiGateway(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<Paginate<TransportationCompaniesGetQueryViewModel>> Get(TransportationCompaniesGetQuery getQuery)
        {
            return await _Get<Paginate<TransportationCompaniesGetQueryViewModel>>("", getQuery);
        }
    }
}