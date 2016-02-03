var app = angular.module("Supplement", []);
   app.controller("QuerySupplement", ["$scope", "$http", function ($scope, $http) {
       
        $scope.nameLikeOperator = '';
        $scope.ingredientName = '';
        $scope.quantityOperator = '';
        $scope.ingredientQuantity = '';
        $scope.ingredientUnit = '';
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