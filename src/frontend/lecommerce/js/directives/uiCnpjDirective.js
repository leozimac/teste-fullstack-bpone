angular.module("lecommerce").directive("uiCnpj", function () {
    return {
        require: "ngModel",
        link: function (scope, element, attrs, ctrl) {
            var _formatCnpj = function (cnpj) {
                cnpj = cnpj.replace(/[^0-9]+/g, "");
                // 57.720.631/0001-00
                if (cnpj.length > 2) {
                    cnpj = cnpj.substring(0,2) + "." + cnpj.substring(2);
                }
                if (cnpj.length > 6) {
                    cnpj = cnpj.substring(0,6) + "." + cnpj.substring(6);
                }
                if (cnpj.length > 10) {
                    cnpj = cnpj.substring(0,10) + "/" + cnpj.substring(10);
                }
                if (cnpj.length > 15) {
                    cnpj = cnpj.substring(0,15) + "-" + cnpj.substring(15,17);
                }

                return cnpj;
            }

            element.bind("keyup", function () {
                ctrl.$setViewValue(_formatCnpj(ctrl.$viewValue));
                ctrl.$render();
            });

            ctrl.$parsers.push(function (value) {
                if (value.length === 18) {
                    var cnpj = value.replace(/[^0-9]+/g, "")
                    return cnpj;
                }
            });
        }
    }
});