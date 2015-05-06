"use strict";

app.controller('LoginController', ['$scope', '$location', 'authService', 'User', 'toaster', 'CurrentUser', '$modal','$rootScope',
    function ($scope, $location, authService, User, toaster, CurrentUser, $modal, $rootScope) {
        $scope.$parent.loading = false;
        $scope.pageClass = 'page-contact';
        $scope.loginData = {
            userName: "",
            password: ""
        };


        $scope.message = "";

        $scope.login = function () {
            $scope.$parent.loading = true;
            authService.login($scope.loginData).then(function (response) {
                // User Func
                if (authService.authentication.isAuth) {
                    $scope.$modalInstance.close();
                   
                }
                $rootScope.$broadcast('logged-in', authService.authentication);
                $scope.$parent.loading = false;
                $location.path('/home');
            },
             function (err) {
                 $scope.$parent.loading = false;
                 $scope.message = err.error_description;
                 toaster.error("Username o password errati!");
             });
        };


        $scope.openReg = function () {
            $scope.$modalInstanceReg = $modal.open({
                scope: $scope,
                templateUrl: "/app/views/modalSignup.html",
                controller: "SignupController",
                size: ''
            });
        };

        $scope.closeReg = function () {
            $scope.$modalInstanceReg.close();
        };

        init();

        function init() {

        }

    }]);