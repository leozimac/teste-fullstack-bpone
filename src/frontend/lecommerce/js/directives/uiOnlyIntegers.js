angular.module("lecommerce").directive("uiInteger", function ($filter) {
    return {
        require: "ngModel",
        link: function (scope, element, attrs, ctrl) {
            var _integer = function (number) {
                if (number == undefined || number == null) return number;
                
                number = number.toString();
                number = number.replace(/[^0-9]+/g, "")
                return number;
            }

            element.bind("keyup", function () {
                ctrl.$setViewValue(_integer(ctrl.$viewValue));
                ctrl.$render();
            });

            ctrl.$parsers.push(function (value) {
                if (value === undefined || value == null) return value;
                
                value = value.toString();
                value = value.replace(/[^0-9]+/g, "");
                return value;
            });
        }
    }
})