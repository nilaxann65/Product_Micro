namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class GetByIdProductRequest
{
  public const string Route = "/Products/{ProductId:int}";
  public static string BuildRoute(int ProductId) => Route.Replace("{ProductId:int}", ProductId.ToString());
  public int ProductId { get; set; }
}
