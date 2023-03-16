namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class UpdateProductResponse
{
  public ProductRecord Product { get;set; }
  public UpdateProductResponse(ProductRecord product)
  {
    Product = product;
  }
}
