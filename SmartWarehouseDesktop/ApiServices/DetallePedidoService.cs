using Newtonsoft.Json;
using SmartWarehouseDesktop.ApiModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class DetallePedidoService
{
    private readonly HttpClient _http;

    public DetallePedidoService()
    {
        _http = new HttpClient();
        _http.BaseAddress = new Uri(ApiConfig.BaseUrl);

        if (Session.Token != null)
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Session.Token);
    }

    public async Task<List<DetallePedidoApiModel>> GetAll()
    {
        var response = await _http.GetAsync("api/DetallePedido");
        string json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<DetallePedidoApiModel>>(json);
    }

    public async Task<List<DetallePedidoApiModel>> GetByPedido(int idPedido)
    {
        var response = await _http.GetAsync($"api/DetallePedido/pedido/{idPedido}");
        string json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<DetallePedidoApiModel>>(json);
    }

    public async Task<bool> Create(DetallePedidoApiModel model)
    {
        string json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _http.PostAsync("api/DetallePedido", content);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> Update(int id, DetallePedidoApiModel model)
    {
        string json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Solución para CS0117: HttpMethod no tiene Patch, así que lo creamos manualmente.
        var patchMethod = new HttpMethod("PATCH");

        // Solución para CS1503: El segundo argumento debe ser Uri, no string.
        var requestUri = new Uri(_http.BaseAddress, $"api/DetallePedido/{id}");

        var request = new HttpRequestMessage(patchMethod, requestUri)
        {
            Content = content
        };

        var response = await _http.SendAsync(request);
        return response.IsSuccessStatusCode;

    }

    public async Task<bool> Delete(int id)
    {
        var response = await _http.DeleteAsync($"api/DetallePedido/{id}");
        return response.IsSuccessStatusCode;
    }
}
