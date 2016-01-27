using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SupplementApi.Filters;

namespace SupplementApi.ViewModels
{
    public class ProductViewModel
    {
        public List<IngredientFilter> IngredientFilters { get; set; }
        public List<IngredientCategoryFilter> IngredientCategoryFilters { get; set; }
        public List<ProductNameFilter> ProductNameFilters { get; set; }
        public List<ProductTypeFilter> ProductTypeFilters { get; set; }
        public List<TargetGroupFilter> TargetGroupFilters { get; set; }
        public List<SupplementFormFilter> SupplementFormFilters { get; set; }
        public List<DietaryClaimFilter> DietaryClaimFilters { get; set; }

    }
}