using MediatR;
using MySampleApp.Domain.Entities;
using MySampleApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Application.Commands
{
    public record UpdateProductCommand(int Id,ProductEntity ProductEntity)
        : IRequest<ProductEntity>;
    public class UpdateProductCommandHandler(IProductRepository productRepository)
        : IRequestHandler<UpdateProductCommand, ProductEntity>
    {
        public async Task<ProductEntity> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
           return await productRepository.UpdateProduct(request.Id, request.ProductEntity);
        }
    }
}
