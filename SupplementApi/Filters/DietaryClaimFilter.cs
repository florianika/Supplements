using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplementApi.Filters
{
    public class DietaryClaimFilter
    {
        public DietayClaim DietaryClaimNameFilter { get; set; }
    }

    public enum DietayClaim
    {
        HEALTH_RELATED_CLAIM_OR_USE_P0124 = 1,
        NO_DIETARY_CLAIM_OR_USE_P0276 = 2,
        NUTRATION_RELATED_CLAIM_OR_USE_P0065 = 3,
        CONSTITUENT_RELATED_CLAIM_OR_USE_P0115 = 4,
        QUALIFIED_HEALTH_CLAIM_P0264 = 5,
        STRUCTURE_FUNCTION_CLAIM_P0265 = 6
    }
}