using Newtonsoft.Json;
using SmartWarehouseDesktop.ApiModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

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

        public async Task<List<RutaEntregaApiModel>> GetAll()
        {
            var response = await _http.GetAsync("api/Rutas");
            string json = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("GetAll Status: " + response.StatusCode);
            Debug.WriteLine("GetAll Body: " + json);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<List<RutaEntregaApiModel>>(json);
        }

        public async Task<RutaEntregaApiModel> GetById(int id)
        {
            var response = await _http.GetAsync($"api/Rutas/{id}");
            string json = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"GetById {id} Status: {response.StatusCode}");
            Debug.WriteLine("Body: " + json);

            if (!response.IsSuccessStatusCode) return null;
            return JsonConvert.DeserializeObject<RutaEntregaApiModel>(json);
        }
        public async Task<bool> Create(RutaEntregaApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/Rutas", content);
            string body = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("Create Status: " + response.StatusCode);
            Debug.WriteLine("Create Body: " + body);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(RutaEntregaApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("PATCH"),
                new Uri(_http.BaseAddress, $"api/Rutas/{model.IdRuta}"));
            request.Content = content;

            var response = await _http.SendAsync(request);
            string body = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("Update Status: " + response.StatusCode);
            Debug.WriteLine("Update Body: " + body);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Rutas/{id}");
            string body = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("Delete Status: " + response.StatusCode);
            Debug.WriteLine("Delete Body: " + body);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<PedidoApiModel>> GetPedidosDeRuta(int id)
        {
            var response = await _http.GetAsync($"api/Rutas/{id}/pedidos");
            string json = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"GetPedidosDeRuta {id} Status: {response.StatusCode}");
            Debug.WriteLine("Body: " + json);
            if (!response.IsSuccessStatusCode) return null;
            return JsonConvert.DeserializeObject<List<PedidoApiModel>>(json);
        }

        public async Task<List<UbicacionRepartidorApiModel>> GetUbicacionesDeRuta(int id)
        {
            var response = await _http.GetAsync($"api/Rutas/{id}/ubicaciones");
            string json = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"GetUbicacionesDeRuta {id} Status: {response.StatusCode}");
            Debug.WriteLine("Body: " + json);
            if (!response.IsSuccessStatusCode) return null;
            return JsonConvert.DeserializeObject<List<UbicacionRepartidorApiModel>>(json);
        }

        public async Task<int?> CreateAndReturnId(RutaEntregaApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/Rutas", content);

            string body = await response.Content.ReadAsStringAsync();
            System.Diagnostics.Debug.WriteLine("Create Ruta Status: " + response.StatusCode);
            System.Diagnostics.Debug.WriteLine("Create Ruta Body: " + body);

            if (!response.IsSuccessStatusCode)
                return null;

            var rutaCreada = JsonConvert.DeserializeObject<RutaEntregaApiModel>(body);
            return rutaCreada.IdRuta;
        }

    }
}
