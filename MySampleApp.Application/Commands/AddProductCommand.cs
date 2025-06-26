using MediatR;
using MySampleApp.Application.Events;
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
            var addedProduct = await productRepository.AddProduct(request.ProductEntity);
            await mediator.Publish(new ProductAddedNotification(addedProduct), cancellationToken);
            return addedProduct;
        }
    }
}
