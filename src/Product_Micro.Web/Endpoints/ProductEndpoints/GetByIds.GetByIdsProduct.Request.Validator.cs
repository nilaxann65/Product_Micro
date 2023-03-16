using FluentValidation;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class GetByIdsProductRequestValidator : AbstractValidator<GetByIdsProductRequest>
{
  public GetByIdsProductRequestValidator()
  {
    RuleFor(r => r.ProductIds).NotEmpty().WithMessage("Debes ingresar al menos un id de producto.");
    RuleFor(r => r.ProductIds).Must(x => x.Count() <= 10).WithMessage("No puedes ingresar más de 10 ids de productos.");
    RuleFor(r => r.ProductIds).Must(x => x.All(y => y > 0)).WithMessage("Los ids de productos deben ser mayores a 0.");
    RuleFor(r => r.ProductIds).Must(x => x.Distinct().Count() == x.Count()).WithMessage("No puedes ingresar ids de productos repetidos.");
  }
}