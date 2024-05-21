using FluentValidation;
using TektonLabs.HxArq.Application.Commands;

namespace TektonLabs.HxArq.Application.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("El ID del producto debe ser mayor que cero.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre del producto no puede estar vacío.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("El precio del producto debe ser mayor que cero.");
            RuleFor(x => x.Status).InclusiveBetween(0, 1).WithMessage("El estado del producto debe ser 0 o 1.");
        }
    }
}
