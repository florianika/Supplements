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
        P0250 = 1, //Four_years_and_above_
        P0266 = 2, //Infants_children_12M_
        P0192 = 3, //Children_12M_4Y_
        P0253 = 4 //Pregnant_lactating_women_
    }
}