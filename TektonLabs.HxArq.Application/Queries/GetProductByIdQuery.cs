using MediatR;
using TektonLabs.HxArq.Application.Dtos;

namespace TektonLabs.HxArq.Application.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public int ProductId { get; set; }
    }
}
