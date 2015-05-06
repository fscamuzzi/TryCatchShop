"use strict";

app.directive('ngReallyClick', function ($timeout) {
    return {
        restrict: 'A',

        link: function (scope, element, attrs) {
            element.bind('click', function () {
                var message = attrs.ngReallyMessage;
                if (message && confirm(message)) {
                    scope.$apply(attrs.ngReallyClick);
                }
            });
        }

    };
});