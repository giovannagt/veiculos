using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Veiculos.Site.Functions
{
    public static class CallApi
    {
        public async static Task<string> Get(string rota)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44398/api/Veiculo/" + rota);
                return await response.Content.ReadAsStringAsync();                
            }
        }

        public async static Task<HttpResponseMessage> Post(string rota, string message)
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44398/api/Veiculo/" + rota)
                {
                    Content = new StringContent(message, Encoding.UTF8, "application/json")
                };

                return await client.SendAsync(request);
            }
        }

        public async static Task<HttpResponseMessage> Put(string rota, string message)
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "https://localhost:44398/api/Veiculo/" + rota)
                {
                    Content = new StringContent(message, Encoding.UTF8, "application/json")
                };

                return await client.SendAsync(request);
            }
        }

        public async static Task<HttpResponseMessage> Delete(string rota)
        {            
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:44398/api/Veiculo/" + rota);
                return await client.SendAsync(request);
            }
        }
    }
}