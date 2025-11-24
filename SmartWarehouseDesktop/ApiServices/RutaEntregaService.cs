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
    public class RutaEntregaService
    {
        private readonly HttpClient _http;

        public RutaEntregaService()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(ApiConfig.BaseUrl);

            if (Session.Token != null)
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.Token);
        }

        // GET ALL
        public async Task<List<RutaEntregaApiModel>> GetAll()
        {
            var response = await _http.GetAsync("api/Rutas");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<RutaEntregaApiModel>>(json);
        }

        // GET BY ID
        public async Task<RutaEntregaApiModel> GetById(int id)
        {
            var response = await _http.GetAsync($"api/Rutas/{id}");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RutaEntregaApiModel>(json);
        }

        // CREATE
        public async Task<bool> Create(RutaEntregaApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/Rutas", content);
            return response.IsSuccessStatusCode;
        }

        // UPDATE COMPLETO
        public async Task<bool> Update(RutaEntregaApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Patch,
                new Uri(_http.BaseAddress, $"api/Rutas/{model.IdRuta}/estado"));
            request.Content = new StringContent($"\"{model.Estado}\"", Encoding.UTF8, "application/json");

            var response = await _http.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        // DELETE
        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Rutas/{id}");
            return response.IsSuccessStatusCode;
        }
    }


}
