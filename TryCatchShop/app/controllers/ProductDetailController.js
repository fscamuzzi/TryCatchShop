'use strict';

app.controller('ProductDetailController', ['$scope', 'toaster', '$modal', 'authService', '$routeParams', 'shopService',
function ($scope, toaster, $modal, authService, $routeParams, shopService) {

    $scope.productID = $routeParams.id;
    $scope.form = {};

    // Page Load
    init();

    function init() {
        if ($scope.productID)
            shopService.getProduct($scope.productID).$promise.then(function (resp) {
                $scope.form = resp;
            }).catch(function (err) {
                toaster.error('error');
            });
    }
}]);