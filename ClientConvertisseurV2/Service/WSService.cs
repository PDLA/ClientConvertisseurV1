using ClientConvertisseurV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Service
{
    class WSService
    {

        static HttpClient client = new HttpClient();

        private static WSService _instance;

        private WSService()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:1749/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static WSService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new WSService();
            }
            return _instance;
        }

        public async Task<List<Devise>> GetAllDeviseAsync()
        {
            List<Devise> devises = null;
            HttpResponseMessage response = await client.GetAsync("Devise");
            if (response.IsSuccessStatusCode)
            {
                devises = await response.Content.ReadAsAsync<List<Devise>>();
            }
            return devises;
        }

    }
}
