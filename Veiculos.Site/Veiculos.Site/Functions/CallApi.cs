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

        //public async static Task<string> Post(string rota, string message)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var response = await client.PostAsync("https://localhost:44398/api/Usuarios/" + rota, new StringContent(message, Encoding.UTF8, "application/json"));

        //        if(true)
        //        {

        //        }

        //        return await response.Content.ReadAsStringAsync();
        //    }
        //}
    }
}