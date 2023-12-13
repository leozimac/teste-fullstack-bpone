angular.module("lecommerce").config(function ($routeProvider) {
    $routeProvider.when("/pedidos", {
        templateUrl: "view/pedidos.html",
        controller: "pedidosCtrl"
    });

    $routeProvider.when("/novoPedido", {
        templateUrl: "view/novoPedido.html",
        controller: "novoPedidoCtrl"
    });

    $routeProvider.when("/detalhesPedido/:id", {
        templateUrl: "view/detalhePedido.html",
        controller: "detalhesPedidoCtrl"
    });

    $routeProvider.when("/clientes", {
        templateUrl: "view/clientes.html",
        controller: "clientesCtrl"
    }); 
    
    $routeProvider.when("/novoCliente", {
        templateUrl: "view/novoCliente.html",
        controller: "novoClienteCtrl"
    });

    $routeProvider.when("/detalhesCliente/:id", {
        templateUrl: "view/detalheCliente.html",
        controller: "detalheClienteCtrl"
    }); 

    $routeProvider.when("/produtos", {
        templateUrl: "view/produtos.html",
        controller: "produtosCtrl"
    });

    $routeProvider.when("/novoProduto", {
        templateUrl: "view/novoProduto.html",
        controller: "novoProdutoCtrl"
    });

    $routeProvider.when("/detalhesProduto/:id", {
        templateUrl: "view/detalheProduto.html",
        controller: "detalheProdutoCtrl"
    });

    $routeProvider.otherwise({redirectTo: "/pedidos"});
});