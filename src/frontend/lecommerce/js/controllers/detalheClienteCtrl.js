angular.module("lecommerce").controller("detalheClienteCtrl", function ($scope, $route, $location, clientesAPI) {
    var getCliente = function () {
        clientesAPI.getCliente($route.current.params.id).then(function successCallback (response) {
            $scope.cliente = response.data.client;
            console.log(response.data);
        }, function errorCallback (response) {
            if (response.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível buscar o cliente!";
            } else {
                $scope.showErrorMessage = true;
                $scope.error = response.data.messages;
            }
        });
    }

    $scope.updateCliente = function (cliente) {
        var updateClienteRequest = {};

        if (cliente.cpf != '') {
            updateClienteRequest = {
                id: cliente.id,
                name: cliente.name,
                document: cliente.cpf,
                clientType: 0
            }
        } else {
            updateClienteRequest = {
                id: cliente.id,
                name: cliente.name,
                document: cliente.cnpj,
                clientType: 1
            }
        }

        clientesAPI.updateCliente(updateClienteRequest).then(function successCallback (response) {
            delete $scope.cliente;
            $location.path("/clientes");
        }, function errorCallback (response) {
            if (response.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível atualizar o cliente!";
            } else {
                $scope.showErrorMessage = true;
                $scope.error = response.data.messages;
            }
        });
    }

    getCliente();
});