using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplementApi.Filters
{
    public class IngredientCategoryFilter
    {
        public IngredientCategory IngredientCategoryName { get; set; }
    }

    public enum IngredientCategory
    {
        no_category = 0,
        vitamin = 1,
        mineral = 2,
        amino_acid = 3,
        animal_part_source = 4,
        bacteria = 5,
        blend = 6,
        botanical = 7,
        carbohydrate = 8,
        chemical = 9,
        element = 10,
        enzyme = 11,
        fat = 12,
        Fatty_Acid = 13,
        fiber = 14,
        header = 15, 
        hormone = 16,
        other = 17,
        polysaccharide = 18,
        protein = 19,
        tbd = 20


    }
}