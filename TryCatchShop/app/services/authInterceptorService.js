"use strict";

app.factory('authInterceptorService', ['$q', '$location', 'localStorageService', 'toaster',
    function ($q, $location, localStorageService, toaster) {
        // Public Method
        return {
            request: function (config) {
                config.headers = config.headers || {};

                var authData = localStorageService.get('authorizationData');
                if (authData) {
                    config.headers.Authorization = 'Bearer ' + authData.token;
                }

                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401) {
                    $location.path('/login');
                    toaster.options = { "showDuration": "1200" };
                    toaster.warning("you need to be authenticated to acces the area!");
                }

                return $q.reject(rejection);
            }
        };
    }]);