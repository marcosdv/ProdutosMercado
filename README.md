# Produtos Mercado API

![Badge](https://img.shields.io/badge/Marcos%20Dias%20Vendramini-ASP.NET%20C%23-red)

## CRUD utilizando C#, .NET 6, CQRS, Entity Framework e SQL Server

- [x] Cadastro de Fornecedor
- [x] Cadastro de Produtos

## Instalando o Entity Framework

### Instalação do dotnet-ef command line tools
dotnet tool install --global dotnet-ef

### Comando para gerar as Migrations
dotnet ef migrations add CriacaoInicial -s ..\ProdutosMercado.Api\ProdutosMercado.Api.csproj

### Comando para atualizar o banco de dados de acordo com as migrations
dotnet ef database update -s ..\ProdutosMercado.Api\ProdutosMercado.Api.csproj

### Comando para gerar o script do banco de dados, para casos de não houver acesso direto ao banco (ex: banco de produção)
dotnet ef migrations script -o ./script.sql -s ..\ProdutosMercado.Api\ProdutosMercado.Api.csproj

## Tecnologias

As seguintes ferramentas foram usadas na construção dos projetos:

- [ASP.NET](https://dotnet.microsoft.com/apps/aspnet)
- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Entity Framework](https://docs.microsoft.com/pt-br/ef/)
