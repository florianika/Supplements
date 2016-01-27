using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplementApi.Filters
{
    public class SupplementFormFilter
    {
        public SupplementForm SupplementFormNameFilter { get; set; }
    }

    public enum SupplementForm
    {
        E0164 = 1, //BAR_
        E0159 = 2, //CAPSULE_
        E0176 = 3, //GUMMY_
        E0165 = 4, //LIQUID_
        E0174 = 5, //LOZENGE_
        E0162 = 6, //POWDER_
        E0161 = 7, //SOFTGL_CAPSULE_
        E0172 = 8, //OTHER_
        E0177 = 9, //UNKNOWN_
        E0155 = 10 //TABLET_

    }
}