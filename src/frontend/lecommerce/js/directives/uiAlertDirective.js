angular.module("lecommerce").directive("uiAlert", function () {
    return {
        templateUrl: "view/alert.html",
        restrict: "AE",
        scope: {
            title: "@",
            message: "="
        },
        transclude: true
    };
});