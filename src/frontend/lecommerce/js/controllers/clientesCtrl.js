angular.module("lecommerce").controller("clientesCtrl", function ($scope, clientesAPI) {
    $scope.clientes = [];

    var carregarClientes = function () {
        clientesAPI.getClientes().then(function successCallback(response) {
            $scope.clientes = response.data.clients;
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

    $scope.ordenarPor = function (campo) {
        $scope.criterioDeOrdenacao = campo;
        $scope.asc = !$scope.asc;
    }

    $scope.removerCliente = function (idCliente) {
        clientesAPI.deleteCliente(idCliente).then(function successCallback (response) {
            carregarClientes();
        }, function errorCallback (response) {
            if (response.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível remover o cliente!";
            } else {
                $scope.showErrorMessage = true;
                $scope.error = response.data.messages;
            }
        });
    }

    carregarClientes();
});