using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SmartWarehouseDesktop.ApiModels
{
    public static class ApiClient
    {
        public static HttpClient GetClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://cogent-anderson-alphamerically.ngrok-free.dev");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Session.Token);

            return client;
        }
    }
}
