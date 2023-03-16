using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Product_Micro.Core.ProductAggregate;
using Product_Micro.Core.ProductAggregate.Specifications;
using Product_Micro.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class GetById :EndpointBaseAsync
  .WithRequest<GetByIdProductRequest>
  .WithActionResult<GetByIdProductResponse>
{
  private readonly IRepository<Product> _repository;

  public GetById(IRepository<Product> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetByIdProductRequest.Route)]
  [SwaggerOperation(
    Summary = "Get a product by id",
    Description = "Get a product by id",
    OperationId = "product.getbyid",
    Tags = new[] { "ProductEndpoints" }
  )]
  public override async Task<ActionResult<GetByIdProductResponse>> HandleAsync( [FromRoute] GetByIdProductRequest request, CancellationToken cancellationToken =new())
  {
    ProductByIdSpec spec = new(request.ProductId);
    var ProductFound = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (ProductFound == null)
      return NotFound();
    GetByIdProductResponse response = new(ProductFound.Id, ProductFound.Name, ProductFound.Price);
    return Ok(response);
  }
}
