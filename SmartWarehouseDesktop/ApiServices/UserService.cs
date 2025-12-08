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
    public class UserService
    {
        private readonly HttpClient _http;

        public UserService()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(ApiConfig.BaseUrl);

            if (Session.Token != null)
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.Token);
        }

        // GET all users (ADMIN only)
        public async Task<List<UserApiModel>> GetAll()
        {
            var response = await _http.GetAsync("api/Usuarios");

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<UserApiModel>>(json);
        }

        // GET single user by ID
        public async Task<UserApiModel> GetById(int id)
        {
            var response = await _http.GetAsync($"api/Usuarios/{id}");

          
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserApiModel>(json);
        }


        // POST create user
        public async Task<bool> Create(CreateUserApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/Usuarios", content);
            return response.IsSuccessStatusCode;
        }


        // DELETE user
        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Usuarios/{id}");
            return response.IsSuccessStatusCode;
        }

        // PATCH for changes (solo si lo necesitas)
        public async Task<bool> Patch(int id, object cambios)
        {
            var json = JsonConvert.SerializeObject(cambios);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"api/Usuarios/{id}");
            request.Content = content;

            var response = await _http.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}
