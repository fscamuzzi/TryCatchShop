'use strict';
app.factory('shopService', ['$resource', '$q', 'localStorageService', 'toaster', 'enviroment', 'CurrentUser',
function ($resource, $q, localStorageService, toaster, enviroment, CurrentUser) {

    // Private Fileds
    var _serviceBase = 'api/Product/';
    var _serviceBaseDetail = 'api/Product/:id';

    var _shopsReourse = $resource(enviroment.apiUrl + _serviceBase, {}, {
        query: { method: 'GET', isArray: true }
    });

    var _shopResourceDetail = $resource(enviroment.apiUrl + _serviceBaseDetail, { id: '@id' }, {
        update: { method: 'PUT' },
        create: { method: 'POST' },
        delete: { method: 'DELETE' }
    });



    // Public Method
    return {
        getProduct: function (id) {
            return _shopResourceDetail.get({ id: id });
        },
        getProducts: function () {
            return _shopsReourse.query();
        },
        addProduct: function (prod) {
            return _shopResourceDetail.create(prod);
        },
        deleteProduct: function (id) {
            return _shopResourceDetail.delete({ id: id });
        },
        updateProduct: function (prod, photoId) {
            prod.firstImage = photoId;
            return _shopResourceDetail.update({ id: prod.id }, prod);
        }

    };
}]);