namespace Lecommerce.Domain.Constant
{
    public static class MessagesConstant
    {
        public const string ClientNotFound = "Nenhum cliente foi encontrado.";
        public const string ClientNotFoundWithId = "Nenhum cliente de id {0} foi encontrado.";
        public const string InvalidCpf = "CPF inválido.";
        public const string InvalidCnpj = "CNPJ inválido.";
        public const string ClientAlreadyExistsWithCpf = "Cliente com CPF {0} já existe!";
        public const string ClientAlreadyExistsWithCnpj = "Cliente com CNPJ {0} já existe!";

        public const string OrdersNotFound = "Nenhum pedido encontrado.";
        public const string OrderNotFoundWithId = "Nenhum pedido de id {0} foi encontrado.";

        public const string ProductsNotFound = "Nenhum produto encontrado.";
        public const string ProductNotFoundWithId = "Nenhum produto de id {0} foi encontrado.";
        public const string ProductQuantityInvalid = "Quantidade do Produto deve ser maio que zero para criar um novo pedido.";
        public const string AlreadyHasProductWithCode = "Já existe um produto com o código {0}";
    }
}
