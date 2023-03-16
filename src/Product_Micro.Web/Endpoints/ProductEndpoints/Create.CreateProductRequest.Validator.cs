using FluentValidation;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
  public CreateProductRequestValidator()
  {
    RuleFor(r => r.Name).NotEmpty().WithMessage("Debes ingresar texto en este campo.");
    RuleFor(r => r.Price).GreaterThan(5).WithMessage("El valor debe ser mayor a 5");
  }
}
