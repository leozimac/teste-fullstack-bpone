angular.module("lecommerce").controller("detalheProdutoCtrl", function($scope, $route, $location, produtosAPI){
    var formatDate = function (date) {
        var newDate = new Date(date.getTime() - (date.getTimezoneOffset() * 60 * 1000));
        return newDate;
    };

    var getProduto = function () {
        produtosAPI.getProduto($route.current.params.id).then(function successCallback (response) {
            $scope.produto = response.data.product;

            var date = new Date($scope.produto.creationDate);
            $scope.produto.creationDate = formatDate(date);
            
            if ($scope.produto.updateDate != null) {
                var updateDate = new Date($scope.produto.updateDate);
                $scope.produto.updateDate = formatDate(updateDate);
            }

            console.log(response.data);
        }, function errorCallback (response) {
            if (response.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível buscar o pedido!";
            } else {
                $scope.showErrorMessage = true;
                $scope.error = response.data.messages;
            }
        });
    }

    $scope.updateProduto = function (produto) {
        produtosAPI.updateProduto(produto).then(function successCallback (response) {
            delete $scope.produto;
            $location.path("/produtos");
        }, function errorCallback (response) {
            if (response.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível atualizar o produto!";
            } else {
                $scope.showErrorMessage = true;
                $scope.error = response.data.messages;
            }
        });
    };

    getProduto();
});