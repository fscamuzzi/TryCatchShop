'use strict';

app.controller('HomeController', ['$scope', 'toaster', '$modal', 'authService', '$resource', 'shopService',
    function ($scope, toaster, $modal, authService, $resource, shopService) {

        $scope.form = {};
        $scope.filialeDetails = {
            Filialeid: 0,
            Titolo: "",
            Indirizzo: "",
            Cap: "",
            Telefono: "",
            Fax: ""
        };


        // Page Load
        init();

        function init() {
       
        }



    }]);