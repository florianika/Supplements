using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplementApi.Filters
{
    public class IngredientFilter
    {
        public LikeOpt NameLikeOperator { get; set; }
        public string IngredientName { get; set; }
        public QuantityOpt QuantityOperator { get; set; }
        public float IngredientQuantity { get; set; }
        public Unit IngredientUnit { get; set; }
    }

    //json example:
   //{
   //     NameLikeOpertaor: 1,
   //     IngredientName: "Vitmin C",
   //     QuantityOpertar: 1,
   //     IngredientQuantity: 10,
   //     IngredientUnit: 2
   //}


    public enum LikeOpt
    {
        must_include = 1,
        may_include = 2,
        exclude = 3,
        begins_with = 4
    }

    public enum QuantityOpt
    {
        geq = 1,
        gt = 2,
        eq = 3,
        leq = 4,
        lt = 5   
    }

    public enum Unit
    {
        g = 1,
        mg = 2,
        µg = 3
    }


}