"use strict";

app.factory('CurrentUser', ['enviroment', function (enviroment) {
    // Private Filed
    var _currentUser = {};

    return {
        getCurrentUser: function () {
            return _currentUser;
        },
        setCurrentUser: function (value) {
            _currentUser = value;
        },
        removeCurrentUser: function () {
            _currentUser = {};
        }
    };
}]);