angular.module("lecommerce").controller("pedidosCtrl", function ($scope, pedidosAPI) {
    $scope.pedidos = [];

    var carregarPedidos = function () {
        pedidosAPI.getPedidos().then(function successCallback(response) {
            $scope.pedidos = response.data.orders;

            $scope.pedidos.forEach(pedido => {
                var date = new Date(pedido.date);
                var newDate = new Date(date.getTime() - (date.getTimezoneOffset() * 60 * 1000));
                pedido.date = newDate;
            }, function errorCallback(response) {
                if (response.status == "-1") {
                    $scope.showErrorMessage = true;
                    $scope.error = "Não foi possível buscar os pedidos!"
                } else {
                    $scope.showErrorMessage = true;
                    $scope.error = response.data.messages;
                }
            });
        });

        $scope.removerPedido = function (pedidoId) {
            pedidosAPI.deletePedido(pedidoId).then(function successCallback (response) {
                carregarPedidos();
            }, function errorCallback (response) {
                if (response.status == "-1") {
                    $scope.showErrorMessage = true;
                    $scope.error = "Não foi possível remover o pedido!";
                } else {
                    $scope.showErrorMessage = true;
                    $scope.error = response.data.messages;
                }
            });
        }
    }

    carregarPedidos();
});