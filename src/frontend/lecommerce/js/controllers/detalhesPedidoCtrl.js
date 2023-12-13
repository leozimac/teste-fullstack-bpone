angular.module("lecommerce").controller("detalhesPedidoCtrl", function ($scope, $route, pedidosAPI) {
    var getPedido = function(){
        pedidosAPI.getPedido($route.current.params.id).then(function successCallback(response) {
            $scope.pedido = response.data.order;
            console.log(response.data.order);
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

    getPedido();
});