using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Product_Micro.Core.ProductAggregate.Specifications;
public class ProductsByIdsSpec : Specification<Product>, ISingleResultSpecification
{
  public ProductsByIdsSpec(List<int> ProductsIds)
  {
    Query.Where(product => ProductsIds.Contains(product.Id));
  }
}
