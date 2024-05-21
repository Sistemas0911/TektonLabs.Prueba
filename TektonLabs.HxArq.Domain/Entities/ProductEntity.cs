using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TektonLabs.HxArq.Domain.Entities
{
    public class ProductEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; } // 0: Inactive, 1: Active
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
