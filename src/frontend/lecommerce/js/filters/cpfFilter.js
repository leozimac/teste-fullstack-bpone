angular.module("lecommerce").filter("cpf", function () {
    return function (input) {
        cpf = input.slice(0, 3) + "." +
            input.slice(3, 6) + "." +
            input.slice(6, 9) + "-" +
            input.slice(9, 11);

        return cpf;
    }
});