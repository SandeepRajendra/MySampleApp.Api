using MySampleApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Infrastructure.Services
{
    public class FakeStoreHttpClientService(HttpClient httpClient)
    {
        public async Task<List<ExternalProductData>> GetData()
        {
            var url = "products";
            return await httpClient.GetFromJsonAsync<List<ExternalProductData>>(url)
                   ?? new List<ExternalProductData>();
        }
    }
}
