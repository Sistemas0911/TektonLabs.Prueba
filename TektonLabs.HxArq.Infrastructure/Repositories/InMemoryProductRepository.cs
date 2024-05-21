using System.Collections.Concurrent;
using TektonLabs.HxArq.Domain.Entities;
using TektonLabs.HxArq.Domain.Interfaces;

namespace TektonLabs.HxArq.Infrastructure.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private static ConcurrentDictionary<int, ProductEntity> _products = new();

        public Task<ProductEntity> GetByIdAsync(int productId)
        {
            _products.TryGetValue(productId, out var product);
            return Task.FromResult(product);
        }

        public Task AddAsync(ProductEntity product)
        {
            _products[product.ProductId] = product;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(ProductEntity product)
        {
            _products[product.ProductId] = product;
            return Task.CompletedTask;
        }
    }
}
