using MediatR;
using MySampleApp.Domain.Entities;
using MySampleApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Application.Queries
{
    public record GetProductByIdQuery(int Id): IRequest<ProductEntity>;
    public class GetProductByIdQueryHandler(IProductRepository productRepository)
        : IRequestHandler<GetProductByIdQuery, ProductEntity>
    {
        public async Task<ProductEntity> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetProductById(request.Id);
        }
    }
}
