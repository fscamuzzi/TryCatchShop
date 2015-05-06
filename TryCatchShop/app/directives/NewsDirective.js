"use strict";

app.directive('news', function ($timeout) {
    return {
        restrict: 'AC',

        link: function (scope, element, attrs) {

            $timeout(function () {
                var $container = $(element);
                // initialize
                $container.easyTicker({
                    speed: 'slow',
                    height: 'auto'
                });

            });
        }

    };
});