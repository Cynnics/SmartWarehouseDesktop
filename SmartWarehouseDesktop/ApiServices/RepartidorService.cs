using Newtonsoft.Json;
using SmartWarehouseDesktop.ApiModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.ApiServices
{
    public class RepartidorService
    {
        private readonly HttpClient _http;

        public RepartidorService()
        {
            _http = ApiConfig.GetClient();
        }

        public async Task<List<RepartidorApiModel>> GetAll()
        {
            var response = await _http.GetAsync("api/Repartidores");

            if (!response.IsSuccessStatusCode)
                return null;

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<RepartidorApiModel>>(json);
        }
    }

}
