angular.module("lecommerce").controller("novoProdutoCtrl", function ($scope, produtosAPI, $location) {
    $scope.adicionarProduto = function (produto) {
        var novoProdutoRequest = {
            name: produto.nome,
            code: produto.codigo,
            price: produto.preco
        };

        produtosAPI.saveProduto(novoProdutoRequest).then(function successCallback (response) {
            delete $scope.produto;
            $scope.produtoForm.$setPristine();
            $location.path("/produtos");
        }, function errorCallback (response) {
            if (response.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível salvar o novo produto!";
            } else {
                $scope.showErrorMessage = true;
                $scope.error = response.data.messages;
            }
        });
    };
});