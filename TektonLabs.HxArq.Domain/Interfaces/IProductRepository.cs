using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TektonLabs.HxArq.Domain.Entities;

namespace TektonLabs.HxArq.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity> GetByIdAsync(int productId);
        Task AddAsync(ProductEntity product);
        Task UpdateAsync(ProductEntity product);
    }
}
