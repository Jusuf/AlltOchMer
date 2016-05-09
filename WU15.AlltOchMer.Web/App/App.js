/// <reference path="C:\VSproject\WU15.AlltOchMer\WU15.AlltOchMer.Web\Pages/About.html" />
/// <reference path="C:\VSproject\WU15.AlltOchMer\WU15.AlltOchMer.Web\Pages/Contact.html" />
/// <reference path="C:\VSproject\WU15.AlltOchMer\WU15.AlltOchMer.Web\Pages/Home.html" />
/// <reference path="C:\VSproject\WU15.AlltOchMer\WU15.AlltOchMer.Web\Pages/Index.html" />
var myApp = angular.module('myApp', ['ngRoute', 'ngResource']);

myApp.config(function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'Pages/Home.html',
            controller: 'productController'
        })

        // route for the about page
        .when('/about', {
            templateUrl: 'Pages/About.html',
            controller: 'aboutController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'Pages/Contact.html',
            controller: 'contactController'
        });
});

// create the controller and inject Angular's $scope
myApp.controller('mainController', function ($scope) {
    // create a message to display in our view
    $scope.message = 'Everyone come and see how good I look!';
});

myApp.controller('aboutController', function ($scope) {
    $scope.message = 'Look! I am an about page.';
});

myApp.controller('contactController', function ($scope) {
    $scope.message = 'Contact us! JK. This is just a demo.';
});
