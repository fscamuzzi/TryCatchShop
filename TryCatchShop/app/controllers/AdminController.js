'use strict';

app.controller('AdminController', ['$scope', 'toaster', '$modal', 'authService', '$resource', '$http', '$upload', 'shopService', 'enviroment',
function ($scope, toaster, $modal, authService, $resource, $http, $upload, shopService, enviroment) {
    $scope.form = {};
    $scope.form.ProductImage = [];
    $scope.products = [];

    $scope.uploading = false;
    $scope.savedSuccessfully = false;
    $scope.myFile = '';
    $scope.path = enviroment.path;
    $scope.newProductImage = {};

    ///Upload Func///
    $scope.data = {
        files: '',
        filesSez: ''
    };

    $scope.$watch('data.files', function (evt) {
        upload(evt);
    });

    var upload = function (files) {
        if (files && files.length) {
            for (var i = 0; i < files.length; i++) {
                var file = files[i];
                $scope.uploading = true;
                //   $scope.imageName = file.name;
                $upload.upload({
                    url: 'api/Product/UploadFile',
                    fields: { 'username': $scope.username },
                    file: file
                }).progress(function (evt) {
                    var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                    console.log('progress: ' + progressPercentage + '% ' + evt.config.file.name);
                    $scope.progress = progressPercentage;
                }).success(function (data, status, headers, config) {
                    console.log('file ' + config.file.name + 'uploaded. Response: ' + data);
                    $scope.newProductImage.FileName = data;
                    $scope.uploading = false;
                    $scope.myFile = data;
                });
            }
        }
    };

    ///Upload func End///

    // func to submit form of preventivo
    $scope.submit = function () {
        if ($scope.formPrev.$valid) {
            // set fields extra

            $scope.form.avaiable = ($scope.form.avaiable === true) ? '1' : '0';
            $scope.form.avaiable = ($scope.form.avaiable === true) ? '1' : '0';

            $scope.form.ProductImage.push({ image: $scope.myFile });

            shopService.addProduct($scope.form).$promise.then(function (response) {
                $scope.products.push(response);
                toaster.success("product inserted!");
            }).catch(function (err) {
                toaster.error("error in insert product");
                //console.log(err);
            });
        }
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
}]);