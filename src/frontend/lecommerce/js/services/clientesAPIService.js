angular.module("lecommerce").factory("clientesAPI", function($http, config) {
    var _getClientes = function () {
        return $http.get(config.baseUrl + "Client");
    };

    var _getCliente = function (id) {
        return $http.get(config.baseUrl + "Client/" + id)
    }

    var _saveCliente = function (cliente) {
        return $http.post(config.baseUrl + "Client", cliente)
    };

    var _deleteCliente = function (id) {
        return $http.delete(config.baseUrl + "Client/" + id)
    };

    var _updateCliente = function (cliente) {
        return $http.put(config.baseUrl + "Client/" + cliente.id, cliente);
    }
    
    return {
        getClientes: _getClientes,
        getCliente: _getCliente,
        saveCliente: _saveCliente,
        deleteCliente: _deleteCliente,
        updateCliente: _updateCliente
    };
});