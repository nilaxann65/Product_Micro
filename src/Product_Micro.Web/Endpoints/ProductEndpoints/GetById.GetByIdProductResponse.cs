namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class GetByIdProductResponse
{
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public decimal Price { get; set; }

  public GetByIdProductResponse(int id, string name, decimal price)
  {
    Id = id;
    Name = name;
    Price = price;
  }
}
