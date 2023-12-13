angular.module("lecommerce").factory("pedidosAPI", function ($http, config) {
    var _getPedidos = function () {
        return $http.get(config.baseUrl + "Order");
    }

    var _savePedido = function (pedido) {
        return $http.post(config.baseUrl + "Order", pedido);
    }

    var _getPedido = function (id) {
        return $http.get(config.baseUrl + "Order/" + id);
    }

    var _deletePedido = function (id) {
        return $http.delete(config.baseUrl + "Order/" + id);
    }

    return {
        getPedidos: _getPedidos,
        savePedido: _savePedido,
        getPedido: _getPedido,
        deletePedido: _deletePedido
    }
})