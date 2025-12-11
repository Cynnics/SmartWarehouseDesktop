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
    public class FacturaService
    {
        private readonly HttpClient _http;

        public FacturaService()
        {
            _http = new HttpClient();
            _http.BaseAddress = new Uri(ApiConfig.BaseUrl);

            if (Session.Token != null)
                _http.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Session.Token);
        }

        // 🔹 Obtener todas las facturas
        public async Task<List<FacturaApiModel>> GetAll()
        {
            var response = await _http.GetAsync("api/Facturas");
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<FacturaApiModel>>(json);
        }

        // 🔹 Obtener facturas por pedido
        public async Task<List<FacturaApiModel>> GetByPedido(int idPedido)
        {
            try
            {
                var response = await _http.GetAsync($"api/Facturas/pedido/{idPedido}");

                if (!response.IsSuccessStatusCode)
                {
                    return new List<FacturaApiModel>(); // Devolver lista vacía en lugar de null
                }

                string json = await response.Content.ReadAsStringAsync();

                // Debug: Ver qué estás recibiendo
                System.Diagnostics.Debug.WriteLine($"JSON Recibido: {json}");

                // Verificar si el JSON está vacío o es inválido
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<FacturaApiModel>();
                }

                return JsonConvert.DeserializeObject<List<FacturaApiModel>>(json);
            }
            catch (JsonReaderException ex)
            {
                MessageBox.Show($"Error al deserializar facturas:\n{ex.Message}\n\nJSON recibido puede ser inválido.");
                return new List<FacturaApiModel>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener facturas del pedido {idPedido}:\n{ex.Message}");
                return new List<FacturaApiModel>();
            }
        }

        // 🔹 Crear factura
        public async Task<bool> Create(FacturaApiModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("api/Facturas", content);

            string debugResponse = await response.Content.ReadAsStringAsync();
            MessageBox.Show("Código: " + response.StatusCode + "\nRespuesta:\n" + debugResponse);

            return response.IsSuccessStatusCode;
        }


        // 🔹 Borrar factura (hard delete o soft delete según API)
        public async Task<bool> Delete(int id)
        {
            var response = await _http.DeleteAsync($"api/Facturas/{id}");
            return response.IsSuccessStatusCode;
        }


        // 🔹 Comprobar si ya existe factura para un pedido
        public async Task<bool> ExisteFactura(int idPedido)
        {
            var facturas = await GetByPedido(idPedido);

            // Devuelve true si hay al menos una factura para este pedido
            return facturas != null && facturas.Count > 0;
        }

    }
}
