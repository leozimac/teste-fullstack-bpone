# teste-fullstack-bpone
Tem como objetivo avaliar meu conhecimento técnico, criatividade, boas práticas de desenvolvimento e habilidade para resolver problemas de forma simples.

## Requisitos
Implementar uma API REST e front para cadastro de clientes e pedidos e seus respectivos produtos:

- O serviço de pedidos deverá persistir no banco de dados todos os atributos recebidos no request
- A API REST deverá tratar erros no cadastro tais como dados enviados inválidos, CPF/CNPJ inválidos
- Seja feito em .Net Core e (Angular JS ou React);
- Princípios SOLID;
- Conteinerização da aplicação utilizando docker e docker compose.

## Tecnologias utilizadas
[ASP.NET Core 8.0](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-8.0?view=aspnetcore-8.0) - Para a criação da API.


[AngularJS](https://angularjs.org/) - Para a criação do front-end.

[PostgreSQL](https://www.postgresql.org/) - Como o banco de dados da solução.

[Docker](https://www.docker.com/) - Para a criação dos containers da API e do Front. Docker-compose para rodar os containers em conjunto e centralizar a configuração.

## Executando o projeto
Para executar o projeto, basta abrir o terminal no diretório onde está localizado o arquivo docker-compose.yml e executar o comando:

`docker-compose up`

Ou

`docker-compose up -d`

O front estará executando no endereço http://localhost:5500/

E a API no endereço http://localhost:5295/swagger/index.html
