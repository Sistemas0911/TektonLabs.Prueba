using MediatR;

namespace TektonLabs.HxArq.Application.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
