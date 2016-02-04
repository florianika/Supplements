using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SupplementApi.ViewModels;
using SupplementApi.Models;

namespace SupplementApi.Filters
{
    public class SupplementQueryFilter
    {
        public static IQueryable<Models.Product> DietaryClaimFilter(ProductViewModel model, IQueryable<Models.Product> filteredProducts, SupplementModel db)
        {
            if (model.DietaryClaimFilters != null && model.DietaryClaimFilters.Count > 0)
            {
                if (filteredProducts == null)
                {
                    filteredProducts = db.Products;
                }
                List<string> dietaryClaims = new List<string>();
                foreach (DietaryClaimFilter dietaryClaimFilter in model.DietaryClaimFilters)
                {
                    string dc = dietaryClaimFilter.DietaryClaimNameFilter.ToString();
                    dietaryClaims.Add(dc.Substring(dc.LastIndexOf('_') + 1));
                }
                filteredProducts = filteredProducts.Where(p => dietaryClaims.Contains(p.DietaryClaimId));
            }

            return filteredProducts;
        }



        public static IQueryable<Models.Product> TargetGroupFilter(ProductViewModel model, IQueryable<Models.Product> filteredProducts, SupplementModel db)
        {
            if (model.TargetGroupFilters != null && model.TargetGroupFilters.Count > 0 && (int)model.TargetGroupFilters[0].TargetGroupNameFilter != 0)
            {
                if (filteredProducts == null)
                {
                    filteredProducts = db.Products;
                }

                List<string> targetGroup = new List<string>();
                foreach (TargetGroupFilter targetGroupFilter in model.TargetGroupFilters)
                {
                    string tf = targetGroupFilter.TargetGroupNameFilter.ToString();
                    targetGroup.Add(tf);
                }
                filteredProducts = filteredProducts.Where(p => targetGroup.Contains(p.TargetGroupId));
            }

            return filteredProducts;
        }

        

        public static IQueryable<Models.Product> SupplementFormFilter(ProductViewModel model, IQueryable<Models.Product> filteredProducts, SupplementModel db)
        {
            if (model.SupplementFormFilters != null && model.SupplementFormFilters.Count > 0 && (int)model.SupplementFormFilters[0].SupplementFormNameFilter != 0)
            {
                if (filteredProducts == null)
                {
                    filteredProducts = db.Products;
                }

                List<string> supplementForm = new List<string>();
                foreach (SupplementFormFilter supplementFormFilter in model.SupplementFormFilters)
                {
                    string sf = supplementFormFilter.SupplementFormNameFilter.ToString();
                    supplementForm.Add(sf);
                }
                filteredProducts = filteredProducts.Where(p => supplementForm.Contains(p.SupplementFormId));
            }

            return filteredProducts;
        }

        public static IQueryable<Models.Product> ProductTypeFilter(ProductViewModel model, IQueryable<Models.Product> filteredProducts, SupplementModel db)
        {
            if (model.ProductTypeFilters != null && model.ProductTypeFilters.Count > 0 && (int)model.ProductTypeFilters[0].ProductTypeNameFilter != 0)
            {
                if (filteredProducts == null)
                {
                    filteredProducts = db.Products;
                }

                List<string> productType = new List<string>();
                foreach (ProductTypeFilter productTypeFilter in model.ProductTypeFilters)
                {
                    string pt = productTypeFilter.ProductTypeNameFilter.ToString();
                    productType.Add(pt);
                }
                
                filteredProducts = filteredProducts.Where(p => productType.Contains(p.TypeId));
            }

            return filteredProducts;
        }


        public static IQueryable<Product> IngredientCategoryFilter(ProductViewModel model, IQueryable<Product> filteredProducts, SupplementModel db)
        {
            if (model.IngredientCategoryFilters != null
                && model.IngredientCategoryFilters.Count > 0 
                && (model.IngredientCategoryFilters[0].IngredientCategoryName.ToString() != "" 
                && model.IngredientCategoryFilters[0].IngredientCategoryName.ToString() != "no_category"))
            {
                //if (joinedProductIngredients == null)
                //{
                //    joinedProductIngredients = db.ProductIngredients;
                //}
                if (filteredProducts == null)
                {
                    filteredProducts = db.Products;
                }
                List<int> listOfCategoryIngredients = new List<int>();
                foreach (IngredientCategoryFilter item in model.IngredientCategoryFilters)
                {
                    listOfCategoryIngredients.Add((int)item.IngredientCategoryName);
                }

                filteredProducts = filteredProducts.Where(fp => fp.PruductIngredients.Any(pi => listOfCategoryIngredients.Contains(pi.Ingredient.IngredientCategory.Id)));
                //TODO check this
                //joinedProductIngredients = joinedProductIngredients.Where(pi => listOfCategoryIngredients.Contains(pi.Ingredient.IngredientCategory.Id));
               
            }

            return filteredProducts;
        }

        public static IQueryable<Models.Product> ProductNameFilter(ProductViewModel model, IQueryable<Models.Product> filteredProducts, SupplementModel db)
        {
            if (model.ProductNameFilters != null && model.ProductNameFilters.Count > 0 && model.ProductNameFilters[0].ProductName != "")
            {
                if (filteredProducts == null)
                {
                    filteredProducts = db.Products;
                }

                foreach (ProductNameFilter productNameFilter in model.ProductNameFilters)
                {
                    switch (productNameFilter.ProductNameLikeOperator)
                    {
                        case LikeOpt.must_include:
                            filteredProducts = filteredProducts.Where(p => p.Name == productNameFilter.ProductName);
                            break;
                        case LikeOpt.may_include:
                            filteredProducts = filteredProducts.Where(p => p.Name.Contains(productNameFilter.ProductName));
                            break;
                        case LikeOpt.exclude:
                            filteredProducts = filteredProducts.Where(p => p.Name != productNameFilter.ProductName);
                            break;
                        case LikeOpt.begins_with:
                            filteredProducts = filteredProducts.Where(p => p.Name.StartsWith(productNameFilter.ProductName));
                            break;
                        default:
                            break;
                    }
                }
            }

            return filteredProducts;
        }

        internal static IQueryable<Product> ProductIngredientFilter(ProductViewModel model, IQueryable<Product> filteredProducts, SupplementModel db)
        {
            if (filteredProducts == null)
            {
                filteredProducts = db.Products;
            }
            foreach (IngredientFilter filter in model.IngredientFilters)
            {
                switch (filter.NameLikeOperator)
                {
                    case LikeOpt.must_include:
                        switch (filter.QuantityOperator)
                        {
                            case QuantityOpt.geq:
                                filteredProducts = filteredProducts.Where(fp => 
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name == filter.IngredientName 
                                                          && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                          && pi.Value >= filter.IngredientQuantity));
                                break;
                            case QuantityOpt.gt:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name == filter.IngredientName
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value > filter.IngredientQuantity));
                                break;
                            case QuantityOpt.eq:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name == filter.IngredientName
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value == filter.IngredientQuantity));
                                break;
                            case QuantityOpt.leq:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name == filter.IngredientName
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value <= filter.IngredientQuantity));
                                break;
                            case QuantityOpt.lt:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name == filter.IngredientName
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value < filter.IngredientQuantity));
                                break;
                            default:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name == filter.IngredientName));
                                break;
                        }
                        
                        break;
                    case LikeOpt.may_include:

                        switch (filter.QuantityOperator)
                        {
                            case QuantityOpt.geq:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.Contains(filter.IngredientName)
                                                          && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                          && pi.Value >= filter.IngredientQuantity));
                                break;
                            case QuantityOpt.gt:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.Contains(filter.IngredientName)
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value > filter.IngredientQuantity));
                                break;
                            case QuantityOpt.eq:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.Contains(filter.IngredientName)
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value == filter.IngredientQuantity));
                                break;
                            case QuantityOpt.leq:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.Contains(filter.IngredientName)
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value == filter.IngredientQuantity));
                                break;
                            case QuantityOpt.lt:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.Contains(filter.IngredientName)
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value <= filter.IngredientQuantity));
                                break;
                            default:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.Contains(filter.IngredientName)));
                                break;
                        }
                        break;
                    case LikeOpt.exclude:
                        filteredProducts = filteredProducts.Where(fp => fp.PruductIngredients.Any(pi => !pi.Ingredient.Name.Contains(filter.IngredientName)));
                        break;
                    case LikeOpt.begins_with:
                        switch (filter.QuantityOperator)
                        {
                            case QuantityOpt.geq:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.StartsWith(filter.IngredientName)
                                                          && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                          && pi.Value >= filter.IngredientQuantity));
                                break;
                            case QuantityOpt.gt:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.StartsWith(filter.IngredientName)
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value > filter.IngredientQuantity));
                                break;
                            case QuantityOpt.eq:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.StartsWith(filter.IngredientName)
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value == filter.IngredientQuantity));
                                break;
                            case QuantityOpt.leq:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.StartsWith(filter.IngredientName)
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value == filter.IngredientQuantity));
                                break;
                            case QuantityOpt.lt:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.StartsWith(filter.IngredientName)
                                                         && pi.Unit1.Name == filter.IngredientUnit.ToString()
                                                         && pi.Value <= filter.IngredientQuantity));
                                break;
                            default:
                                filteredProducts = filteredProducts.Where(fp =>
                                fp.PruductIngredients.Any(pi => pi.Ingredient.Name.StartsWith(filter.IngredientName)));
                                break;
                        }
                        filteredProducts = filteredProducts.Where(fp => fp.PruductIngredients.Any(pi => pi.Ingredient.Name.StartsWith(filter.IngredientName)));
                        break;
                    default:
                        break;
                }

                
            }
            return filteredProducts;
        }

        public static void IngredientFilter(ProductViewModel model, ref IQueryable<ProductIngredient> includedProductIngredients, ref IQueryable<ProductIngredient> excludedProductIngredients, SupplementModel db)
        {
            if (model.IngredientFilters != null)//vazhdo pak me f10 se une nuk e shtyp dot
            {
                foreach (IngredientFilter filter in model.IngredientFilters)
                {
                    //TODO find a better way to build the linq query
                    //the one implementit is resource consuming and slow
                    //but it works somehow
                    //too complicated if more filters are added

                    switch (filter.NameLikeOperator)
                    {
                        case LikeOpt.must_include:
                            if (includedProductIngredients == null)
                            {
                                includedProductIngredients = db.ProductIngredients;
                            }
                            includedProductIngredients = includedProductIngredients.Where(pi => pi.Ingredient.Name == filter.IngredientName);
                            break;
                        case LikeOpt.may_include:
                            if (includedProductIngredients == null)
                            {
                                includedProductIngredients = db.ProductIngredients;
                            }
                            includedProductIngredients = includedProductIngredients.Where(pi => pi.Ingredient.Name.Contains(filter.IngredientName));
                            break;
                        case LikeOpt.exclude:
                            if (excludedProductIngredients == null)
                            {
                                excludedProductIngredients = db.ProductIngredients;
                            }
                            excludedProductIngredients = excludedProductIngredients.Where(pi => pi.Ingredient.Name.Contains(filter.IngredientName));
                            break;
                        case LikeOpt.begins_with:
                            if (includedProductIngredients == null)
                            {
                                includedProductIngredients = db.ProductIngredients;
                            }
                            includedProductIngredients = includedProductIngredients.Where(pi => pi.Ingredient.Name.StartsWith(filter.IngredientName));
                            break;
                        default:
                            break;
                    }

                    switch (filter.QuantityOperator)
                    {
                        case QuantityOpt.geq:
                            if (filter.NameLikeOperator != LikeOpt.exclude)
                            {
                                includedProductIngredients = includedProductIngredients.Where(pi => pi.Value >= filter.IngredientQuantity
                                && pi.Unit1.Name == filter.IngredientUnit.ToString());
                            }
                            else
                            {
                                excludedProductIngredients = excludedProductIngredients.Where(pi => pi.Value >= filter.IngredientQuantity
                                && pi.Unit1.Name == filter.IngredientUnit.ToString());
                            }
                            break;
                        case QuantityOpt.gt:
                            if (filter.NameLikeOperator != LikeOpt.exclude)
                            {
                                includedProductIngredients = includedProductIngredients.Where(pi => pi.Value >= filter.IngredientQuantity
                                && pi.Unit1.Name == filter.IngredientUnit.ToString());
                            }
                            else
                            {
                                excludedProductIngredients = excludedProductIngredients.Where(pi => pi.Value >= filter.IngredientQuantity
                                && pi.Unit1.Name == filter.IngredientUnit.ToString());
                            }
                            break;
                        case QuantityOpt.eq:
                            if (filter.NameLikeOperator != LikeOpt.exclude)
                            {
                                includedProductIngredients = includedProductIngredients.Where(pi => pi.Value == filter.IngredientQuantity
                                && pi.Unit1.Name == filter.IngredientUnit.ToString());
                            }
                            else
                            {
                                excludedProductIngredients = excludedProductIngredients.Where(pi => pi.Value == filter.IngredientQuantity
                                && pi.Unit1.Name == filter.IngredientUnit.ToString());
                            }
                            break;
                        case QuantityOpt.leq:
                            if (filter.NameLikeOperator != LikeOpt.exclude)
                            {
                                includedProductIngredients = includedProductIngredients.Where(pi => pi.Value <= filter.IngredientQuantity
                                && pi.Unit1.Name == filter.IngredientUnit.ToString());
                            }
                            else
                            {
                                excludedProductIngredients = excludedProductIngredients.Where(pi => pi.Value <= filter.IngredientQuantity
                                && pi.Unit1.Name == filter.IngredientUnit.ToString());
                            }
                            break;
                        case QuantityOpt.lt:
                            if (filter.NameLikeOperator != LikeOpt.exclude)
                            {
                                includedProductIngredients = includedProductIngredients.Where(pi => pi.Value < filter.IngredientQuantity
                                && pi.Unit1.Name == filter.IngredientUnit.ToString());
                            }
                            else
                            {
                                excludedProductIngredients = excludedProductIngredients.Where(pi => pi.Value < filter.IngredientQuantity
                                && pi.Unit1.Name == filter.IngredientUnit.ToString());
                            }
                            break;
                        default:
                            break;
                    }



                }


                //List<Models.ProductIngredient> pis = productIngredients.ToList();

                //if (filter.QuantityOperator == QuantityOpt.geq)
                //{
                //        List<Models.ProductIngredient> productIngredients = (from pIngredients in db.ProductIngredients
                //                                                             where pIngredients.Ingredient.Name == filter.IngredientName
                //                                                                 && pIngredients.Unit1.Name == filter.IngredientUnit.ToString()
                //                                                             && pIngredients.Value >= filter.IngredientQuantity
                //                                                             select pIngredients).ToList();
                //        foreach (Models.ProductIngredient productIngredient in productIngredients)
                //        {
                //            if (!products.Contains(productIngredient.Product))
                //            {
                //                products.Add(productIngredient.Product);
                //            }
                //        }
                //}
                // }
            }
        }


    }
}