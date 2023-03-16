using FluentValidation;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>{
    public UpdateProductRequestValidator(){
        RuleFor(r => r.Id).GreaterThan(0).WithMessage("El id debe ser mayor a 0.");
        RuleFor(r => r.Name).NotEmpty().WithMessage("Debes ingresar texto en este campo.");
        RuleFor(r => r.Price).GreaterThan(5).WithMessage("El valor debe ser mayor a 5");
    }
}