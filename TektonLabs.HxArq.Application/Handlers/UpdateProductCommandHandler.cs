using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.HxArq.Application.Commands;
using TektonLabs.HxArq.Domain.Interfaces;
using TektonLabs.HxArq.Domain.Entities;

namespace TektonLabs.HxArq.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductEntity
            {
                ProductId = request.ProductId,
                Name = request.Name,
                Status = request.Status,
                Stock = request.Stock,
                Description = request.Description,
                Price = request.Price
            };

            await _productRepository.UpdateAsync(product);
        }
    }
}
