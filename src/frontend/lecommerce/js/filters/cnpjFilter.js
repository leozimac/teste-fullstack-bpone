angular.module("lecommerce").filter("cnpj", function () {
    return function (input) {
        // 57 720 631 0001 00
        cnpj = input.slice(0, 2) + "." +
            input.slice(2, 5) + "." +
            input.slice(5, 8) + "/" +
            input.slice(8, 12) + "-" +
            input.slice(12);

        return cnpj;
    }
});