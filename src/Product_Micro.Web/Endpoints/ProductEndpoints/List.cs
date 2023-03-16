using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Product_Micro.Core.ProductAggregate;
using Product_Micro.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class List : EndpointBaseAsync
  .WithoutRequest
  .WithActionResult<ProductListResponse>
{
  private readonly IReadRepository<Product> _repository;

  public List(IReadRepository<Product> repository)
  {
    _repository = repository;
  }
  [HttpGet("/Products")]
  [SwaggerOperation(
    Summary = "List all products",
    Description = "List all products",
    OperationId = "product.list",
    Tags = new[] { "ProductEndpoints" }
  )]
  public override async Task<ActionResult<ProductListResponse>> HandleAsync(CancellationToken cancellationToken = new())
  {
    List<Product> products = await _repository.ListAsync(cancellationToken);

    var response = new ProductListResponse
    {
      Products = products.Select(producto => new ProductRecord(producto.Id, producto.Name, producto.Price)).ToList()
    };
    return Ok(response);
  }
}
