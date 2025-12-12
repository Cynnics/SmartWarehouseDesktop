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
    public class ProductoService
    {
        private readonly HttpClient _http;

        public ProductoService()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(ApiConfig.BaseUrl);

            if (!string.IsNullOrEmpty(Session.Token))
            {
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.Token);
            }
         
        }

        public async Task<List<ProductApiModel>> GetAll()
        {
            var response = await _http.GetAsync("api/Productos");

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine("GET error: " + error);
                return null;
            }

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ProductApiModel>>(json);
        }


        public async Task<bool> Create(ProductApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/Productos", content);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine("Create error: " + error);
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(ProductApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PutAsync($"api/Productos/{model.IdProducto}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Productos/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PatchProducto(int id, object cambios)
        {
            var json = JsonConvert.SerializeObject(cambios);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("PATCH"),
                                                 $"api/Productos/{id}");
            request.Content = content;

            var response = await _http.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        public async Task<ProductApiModel> GetById(int id)
        {
            var response = await _http.GetAsync($"api/Productos/{id}");
                      
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductApiModel>(json);
        }


    }
}
