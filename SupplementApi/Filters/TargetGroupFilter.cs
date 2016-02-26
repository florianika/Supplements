using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplementApi.Filters
{
    public class TargetGroupFilter
    {
        public TargetGroup TargetGroupNameFilter { get; set; }
    }

    public enum TargetGroup
    {
        P0192 = 1, //Infants/Children  <12 mths
        P0250 = 2, //Children 12 mths - < 4 years
        P0253 = 3, //4 years - 16 Years
        P0266 = 4, //16 Years - 45 Years
        P0267 = 5, //45 Years and above
        P0268 = 6 //Pregnant and lactating waman


    }
}