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
        public async Task<dynamic> GetData()
        {
            return await httpClient.GetFromJsonAsync<dynamic>("https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=USD,EUR,INR");
        }
    }
}
