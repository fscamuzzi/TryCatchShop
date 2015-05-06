'use strict';

app.controller('IndexController', [
    '$scope', '$location', 'toaster', '$modal', 'authService', 'CurrentUser', 'User', '$timeout', '$rootScope', 'shopService',
    function ($scope, $location, toaster, $modal, authService, CurrentUser, User, $timeout, $rootScope, shopService) {

        $scope.authentication = authService.authentication;
        $scope.loading = false;
        $scope.message = "";
        $scope.products = [];

        ////////////////////////////////////////////////////////////////////
        // modal window Func //////////////////////////////////////////////7
        ////////////////////////////////////////////////////////////////////

        $scope.open = function () {
            $scope.$modalInstance = $modal.open({
                scope: $scope,
                templateUrl: "/app/views/login.html",
                controller: "LoginController",
                size: ''
            });
        };

        $scope.close = function () {
            $scope.$modalInstance.close();
        };

        //////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////

        $scope.message = "";

        $rootScope.$on("logged-in", function (evt, parameters) {
            $scope.authentication = parameters;
        });

        $scope.logout = function () {
            authService.logOut().then(function () {
                $scope.authentication = {
                    isAuth: false,
                    userName: "",
                    role: ""
                };

                $location.path('/home');
            });
        };

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



    }
]);