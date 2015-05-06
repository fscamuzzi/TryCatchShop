"use strict";

app.controller('SignupController', ['$scope', '$location', '$timeout', 'authService', 'User', 'toaster', '$modal',
    function ($scope, $location, $timeout, authService, User, toaster, $modal) {
        $scope.loading = false;
        $scope.message = "";
        $scope.profileStatus = {
            message: "",
            isNew: true
        };

        $scope.registration = {
            userName: "",
            password: "",
            confirmPassword: "",
            name: "",
            surname: "",
            birthdate: "",
            address: "",
            phoneNumber: "",
            Email: "",
            Role: "Customer"
        };

        $scope.saveData = function () {
            signUp();
        };

        // PRIVATE FUNCTION ///////////////////////////

        // Page Load
        function init() {
            $scope.format = $scope.formats[0];
            $scope.today();

            $scope.profileStatus.message = "Register your profile";
            $scope.profileStatus.isNew = true;
        }

        // Func to update Profile of Current User
        var updateUser = function () {
            User.updateCurrentUser($scope.registration).$promise.then(function () {
                User.setCurrentUser($scope.registration);
                toaster.success("operation complete!");
            }).catch(function (err) {
                console.log(err);
                toaster.error("error", err.message);
            });
        };

        // Func to format date From View
        function formatMMDDYYYY(date) {
            return (date.getMonth() + 1) +
            "/" + date.getDate() +
            "/" + date.getFullYear();
        }

        var startTimer = function () {
            var timer = $timeout(function () {
                $timeout.cancel(timer);
                $scope.closeReg();
                $scope.close();
                $location.path('/login');
            }, 2000);
        };

        //[AR] 100315 - Ho trasformato "$scope.signUp = function {" in "function signUp() {"
        var signUp = function () {
            $scope.loading = true;
            authService.saveRegistration($scope.registration).then(function (response) {
                $scope.savedSuccessfully = true;
                $scope.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
                $scope.loading = false;
                startTimer();
            },
                      function (response) {
                          var errors = [];

                          for (var key in response.data.ModelState) {
                              if (key)
                                  for (var i = 0; i < response.data.ModelState[key].length; i++) {
                                      errors.push(response.data.ModelState[key][i]);
                                  }
                          }
                          $scope.message = "Failed to register user due to:" + errors.join(' ');
                      });
        };

        ////////////////////////////////////////////
        // END PRIVATE FUNC ///////////////////////
        //////////////////////////////////////////

        // PUBLIC FUNCTION ///////////////////////////

        // DatePicker Func and $scope var
        $scope.formats = ['dd.MM.yyyy'];

        $scope.today = function () {
            $scope.dt = new Date();
        };

        $scope.clear = function () {
            $scope.dt = null;
        };

        $scope.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.opened = true;
        };

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };

        // add listener to change of date in datepicker
        $scope.$watch('dt', function () {
            //date has changed
            console.log(formatMMDDYYYY($scope.dt));
            $scope.registration.birthdate = formatMMDDYYYY($scope.dt);
        });

        ////////////////////////////////////////////
        // END PRIVATE FUNC ///////////////////////
        //////////////////////////////////////////

        // call func on Page Load
        init();
    }]);