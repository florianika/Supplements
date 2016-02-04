var app = angular.module("Supplement", []);
   app.controller("QuerySupplement", ["$scope", "$http", function ($scope, $http) {
       
        $scope.nameLikeOperator = '';
        $scope.ingredientName = '';
        $scope.quantityOperator = '';
        $scope.ingredientQuantity = '';
        $scope.ingredientUnit = '';
        $scope.nameLikeOperator2 = '';
        $scope.ingredientName2 = '';
        $scope.quantityOperator2 = '';
        $scope.ingredientQuantit2 = '';
        $scope.ingredientUnit2 = '';
        $scope.nameLikeOperator3 = '';
        $scope.ingredientName3 = '';
        $scope.quantityOperator3 = '';
        $scope.ingredientQuantit3 = '';
        $scope.ingredientUnit3 = '';
        $scope.showFilters = true;
        $scope.ingredientCategory = '';
        $scope.productNameLikeOperator = '';
        $scope.productName = '';
        $scope.productType = '';
        $scope.query = '';
        $scope.supplementForm = '';
        $scope.showLoading = false;
        $scope.secondIngredientFilter = false;
        $scope.thirdIngredientFilter = false;

        $scope.showSecondIngredinetFilter = function () {
            $scope.secondIngredientFilter = true;
        };

        $scope.showThirdIngredinetFilter = function () {
            $scope.thirdIngredientFilter = true;
        };


        $scope.getResults = function () {

            var res = $http.post("/api/ProductApi", $scope.query);
            res.success(function (data, status, headers, config) {
                $scope.supplements = data;
                $scope.showLoading = false;
            });
            res.error(function (data, status, headers, config) {
                alert("failure message: " + JSON.stringify({ data: data }));
            });
        };
       
        $scope.createQuery = function () {
            var jsonQuery = {
                IngredientFilters: [{
                    "NameLikeOperator": $scope.nameLikeOperator,
                    "IngredientName": $scope.ingredientName,
                    "quantityOperator": $scope.quantityOperator,
                    "IngredientQuantity": $scope.ingredientQuantity,
                    "IngredientUnit": $scope.ingredientUnit
                },
                {
                    "NameLikeOperator": $scope.nameLikeOperator2,
                    "IngredientName": $scope.ingredientName2,
                    "quantityOperator": $scope.quantityOperator2,
                    "IngredientQuantity": $scope.ingredientQuantity2,
                    "IngredientUnit": $scope.ingredientUnit2
                },
                {
                    "NameLikeOperator": $scope.nameLikeOperator3,
                    "IngredientName": $scope.ingredientName3,
                    "quantityOperator": $scope.quantityOperator3,
                    "IngredientQuantity": $scope.ingredientQuantity3,
                    "IngredientUnit": $scope.ingredientUnit3
                }],
                IngredientCategoryFilters: [{
                    "IngredientCategoryName": $scope.ingredientCategory
                }],
                ProductNameFilters: [{
                    "ProductNameLikeOperator": $scope.productNameLikeOperator,
                    "ProductName": $scope.productName
                }],
                ProductTypeFilters: [{
                    "ProductTypeNameFilter": $scope.productType
                }],
                SupplementFormFilters: [{
                    "SupplementFormNameFilter": $scope.supplementForm
                }]

            };
            $scope.query = JSON.stringify(jsonQuery);
            $scope.showFilters = false;
            $scope.showLoading = true;
            $scope.getResults();
        };
            
   }]);