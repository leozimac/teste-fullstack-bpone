angular.module("lecommerce").controller("lecommerceCtrl", function ($scope, $http, clientesAPI){
    $scope.app = "Pedidos";
    $scope.pedidos = [
        {cliente: "Leonardo", produto: "Livro", data: "11/12/2023 10:15", total: 50.00},
        {cliente: "Ana", produto: "Gel facial", data: "10/12/2023 17:00", total: 25.00}
    ];

    $scope.clientes = [
        {nome: "Leonardo", id: "2855cb3c-1e50-48ea-a374-db5c6cf5cfd3"},
        {nome: "Ana", id: "0ad79178-9290-4593-bdc7-3e74442148ca"}
    ];

    var carregarClientes = function () {
        clientesAPI.getClientes().then(function successCallback(data){
            console.log(data);
        }, function errorCallback(data) {
            if (data.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível conectar com o servidor!";
            }
        });
    };

    $scope.adicionarPedido = function (pedido) {
        pedido.cliente = pedido.cliente.nome;
        $scope.pedidos.push(angular.copy(pedido));
        delete $scope.pedido;
        $scope.pedidoForm.$setPristine();
    };

    $scope.removerPedido = function (pedidos) {
        $scope.pedidos = pedidos.filter(function (pedido) {
            if (!pedido.selecionado) return pedido;
        });
    };

    $scope.isPedidoSelecionado = function (pedidos) {
        return pedidos.some(function (pedido) {
            return pedido.selecionado;
        });
    }

    carregarClientes();
});