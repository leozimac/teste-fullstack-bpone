angular.module("lecommerce").controller("produtosCtrl", function ($scope, produtosAPI) {
    $scope.produtos = [];

    var getProdutos = function () {
        produtosAPI.getProdutos().then(function successCallback(response) {
            $scope.produtos = response.data.products;
        }, function errorCallback(response) {
            if (response.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível buscar os clientes!";
            } else {
                $scope.showErrorMessage = true;
                $scope.error = response.data.messages;
            }
        });
    }

    $scope.removerProduto = function (produtoId) {
        produtosAPI.deleteProduto(produtoId).then(function successCallback (response) {
            getProdutos();
        }, function errorCallback (response) {
            if (response.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível remover o produto!";
            } else {
                $scope.showErrorMessage = true;
                $scope.error = response.data.messages;
            }
        });
    };

    getProdutos();
});