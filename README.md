## VERS�O FINAL 
## DesafioBack - Laudinei Martins

Desenvolva uma API que permita a inclus�o de um t�tulo em atraso, tamb�m uma consulta de uma lista de t�tulos atrasados e a consulta de um t�tulo por ID.

Atendendo aos requisitos do desafio proposto, foi desenvolvido uma API denominado desafiobackapi.
A API foi desenvolvida dentro do padr�o REST, � executada em um container Docker.

# Tecnologias, Frameworks e Libraries:

- desafiobackapi foi escrita em C# . NET Core 5.0 e utiliza o LocalSqlServer, EntityFramework, Dapper, Swagger, xUnit para testes unit�rios.

# Recursos, par�metros e requisitos:
  
Para executar a API, basta abrir o projeto .\DesafioBack\DesafioBack.sln no Visual Studio e executar para abrir a p�gina 
http://localhost:62440/swagger/index.html. Executar no swagger as op��es de inclus�o, e consultas.

Exemplo de json para inclus�o:

{
  "numero": 1012,
  "nome": "fulano",
  "cpf": "999999999999",
  "juros": 1.3,
  "multa": 2.5,
  "parcelas": [
    {
      "numero": 20,
      "vencimento": "2021-04-10T15:29:53.745Z",
      "valor": 120
    },
	{
      "numero": 21,
      "vencimento": "2021-05-10T15:29:53.745Z",
      "valor": 120
    },
	{
      "numero": 22,
      "vencimento": "2021-06-10T15:29:53.745Z",
      "valor": 120
    },
    {
      "numero": 23,
      "vencimento": "2021-07-10T15:29:53.745Z",
      "valor": 120
    }

  ]
}

# Se for necess�rio criar o banco de dados.
- CRIAR O PRIMEIRO MIGRATION.
Abrir um cmd e entrar no diret�rio do projeto .\DesafioBack\DesafioBack e executar os comandos.

dotnet tool install --global dotnet-ef --version 3.1.5

dotnet ef migrations add apiback -p .\DesafioBack.csproj 

- APLICAR AS MIGRACOES NO BANCO.

dotnet ef database update apiback -p \DesafioBack.csproj

----------------------------------------------
N�O DEU TEMPO DE ACERTAR PELO DOCKER

Para executar a API pelo docker, o mesmo dever� estar instalado em execu��o e dever� entrar no diret�rio raiz da solu��o ./DesafioBack e executar o comando:
    docker-compose up -d

Esse comando baixar� as imagens e criar� os containers e subir� as aplica��es.

- Para documenta��o e testes/utiliza��o da API, acesse o navegador:

DesafioBack: http://localhost:5001/swagger/index.html.


# Referencias:

https://xunit.net
https://docs.docker.com/compose/aspnet-mssql-compose/
https://desenvolvedor.io/curso-online-introducao-entity-framework-core


