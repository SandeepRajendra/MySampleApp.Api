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
    public record AddProductCommand(ProductEntity ProductEntity): IRequest<ProductEntity>;
    public class AddProductCommandHandler(IProductRepository productRepository, IPublisher mediator)
        : IRequestHandler<AddProductCommand, ProductEntity>
    {
        public async Task<ProductEntity> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await productRepository.AddProduct(request.ProductEntity);
        }
    }
}
