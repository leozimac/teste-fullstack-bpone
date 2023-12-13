angular.module("lecommerce").factory("produtosAPI", function ($http, config) {
    var _getProdutos = function () {
        return $http.get(config.baseUrl + "Product");
    };

    var _getProduto = function (id) {
        return $http.get(config.baseUrl + "Product/" + id)
    };

    var _saveProduto =  function (produto) {
        return $http.post(config.baseUrl + "Product", produto);
    }

    var _deleteProduto = function (id) {
        return $http.delete(config.baseUrl + "Product/" + id);
    }

    var _updateProduto = function (produto) {
        return $http.put(config.baseUrl + "Product/" + produto.id, produto)
    }

    return {
        getProdutos: _getProdutos,
        getProduto: _getProduto,
        saveProduto: _saveProduto,
        deleteProduto: _deleteProduto,
        updateProduto: _updateProduto
    }
});