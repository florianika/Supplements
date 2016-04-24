using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SupplementApi.Models;

namespace SupplementApi.ApiModel
{
    //This class is important to map DB model with the api response model
    //db model is complicated to be returned as json 
    //and gives reference loop
    //the api it will be exclusive to Products
    public static class MapModel
    {

        public static Product MapProduct(Models.Product mProduct)
        {
            Product product = new Product();
            product.Id = mProduct.Id;
            product.Name = mProduct.Name;
            product.Description = mProduct.Description;
            Producer producer = MapProducer(mProduct);
            product.ProductProducer = producer;
            SupplementForm supplementForm = MapSupplementForm(mProduct);
            product.ProductSupplementForm = supplementForm;
            Type type = MapType(mProduct);
            product.ProductType = type;
            TargetGroup targetGroup = MapTargetGroup(mProduct);
            product.ProductTargetGroup = targetGroup;
            DietaryClaim dietaryClaim = MapDietaryClaim(mProduct);
            product.ProductDietaryClaim = dietaryClaim;
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (Models.ProductIngredient productIngredient in mProduct.PruductIngredients)
            {               
                Ingredient ingredient = MapIngredient(productIngredient);
                ingredients.Add(ingredient);    
            }
            product.Ingredients = ingredients;
            product.Priority = mProduct.Priority;
            return product;
        }

        private static Ingredient MapIngredient(Models.ProductIngredient productIngredient)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Id = productIngredient.Ingredient.Id;
            ingredient.Name = productIngredient.Ingredient.Name;
            ingredient.Description = productIngredient.Ingredient.Description;
            ingredient.IngredientValue = productIngredient.Value;
            Category category = MapCategory(productIngredient);
            ingredient.IngredientCategory = category;
            Unit unit =  MapUnit(productIngredient);
            ingredient.IngredientUnit = unit;
            if (productIngredient.IdIngredient2 != null)
            {
                ingredient.Id2 = productIngredient.IdIngredient2;
                ingredient.Name2 = productIngredient.Ingredient2.Name;
                ingredient.Description2 = productIngredient.Ingredient2.Description;
                ingredient.Ingredient2Value = productIngredient.Value2;
            }
            return ingredient;
        }

        private static Unit MapUnit(Models.ProductIngredient productIngredient)
        {
            Unit unit = new Unit();
            unit.Id = productIngredient.Unit1.Id;
            unit.Name = productIngredient.Unit1.Name;
            unit.Description = productIngredient.Unit1.Description;
            return unit;
        }

        private static Category MapCategory(Models.ProductIngredient productIngredient)
        {
            Category category = new Category();
            category.Id = productIngredient.Ingredient.IngredientCategory.Id;
            category.Name = productIngredient.Ingredient.IngredientCategory.Name;
            category.Description = productIngredient.Ingredient.IngredientCategory.Description;
            return category;
        }

        private static Producer MapProducer(Models.Product mProduct)
        {
            Producer producer = new Producer();
            producer.Id = mProduct.Producer1.Id;
            producer.Name = mProduct.Producer1.Name;
            producer.Address = mProduct.Producer1.Address;
            producer.Telephone = mProduct.Producer1.Telephone;
            producer.Email = mProduct.Producer1.Email;
            producer.Website = mProduct.Producer1.Website;
            return producer;
        }

        private static SupplementForm MapSupplementForm(Models.Product mProduct)
        {
            ApiModel.SupplementForm supplementForm = new ApiModel.SupplementForm();
            supplementForm.Id = mProduct.SupplementForm.Id;
            supplementForm.Name = mProduct.SupplementForm.Name;
            supplementForm.Description = mProduct.SupplementForm.Description;
            return supplementForm;
        }

        private static Type MapType(Models.Product mProduct)
        {
            Type type = new Type();
            type.Id = mProduct.ProductType.Id;
            type.Name = mProduct.ProductType.Name;
            type.Description = mProduct.ProductType.Description;
            return type;
        }

        private static TargetGroup MapTargetGroup(Models.Product mProduct)
        {
            TargetGroup targetGroup = new TargetGroup();
            targetGroup.Id = mProduct.TargetGroup.Id;
            targetGroup.Name = mProduct.TargetGroup.Name;
            targetGroup.Description = mProduct.TargetGroup.Description;
            return targetGroup;
        }

        private static DietaryClaim MapDietaryClaim(Models.Product mProduct)
        {
            DietaryClaim dietaryClaim = new DietaryClaim();
            dietaryClaim.Id = mProduct.DietaryClaim.Id;
            dietaryClaim.Name = mProduct.DietaryClaim.Name;
            dietaryClaim.Description = mProduct.DietaryClaim.Description;
            return dietaryClaim;
        }

    }
}