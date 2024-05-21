using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TektonLabs.HxArq.Application.Dtos;
using TektonLabs.HxArq.Application.Queries;
using TektonLabs.HxArq.Domain.Interfaces;
using TektonLabs.HxArq.Infrastructure.Cache;
using TektonLabs.HxArq.Infrastructure.Services;


namespace TektonLabs.HxArq.Application.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductStatusCache _statusCache;
        private readonly DiscountService _discountService;

        public GetProductByIdQueryHandler(IProductRepository productRepository, ProductStatusCache statusCache, DiscountService discountService)
        {
            _productRepository = productRepository;
            _statusCache = statusCache;
            _discountService = discountService;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                return null;
            }

            var discount = await _discountService.GetDiscountAsync(product.ProductId);
            var statusName = _statusCache.GetStatusName(product.Status);

            return new ProductDTO
            {
                ProductId = product.ProductId,
                Name = product.Name,
                StatusName = statusName,
                Stock = product.Stock,
                Description = product.Description,
                Price = product.Price,
                Discount = discount
            };
        }


    }
}
