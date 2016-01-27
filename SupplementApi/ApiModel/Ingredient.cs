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
    }
}