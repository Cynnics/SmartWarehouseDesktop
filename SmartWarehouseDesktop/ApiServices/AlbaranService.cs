using Newtonsoft.Json;
using SmartWarehouseDesktop.ApiModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.ApiServices
{
    public class AlbaranService
    {
        private readonly HttpClient _http;

        public AlbaranService()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(ApiConfig.BaseUrl);

            if (Session.Token != null)
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.Token);
        }

        public async Task<List<AlbaranApiModel>> GetAll()
        {
            var response = await _http.GetAsync("api/Albaranes");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<AlbaranApiModel>>(json);
        }

        public async Task<AlbaranApiModel> GetById(int id)
        {
            var response = await _http.GetAsync($"api/Albaranes/{id}");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AlbaranApiModel>(json);
        }

        public async Task<bool> Create(AlbaranApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/Albaranes", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(AlbaranApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("PATCH"),
                new Uri(_http.BaseAddress, $"api/Albaranes/{model.IdAlbaran}"));

            request.Content = content;

            var response = await _http.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Albaranes/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ExisteAlbaran(int idPedido)
        {
            var response = await _http.GetAsync($"api/Albaranes/pedido/{idPedido}");

            if (!response.IsSuccessStatusCode)
                return false; 

            var json = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(json) || json == "null")
                return false;

            var albaran = JsonConvert.DeserializeObject<AlbaranApiModel>(json);
            return albaran != null && albaran.IdPedido == idPedido;
        }





    }
}
