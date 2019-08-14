using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace VouDeVan.App.Mobile.Driver.GatewayApi
{
    // It is layer super type
    public abstract class ApiGateway
    {
        private readonly HttpClient _httpClient;

        protected ApiGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        protected async Task<HttpResponseMessage> _Get(string uri, object query)
        {
            if (query != null)
            {
                //uri = uri.SetQueryParams(query);
            }
            return await _httpClient.GetAsync(uri);
        }


        protected async Task<T> _Get<T>(string uri, object query)
        {
            var response = await _Get(uri, query);

            if (response.IsSuccessStatusCode == false)
            {
                // TODO deu merda, lançar um expcetion aqui
                throw new Exception("Deu Merda na requisição");
            }

            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}