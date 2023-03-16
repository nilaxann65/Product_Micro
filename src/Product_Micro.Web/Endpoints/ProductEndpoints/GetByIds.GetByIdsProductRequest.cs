namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class GetByIdsProductRequest
{
  public const string Route = "/Products";
  public List<int> ProductIds { get; set; } = new List<int>();
}
