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
    public class UbicacionRepartidorService
    {
        private readonly HttpClient _http;

        public UbicacionRepartidorService()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(ApiConfig.BaseUrl);

            if (Session.Token != null)
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.Token);
        }

        // GET ALL
        public async Task<List<UbicacionRepartidorApiModel>> GetAll()
        {
            var response = await _http.GetAsync("api/Ubicaciones");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<UbicacionRepartidorApiModel>>(json);
        }

        // GET BY REPARTIDOR
        public async Task<List<UbicacionRepartidorApiModel>> GetByRepartidor(int idRep)
        {
            var response = await _http.GetAsync($"api/Ubicaciones/repartidor/{idRep}");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<UbicacionRepartidorApiModel>>(json);
        }

        // CREATE
        public async Task<bool> Create(UbicacionRepartidorApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/Ubicaciones", content);
            return response.IsSuccessStatusCode;
        }

        // DELETE
        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Ubicaciones/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<UbicacionRepartidorApiModel>> GetByRuta(int idRuta)
        {
            var response = await _http.GetAsync($"api/Rutas/{idRuta}/ubicaciones");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<UbicacionRepartidorApiModel>>(json);
        }

        public async Task<bool> Update(UbicacionRepartidorApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("PATCH"),
                $"api/Ubicaciones/{model.IdUbicacion}");

            request.Content = content;

            var resp = await _http.SendAsync(request);
            return resp.IsSuccessStatusCode;
        }


    }
}
