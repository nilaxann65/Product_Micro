using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Product_Micro.Core.ProductAggregate;
using Product_Micro.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class Delete : EndpointBaseAsync
  .WithRequest<DeleteProductRequest>
  .WithoutResult
{
  private readonly IRepository<Product> _repository;

  public Delete(IRepository<Product> repository)
  {
    _repository = repository;
  }


  [HttpDelete(DeleteProductRequest.Route)]
  [SwaggerOperation(
    Summary = "Delete a product",
    Description = "Delete a product",
    OperationId = "product.delete",
    Tags = new[] { "ProductEndpoints" }
  )]
  public override async Task<ActionResult> HandleAsync([FromRoute] DeleteProductRequest request, CancellationToken cancellationToken = new())
  {
    var productToDelete = await _repository.GetByIdAsync(request.ProductId, cancellationToken);
    if (productToDelete == null)
      return NotFound(request.ProductId);

    await _repository.DeleteAsync(productToDelete, cancellationToken);
    return Ok(request.ProductId);
  }
}
