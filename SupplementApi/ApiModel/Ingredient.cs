using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplementApi.ApiModel
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category IngredientCategory { get; set; }
        public float? IngredientValue { get; set; }
        public Unit IngredientUnit { get; set; }
        //for the second ingredient that is part of the first ingredient
        public int? Id2 { get; set; }
        public string Name2 { get; set; }
        public string Description2 { get; set; }
        public float? Ingredient2Value { get; set; }

    }
}