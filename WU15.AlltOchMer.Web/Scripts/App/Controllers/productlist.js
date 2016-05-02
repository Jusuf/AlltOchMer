myApp.controller('productlistController', function ($scope, $http) {

    $scope.message = 'Lista över produkter';

    $http.get("/api/product").success(function (data, status, headers, config) {

        $scope.productList = data;

    }).error(function (data, status, headers, config) {

    });

});