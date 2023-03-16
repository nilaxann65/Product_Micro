using System.ComponentModel.DataAnnotations;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class DeleteProductRequest
{
  public const string Route = "/Products/{ProductId:int}";
  public static string BuildRoute(int ProductId) => Route.Replace("{ProductId:int}", ProductId.ToString());
  [Required]
  public int ProductId { get; set; }
}
