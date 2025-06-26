using MySampleApp.Domain.Interfaces;
using MySampleApp.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Infrastructure.Repositories
{
    public class ExternalProductRepository(
     FakeStoreHttpClientService fakeStoreHttpClientService)
        : IExternalProductRepository
    {
        public async Task<dynamic> GetData()
        {
            return await fakeStoreHttpClientService.GetData();
        }
    }
}
