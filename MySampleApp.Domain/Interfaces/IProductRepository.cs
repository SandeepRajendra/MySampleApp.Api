using MySampleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProducts();
        Task<ProductEntity> GetProductById(int Id);
        Task<ProductEntity> AddProduct(ProductEntity productEntity);
        Task<ProductEntity> UpdateProduct(int ProdId, ProductEntity productEntity);
        Task<bool> DeleteProduct(int ProdId);
    }
}
