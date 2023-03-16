using Microsoft.Identity.Client;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class CreateProductResponse
{
  public int Id { get; set; }
  public string Name { get; set; }
  public decimal Price { get; set; }

  public CreateProductResponse(int id, string name, decimal price)
  {
    Id = id;
    Name = name;
    Price = price;
  }
}
