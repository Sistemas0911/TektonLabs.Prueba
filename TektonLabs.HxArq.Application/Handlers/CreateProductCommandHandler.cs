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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private static int _currentId = 0;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductEntity
            {
                ProductId = ++_currentId,
                Name = request.Name,
                Status = request.Status,
                Stock = request.Stock,
                Description = request.Description,
                Price = request.Price
            };

            await _productRepository.AddAsync(product);
            return product.ProductId;
        }
    }
}
