using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplementApi.ApiModel
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Producer ProductProducer { get; set; }
        public SupplementForm ProductSupplementForm { get; set; }
        public Type ProductType { get; set; }
        public TargetGroup ProductTargetGroup { get; set; }
        public DietaryClaim ProductDietaryClaim { get; set; }
        public List<Ingredient> Ingredients  { get; set; }
        public int Priority { get; set; }

    }
}