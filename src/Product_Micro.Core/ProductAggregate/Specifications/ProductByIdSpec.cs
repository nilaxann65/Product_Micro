using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Product_Micro.Core.ProductAggregate.Specifications;
public class ProductByIdSpec : Specification<Product>, ISingleResultSpecification
{
  public ProductByIdSpec(int ProductId)
  {
    Query.Where(product => product.Id == ProductId);
  }
}
