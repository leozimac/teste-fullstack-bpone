angular.module("lecommerce").controller("novoPedidoCtrl", function ($scope, pedidosAPI, clientesAPI, produtosAPI, $location) {
    $scope.produtos = [];
    $scope.clientes = [];

    $scope.total = 0;

    var carregarClientes = function () {
        clientesAPI.getClientes().then(function successCallback(response){
            $scope.clientes = response.data.clients;
        }, function errorCallback(response) {
            if (response.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível conectar com o servidor!";
            }
        });
    };

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

    $scope.addTotal = function (pedido, quantidade) {
        if (pedido === undefined || pedido === null) return;
       $scope.total = pedido.price * quantidade;
    }

    $scope.adicionarPedido = function (pedido) {
        var novoPedidoRequest = {
            clientId: pedido.cliente,
            items: [
                {
                    productId: pedido.produto.id,
                    quantity: pedido.quantidade,
                    total: $scope.total
                }
            ]
        }

        pedidosAPI.savePedido(novoPedidoRequest).then(function successCallback (response) {
            delete $scope.pedido;
            $scope.pedidoForm.$setPristine();
            $location.path("/pedidos")
        }, function errorCallback (response) {
            if (response.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível salvar o novo produto!";
            } else {
                $scope.showErrorMessage = true;
                $scope.error = response.data.messages;
            }
        });
    }

    carregarClientes();
    getProdutos();
})