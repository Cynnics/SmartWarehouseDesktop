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
    public class PedidoService
    {
        private readonly HttpClient _http;

        public PedidoService()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(ApiConfig.BaseUrl);
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Session.Token);
        }

        public async Task<List<PedidoApiModel>> GetEntregados()
        {
            var response = await _http.GetAsync("api/Pedidos/entregados");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PedidoApiModel>>(json);
        }
        public async Task<(decimal Subtotal, decimal IVA, decimal Total)> GetTotales(int idPedido)
        {
            var response = await _http.GetAsync($"api/Pedidos/{idPedido}/totales");
            string json = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(json);

            return ((decimal)data.subtotal, (decimal)data.iva, (decimal)data.total);
        }

    }
}   
