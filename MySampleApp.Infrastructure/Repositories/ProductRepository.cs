using Microsoft.EntityFrameworkCore;
using MySampleApp.Domain.Entities;
using MySampleApp.Domain.Interfaces;
using MySampleApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Infrastructure.Repositories
{
    public class ProductRepository(MySampleAppDbContext mySampleAppDbContext) : IProductRepository
    {
        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await mySampleAppDbContext.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetProductById(int Id)
        {
            var product = await mySampleAppDbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {Id} not found.");
            return product;
        }

        public async Task<ProductEntity> AddProduct(ProductEntity productEntity)
        {
           productEntity.CreatedAt = DateTime.Now;
           mySampleAppDbContext.Products.Add(productEntity);
           await mySampleAppDbContext.SaveChangesAsync();
           return productEntity;
        }

        public async Task<ProductEntity> UpdateProduct(int ProdId,ProductEntity productEntity)
        {
            var product = await mySampleAppDbContext.Products.FirstOrDefaultAsync(x => x.Id == ProdId);
            if (product is not null) 
            { 
                product.Name = productEntity.Name;
                product.Description = productEntity.Description;
                product.Price = productEntity.Price;
                product.Quantity = productEntity.Quantity;
                product.UpdatedAt = DateTime.Now;

                await mySampleAppDbContext.SaveChangesAsync();
                return product;
            }
            return productEntity;
        }

        public async Task<bool> DeleteProduct(int ProdId)
        {
            var product = await mySampleAppDbContext.Products.FirstOrDefaultAsync(x => x.Id == ProdId);
            if (product is not null)
            {
                mySampleAppDbContext.Products.Remove(product);
                return await mySampleAppDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
