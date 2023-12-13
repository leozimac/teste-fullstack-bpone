angular.module("lecommerce").controller("novoClienteCtrl", function ($scope, clientesAPI, $location){

    $scope.tipoPessoa = 0;
    $scope.cpfRequired = false;
    $scope.cnjpRequired = false;

    $scope.setTipoPessoa = function (tipo) {
        if (tipo == "pf") {
            $scope.tipoPessoa = 0;
            $scope.cpfRequired = true;
            $scope.cnjpRequired = false;
            $scope.clienteForm.cnpj.$setPristine();
        } else if(tipo == "pj") {
            $scope.tipoPessoa = 1;
            $scope.cnjpRequired = true;
            $scope.cpfRequired = false;
            $scope.clienteForm.cpf.$setPristine();
            console.log($scope.clienteForm.$invalid);
        }
    }

    $scope.adicionarCliente = function (cliente) {
        var novoClienteRequest = {};
        if (cliente.cpf) {
            novoClienteRequest = {
                name: cliente.nome,
                document: cliente.cpf,
                clientType: 0
            };
        } else if (cliente.cnpj) {
            novoClienteRequest = {
                name: cliente.nome,
                document: cliente.cnpj,
                clientType: 1
            };
        }

        clientesAPI.saveCliente(novoClienteRequest).then(function successCallback (response) {
            delete $scope.cliente;
            $scope.clienteForm.$setPristine();
            $location.path("/clientes");

        }, function errorCallback (response) {
            if (response.status == "-1") {
                $scope.showErrorMessage = true;
                $scope.error = "Não foi possível salvar o novo cliente!";
            } else {
                $scope.showErrorMessage = true;
                $scope.error = response.data.messages;
            }
        });
    }
});