﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SupplementApi.ApiModel;
using SupplementApi.Models;
using SupplementApi.FilterViewModels;
using SupplementApi.Filters;


namespace SupplementApi.Controllers
{
    public class ProductApiController : ApiController
    {
        SupplementModel db = new SupplementModel();
        // GET: api/ProductApi
        public List<ApiModel.Product> Get()
        {
            List<Models.Product> mProducts = db.Products.ToList();
            List<ApiModel.Product> products = new List<ApiModel.Product>();
            foreach (Models.Product mProduct in mProducts)
            {
                ApiModel.Product product = MapModel.MapProduct(mProduct);
                products.Add(product);
            }
            return products;
        }

        // GET: api/ProductApi/5
        public ApiModel.Product Get(int id)
        {
            Models.Product mProduct = db.Products.Single(p => p.Id == id);
            ApiModel.Product product = MapModel.MapProduct(mProduct);

            return product;
        }

        // POST: api/ProductApi
        [HttpPost]
        public List<ApiModel.Product> Post(ProductFilterViewModel model)
        {

            List<Models.Product> mProducts = new List<Models.Product>();
            //This list is returned instead of Models.Product to avoid circular reference
            //ApiMode.Product is a mapped model of Model.Product to be use for api json porposes
            List<ApiModel.Product> returnProducts = new List<ApiModel.Product>();
            IQueryable<Models.Product> filteredProducts = null;
            filteredProducts = SupplementQueryFilter.ProductIngredientFilter(model, filteredProducts, db);
            //ProductName filter
            filteredProducts = SupplementQueryFilter.ProductNameFilter(model, filteredProducts, db);

            //IngredientCategory filter
            //TODO check this
            filteredProducts = SupplementQueryFilter.IngredientCategoryFilter(model, filteredProducts, db);
            //ProductType filter
            filteredProducts = SupplementQueryFilter.ProductTypeFilter(model, filteredProducts, db);

            //Supplement Form filter
            filteredProducts = SupplementQueryFilter.SupplementFormFilter(model, filteredProducts, db);

            //TargetGroup filtesr
            filteredProducts = SupplementQueryFilter.TargetGroupFilter(model, filteredProducts, db);

            //Dietary claim filter
            filteredProducts = SupplementQueryFilter.DietaryClaimFilter(model, filteredProducts, db);

            if (filteredProducts != null)
            {
                
                foreach (Models.Product product in filteredProducts.OrderBy(p => p.Priority))
                {
                    returnProducts.Add(MapModel.MapProduct(product));
                }
            }

            return returnProducts;
        }

        // PUT: api/ProductApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductApi/5
        public void Delete(int id)
        {
        }
    }
}
