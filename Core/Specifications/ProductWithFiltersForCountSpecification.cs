using Core.Entities;
using Core.SearchAndFilteringDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams)
            : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.Contains(productParams.Search)) &&
            (!productParams.brandId.HasValue || x.ProductBrandId == productParams.brandId) &&
            (!productParams.typeId.HasValue || x.ProductTypeId == productParams.typeId)
        )
        {
        }
    }
}
