"use strict";

app.directive('fullpage', function ($timeout) {
    return {
        restrict: 'AC',

        link: function (scope, element, attrs) {

            $timeout(function () {
                // initialize
                var width = $(window).width();
                var height = $(window).height();
                var $fullpage = $(element);
                //var isPhoneDevice = /Android|webOS|iPhone|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent);

                $(window).resize(function () {
                    height = $(window).height(); // New height
                    width = $(window).width(); // New width
                });

   
                if ((width < 991) || (height<680)) {
                    //$fullpage.fullpage({ menu: "menu", scrollOverflow: true });
                    $fullpage.on('click', 'a', function () {
                        $fullpage.fullpage.destroy();
                    });
                } else {
                    $fullpage.fullpage({ menu: "menu" });
                    $fullpage.on('click', 'a', function () {
                        $fullpage.fullpage.destroy();
                    });
                }


                scope.$on('$destroy', function () {
                    console.log("destroy");
                    cleanup();
                });


                function cleanup() {
                    $fullpage.fullpage.destroy();
                }


            });
        }

    };
});