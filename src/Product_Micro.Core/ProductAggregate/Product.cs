
using Ardalis.GuardClauses;
using MediatR;
using Product_Micro.SharedKernel;
using Product_Micro.SharedKernel.Interfaces;

namespace Product_Micro.Core.ProductAggregate;
public class Product : EntityBase, IAggregateRoot
{
  public string Name { get; private set; }
  public decimal Price { get; private set; }
  public Product(string name, decimal price)
  {
    Name = Guard.Against.NullOrEmpty(name);
    Price = price;
  }
  public void Update(string name, decimal price)
  {
    Name = Guard.Against.NullOrEmpty(name);
    Price = price;
  }
}
