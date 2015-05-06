"use strict";
/*######################*********************#############################
   Created by: Federico Scamuzzi
  http://twitter.com/fscamuzzi
   ######################*********************##############################*/

window.app = angular.module('TryCatchShop', [
    'ngRoute',
    'ngResource',
    'ui.bootstrap',
    'ngAnimate',
    'toaster',
    'chieffancypants.loadingBar',
    'ngMap',
    'LocalStorageModule',
    'angularFileUpload'
]);


app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

    $routeProvider.when("/", {
        controller: "IndexController",
        templateUrl: "/app/views/home.html"
    });


    $routeProvider.when("/shop/", {
        controller: "ShopController",
        templateUrl: "/app/views/shop.html"
    });

    $routeProvider.when("/product/:id", {
        controller: "ProductDetailController",
        templateUrl: "/app/views/productDetail.html"
    });

    $routeProvider.when("/admin/", {
        controller: "AdminController",
        templateUrl: "/app/views/admin.html"
    });


    $routeProvider.when("/login/", {
        controller: "LoginController",
        templateUrl: "/app/views/home.html"

    });


    $routeProvider.otherwise({ redirectTo: "/" });

    $locationProvider.html5Mode(true);

}]);


// General Configuration
app.config(function ($httpProvider) {

    $httpProvider.interceptors.push('authInterceptorService');

});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);

// Modify this var constant to change apiUrl host
app.constant('enviroment', {
    // for remote or localhost
    apiUrl: "",
    path: ""
});

//app.value('cgBusyDefaults', {
//    message: 'Caricamento..',
//    backdrop: true,
//    templateUrl: '/Scripts/lib/angular-busy/angular-busy.html',
//    delay: 800
//    wrapperClass: 'my-class my-class2'
//});

app.animation('.view-slide-in', function () {
    return {
        enter: function (element, done) {
            element.css({
                opacity: 0.5,
                position: "relative",
                top: "0px",
                left: "200px"
            })
            .animate({
                top: 0,
                left: 0,
                opacity: 1
            }, 1200, done);
        }
    };
});
