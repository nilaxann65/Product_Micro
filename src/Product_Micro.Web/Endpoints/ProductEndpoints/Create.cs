using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Product_Micro.Core.ProductAggregate;
using Product_Micro.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class Create : EndpointBaseAsync
  .WithRequest<CreateProductRequest>
  .WithActionResult<CreateProductResponse>
{
  private readonly IRepository<Product> _repository;

  public Create(IRepository<Product> repository)
  {
    _repository = repository;
  }
  [HttpPost(CreateProductRequest.Route)]
  [SwaggerOperation(
    Summary = "Create a new product",
    Description = "Create a new product",
    OperationId = "product.create",
    Tags = new[] { "ProductEndpoints" })
  ]
  public override async Task<ActionResult<CreateProductResponse>> HandleAsync(CreateProductRequest request, CancellationToken cancellationToken)
  {
    CreateProductRequestValidator validator = new();
    var result = validator.Validate(request);
    if(result.Errors.Count != 0)
    {
      List<string> errors = result.Errors.Select(x => x.PropertyName + " : " + x.ErrorMessage).ToList();
      return BadRequest(new
      {
        Message = "Formato incorrecto",
        Errors = errors
      }); 
    }

    Product newProduct = new(request.Name, request.Price);
    Product createdProduct = await _repository.AddAsync(newProduct, cancellationToken);
    CreateProductResponse response = new(createdProduct.Id, createdProduct.Name, createdProduct.Price);
    return Ok(response);
  }
}
