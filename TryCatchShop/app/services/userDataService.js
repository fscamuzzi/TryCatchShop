"use strict";

app.factory('User', ['localStorageService', 'enviroment', '$resource', '$q', 'CurrentUser','$http',
    function (localStorageService, enviroment, $resource, $q, CurrentUser, $http) {

        // Private Filed
        var deferred = $q.defer();
        var _serviceBase = '/api/Account/CurrentUser';
        var _serviceBase2 = '/api/Users/UpdateProfile';
        var _serviceBase5 = '/api/Users/GetUser/:idOwin';
        var _serviceBase3 = '/api/Users/';
        var _serviceBase4 = '/api/Users/:id';
        var data = {};

        var _resource = $resource(enviroment.apiUrl + _serviceBase3, {}, {
            query: { method: 'GET', isArray: true }
        });

        var _resourceUser = $resource(enviroment.apiUrl + _serviceBase5, { idOwin: '@idOwin' });
        var _resourceDetail = $resource(enviroment.apiUrl + _serviceBase4, { id: '@id' }, {
            update: { method: 'PUT' },
            create: { method: 'POST' },
            delete: { method: 'DELETE' }
        });

        return {
            getCurrentUser: function () {
                if (!localStorageService.get('currentUser')) {
                    $resource(enviroment.apiUrl + _serviceBase).get().$promise.then(function (resp) {
                        localStorageService.set('currentUser', resp);
                        CurrentUser.setCurrentUser(resp);
                        data = resp;
                        deferred.resolve(data);
                    }).catch(function (err) {
                        deferred.reject(err);
                    });
                }
                else {
                    data = localStorageService.get('currentUser');
                    CurrentUser.setCurrentUser(data);
                    deferred.resolve(data);
                }

                return deferred.promise;
            },
            updateCurrentUser: function (value) {
                return $resource(enviroment.apiUrl + _serviceBase2, {},
                  {
                      'update': { method: 'PUT' }
                  }).update(value);
            },
            setCurrentUser: function (value) {
                localStorageService.remove('currentUser');
                localStorageService.set('currentUser', value);
                CurrentUser.setCurrentUser(value);
                return value;
            },
            getAllUsers: function () {
                return _resource.query();
            },
            getUser: function (idOwin) {
                return _resourceUser.get({ idOwin: idOwin });
            },
            deleteUser: function(user_id) {
                return _resourceDetail.delete({ id: user_id });
            },
            updateUser: function(user) {
                return _resourceDetail.update(user);
            }
        };

    }]);