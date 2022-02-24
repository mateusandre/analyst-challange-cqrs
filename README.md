# Desafio para vaga de analista pleno/sênior

## Dependências

* .Net Core 3.1.403
* EntityFrameworkCore (5.0.4)
* Swashbuckle.AspNetCore (6.1.0)
* AutoMapper (10.1.1)
* MediatR (9.0.0)
* Microsoft Sql Server 2017 Ubuntu
* Docker
* Vue.js
* Webpack
* Es2015
* Node.js

## Documentação

Após clonar o projeto abra o terminal a partir da pasta src/Web.UI e execute o comando "docker-compose up" para subir o container da aplicação e do sql server
A aplicação estará disponível em [https://localhost:15000](https://localhost:15000), onde poderá ser visto a documentação da API.
Para abrir o Dashboard acesse o endereço [https://localhost:15000/app](https://localhost:15000/app)

## Solução ao Desafio

Utilizado pattern CQRS para separar a responsabilidade da aplicação em Commands e Queries, fazendo as operações de forma assíncrona, este pattern permite uma ganho para escalar aplicações de alta disponibilidade e performance.
O CQRS é importante nesse cenário devido a grande carga de gravação e leitura, trazendo várias possibilidades para escalar a aplicação como for necessário.
Utilização de VueJs no front-end para consumir a api através do axios e componentizar o front-end, garantindo uma maior flexibilidade e separação de responsabilidades.

## O que eu gostaria de implementar

* Utilizar um banco NoSQL para gravar os dados para leitura de forma estruturada, assim melhorando a performance da leitura e da gravação, pois os processamentos seriam executados em bases de dados distintas, e um banco desnormalizado como o MongoDB garantiria a Performance de leitura.
* Utilizar atualização eventual para sincronização dos bancos de gravação e leitura.
* Utilizar fila RabbitMq para controlar a gravação dos eventos, garantindo que se o banco estiver fora, os dados serão gravados assim que o servidor retornar.
* Implementar Websocket com SignalR para atualização de informações no front-end, ao invés de intervalos para a busca.
* Implementar arquivo build.sh para fazer build da imagem e subir para o registry
