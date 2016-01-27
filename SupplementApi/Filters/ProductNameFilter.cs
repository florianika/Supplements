using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplementApi.Filters
{
    public class ProductNameFilter
    {
        public LikeOpt ProductNameLikeOperator { get; set; }
        public string ProductName { get; set; }
    }
}