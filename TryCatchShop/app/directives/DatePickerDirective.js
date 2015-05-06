"use strict";

app.directive('picker', function ($timeout) {
    return {
        restrict: 'AE',
        scope: true,
        link: function (scope, element, attrs) {
            var momentjs = window.moment;
            var scopeMain = scope;

            $timeout(function () {
                var $container = $(element);
             
                $container.datepicker({
                    format: 'mm/dd/yyyy'
                })
               .on('changeDate', function (e) {
                   var formatDate = momentjs(e.date).format('DD-MM-YYYY');
                    scopeMain.$parent.form.datepicker = formatDate;
                });

            });
        }

    };
});