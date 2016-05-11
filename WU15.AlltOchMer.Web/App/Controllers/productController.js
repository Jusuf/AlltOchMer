myApp.controller('productController', function ($scope, $http) {

    $scope.message = 'Lista över produkter';
    $scope.products = [];
   
    $http.get("/api/product/AllProducts").success(function (data, status, headers, config) {
        
        $.each(data, function (index, p) {
            
            if (p.price == 0) {
                p.price = 'Ej prissatt';
            }
            var product = {
                id: p.productId,
                name: p.productName,
                price: p.price
            }
            
            $scope.products.push(product)
        });
        
    }).error(function (data, status, headers, config) {
        
    });
    $scope.getProductById = function (id) {

        console.log(event);
        $http.get("/api/product/ProductDetails/" + id).success(function (data, status, headers, config) {
            debugger;
            $.each(data, function (index, p) {

                if (p.price == 0) {
                    p.price = 'Ej prissatt';
                }
                var product = {
                    id: p.productId,
                    name: p.productName,
                    price: p.price
                }

                $scope.products.push(product)
            });

        }).error(function (data, status, headers, config) {

        });
    };

});