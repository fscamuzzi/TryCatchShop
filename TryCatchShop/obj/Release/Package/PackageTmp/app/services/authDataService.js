'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', 'toaster', 'enviroment', 'CurrentUser',
function ($http, $q, localStorageService, toaster, enviroment, CurrentUser) {
    // Private Fileds
    var _serviceBase = '';
    var _authentication = {
        isAuth: false,
        userName: "",
        role: ""
    };

    // Private Method
    var _logOut = function () {
        var deferred = $q.defer();
        try {
            $http.post(enviroment.apiUrl + _serviceBase + 'api/Account/Logout').then(function (response) {
                localStorageService.remove('authorizationData');
                localStorageService.remove('currentUser');
                // CurrentUser.removeCurrentUser();
                CurrentUser.setCurrentUser(null);

                _authentication.isAuth = false;
                _authentication.userName = "";
                _authentication.role = "";
                deferred.resolve('logOut');
            });

        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

    // Public Method
    return {
        saveRegistration: function (registration) {
            _logOut();

            return $http.post(enviroment.apiUrl + _serviceBase + 'api/Account/register', registration).then(function (response) {
                return response;
            });
        },
        login: function (loginData) {
            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password + "&name=" + loginData.name + "&surname=" + loginData.surname + "&birthdate=" + loginData.birthdate + "&address=" + loginData.address + "&phoneNumber=" + loginData.phoneNumber + "&email=" + loginData.email;
            var deferred = $q.defer();

            $http.post(enviroment.apiUrl + _serviceBase + 'api/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, role: response.role });

                _authentication.isAuth = true;
                _authentication.userName = response.userName;
                _authentication.role = response.role;

                deferred.resolve(response);
            }).error(function (err, status) {
                _logOut();
                deferred.reject(err);
            });

            return deferred.promise;
        },
        logOut: _logOut,
        fillAuthData: function () {
            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentication.isAuth = true;
                _authentication.userName = authData.userName;
                _authentication.role = authData.role;
            }
        },
        authentication: _authentication
    };
}]);