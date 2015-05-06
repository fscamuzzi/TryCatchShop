'use strict';

app.controller('ShopController', ['$scope', 'toaster', '$modal', 'authService', '$resource', '$http', '$upload', 'shopService', 'enviroment',
function ($scope, toaster, $modal, authService, $resource, $http, $upload, shopService, enviroment) {
   
    // Page Load
    init();

    function init() {
        shopService.getProducts().$promise.then(function (resp) {
            // order product by insert date
            var productsOrderd = JSLINQ(resp).OrderBy(function (item) {
                return item.insertDate;
            }).ToArray();

            $scope.products = productsOrderd;
        }).catch(function (err) {
            toaster.error('insert error');
        });
    }
}]);