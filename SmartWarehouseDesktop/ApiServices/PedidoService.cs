using Newtonsoft.Json;
using SmartWarehouseDesktop.ApiModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartWarehouseDesktop.ApiServices
{
    public class PedidoService
    {
        private readonly HttpClient _http;

        public PedidoService()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(ApiConfig.BaseUrl);

            if (Session.Token != null)
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.Token);
        }

        public async Task<List<PedidoApiModel>> GetAll()
        {
            var response = await _http.GetAsync("api/Pedidos");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PedidoApiModel>>(json);
        }

        public async Task<bool> Create(PedidoApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/Pedidos", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PatchEstado(int id, string nuevoEstado)
        {
            var json = $"\"{nuevoEstado}\""; 
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"api/Pedidos/{id}/estado");
            request.Content = content;

            var response = await _http.SendAsync(request);
            return response.IsSuccessStatusCode;
        }


        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Pedidos/{id}");
            return response.StatusCode == System.Net.HttpStatusCode.NoContent
                || response.IsSuccessStatusCode;
        }


        public async Task<List<PedidoApiModel>> GetEntregados()
        {
            var response = await _http.GetAsync("api/Pedidos?estado=entregado");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PedidoApiModel>>(json);
        }

        public async Task<TotalesPedidoApiModel> GetTotales(int idPedido)
        {
            try
            {
                var response = await _http.GetAsync($"api/Pedidos/{idPedido}/totales");

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                string json = await response.Content.ReadAsStringAsync();

                System.Diagnostics.Debug.WriteLine($"Totales JSON: {json}");

                if (string.IsNullOrWhiteSpace(json))
                {
                    return null;
                }

                var totales = JsonConvert.DeserializeObject<TotalesPedidoApiModel>(json);
                 return totales;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener totales del pedido {idPedido}:\n{ex.Message}");
                return null;
            }
        }

        public async Task<bool> Update(PedidoApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PutAsync($"api/Pedidos/{model.IdPedido}", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateRepartidor(int idPedido, int idRepartidor, string estado)
        {
            var payload = new
            {
                IdRepartidor = idRepartidor,
                Estado = estado
            };

            string json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PutAsync($"api/Pedidos/PutPedidoRepartidor/{idPedido}", content);
            return response.IsSuccessStatusCode;
        }


        public async Task<PedidoApiModel> GetById(int idPedido)
        {
            var response = await _http.GetAsync($"api/Pedidos/{idPedido}");
            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PedidoApiModel>(json);
        }

   
    }
}
