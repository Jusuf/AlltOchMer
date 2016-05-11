myApp.controller('productDetailsController', function ($scope, $http) {

    $scope.message = 'Produkt Detaljer';
   
    $http.get("/api/product/ProductDetails").success(function (data, status, headers, config) {
        
        $.each(data, function (index, p) {
            
            if (p.price == 0) {
                p.price = 'Ej prissatt';
            }
            $scope.product = {
                id: p.productId,
                name: p.productName,
                price: p.price
            }
        });
        
    }).error(function (data, status, headers, config) {
        
    });

});