using Ardalis.ApiEndpoints;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Product_Micro.Core.ProductAggregate;
using Product_Micro.Core.ProductAggregate.Specifications;
using Product_Micro.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class GetByIds : EndpointBaseAsync
  .WithRequest<GetByIdsProductRequest>
  .WithActionResult<GetByIdsProductResponse>
{
  private readonly IRepository<Product> _repository;

  public GetByIds(IRepository<Product> repository)
  {
    _repository = repository;
  }

  [HttpPost(GetByIdsProductRequest.Route)]
  [SwaggerOperation(
    Summary = "Get products by ids",
    Description = "Get products by ids",
    OperationId = "product.getbyids",
    Tags = new[] { "ProductEndpoints" })
  ]
  public override async Task<ActionResult<GetByIdsProductResponse>> HandleAsync(GetByIdsProductRequest request, CancellationToken cancelattionToken = new())
  {
    GetByIdsProductRequestValidator validator = new();
    ValidationResult resultValidation = await validator.ValidateAsync(request, cancelattionToken);
    if(!resultValidation.IsValid)
      return BadRequest(resultValidation.Errors);

    ProductsByIdsSpec spec = new(request.ProductIds);
    List<Product> result = await _repository.ListAsync(spec, cancelattionToken);
    if(result == null)
      return NotFound();
    GetByIdsProductResponse response = new();
    response.Products = result.Select(x => new ProductRecord(x.Id, x.Name, x.Price)).ToList();
    return Ok(response);
  }
}
