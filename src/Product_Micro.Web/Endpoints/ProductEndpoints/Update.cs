using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Product_Micro.Core.ProductAggregate;
using Product_Micro.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class Update : EndpointBaseAsync
  .WithRequest<UpdateProductRequest>
  .WithActionResult<UpdateProductResponse>
{
  private readonly IRepository<Product> _repository;

  public Update(IRepository<Product> repository)
  {
    _repository = repository;
  }
  [HttpPut(UpdateProductRequest.Route)]
  [SwaggerOperation(
    Summary = "Update a product",
    Description = "Update a product",
    OperationId = "product.update",
    Tags = new[] { "ProductEndpoints"  }
  )]
  public override async Task<ActionResult<UpdateProductResponse>> HandleAsync(UpdateProductRequest request, CancellationToken cancellationToken = new())
  {
    var existingProduct = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (existingProduct == null)
      return NotFound();

    existingProduct.Update(request.Name, request.Price);

    await _repository.UpdateAsync(existingProduct, cancellationToken);
    UpdateProductResponse response = new(
      new ProductRecord(existingProduct.Id, existingProduct.Name, existingProduct.Price)
      );
    return Ok(response);
  }
}
