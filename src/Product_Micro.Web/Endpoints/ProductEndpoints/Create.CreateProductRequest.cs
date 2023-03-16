using FluentValidation;
using Microsoft.Build.Framework;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class CreateProductRequest
{
  public const string Route = "/Products/Create";
  public string Name { get; set; } = null!;
  public decimal Price { get; set; }
}


