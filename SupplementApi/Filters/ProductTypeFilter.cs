using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplementApi.Filters
{
    public class ProductTypeFilter
    {
        public ProductType ProductTypeNameFilter  { get; set; }
    }

    public enum ProductType
    {
        A1317 = 1, //BOTANICAL_SUPPELMENT_WITH_VITAMIN_MINERAL_
        A1305 = 2, //DIETARY_SUPPLEMENT_AMINOACID_PROTEIN_
        A1313 = 3, //DIETARY_SUPPLEMENT_COMBINATION_
        A1325 = 4, //IETARY_SUPPLEMENT_COMBINATION_OTHER_
        A1306 = 5, //DIETARY_SUPPLEMENT_HERBAL_BOTANICAL_
        A1299 = 6, //IETARY_SUPPLEMENT_MINERAL_
        A1309 = 7, //DIETARY_SUPPLEMENT_NONNUTRIENT_NONBOTANICAL_
        A1326 = 8, //DIETARY_SUPPLEMENT_OTHER_NUTRITIVE_
        A1302 = 9, //DIETRAY_SUPPLEMENT_VITAMIN_
        A1310 = 10, //FATTY_ACCID_FAT_OIL_
        A1315 = 11,  //MULTI_VITAMIN_MULTI_MINERAL_
        A1316 = 12 //SINGLE_VITAMIN_SINGLE_MINERAL_
    }
} 