using MySampleApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Domain.Interfaces
{
    public interface IExternalProductRepository
    {
        Task<List<ExternalProductData>> GetData();
    }
}
