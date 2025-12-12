using Newtonsoft.Json;
using SmartWarehouseDesktop.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmartWarehouseDesktop.ApiServices
{
    public class RutaPedidoService
    {
        private readonly HttpClient _http;

        public RutaPedidoService()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(ApiConfig.BaseUrl);

            if (Session.Token != null)
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.Token);
        }

        public async Task<bool> AsignarPedido(int idRuta, int idPedido)
        {
            var response = await _http.PostAsync(
                $"api/Rutas/{idRuta}/pedidos/{idPedido}", null);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<PedidoApiModel>> GetPedidos(int idRuta)
        {
            var response = await _http.GetAsync($"api/Rutas/{idRuta}/pedidos");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PedidoApiModel>>(json);
        }
    }

}
