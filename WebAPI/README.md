
## EventosAPI

> Web API desenvolvida em C# .NetCore 3.1 e testada com Postman :rocket:

Utilizada como apoio para um serviço desenvolvido em delphi para cadastrado de eventos, palestrantes e convidados.\
Esta API conta com requisições Http Get, Post, Put e Delete, validações diversas com retorno de status, e ainda uma funcionalida extra de verificação de endereços a partir do cep, utilizando a API externa , e gratuita, [ViaCep](https://viacep.com.br) integrada ao nosso serviço. Neste processo, recebemos o json do ViaCep, convertemos para objeto e retornamos ao usuário um novo Json, a partir da nossa API, contendo apenas os dados mais relevantes para ele como Endereço, Cep, Logradouro, etc.


- [x] Orientada a interfaces
- [x] Arquitetura DDD
- [x] Sql Server
- [x] Requisições Get, Post, Put e Delete
- [x] Linq, Lambda, AutoMapper e EntityFramework
- [x] Json
