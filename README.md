## VERSÃO FINAL 
## DesafioBack - Laudinei Martins

Desenvolva uma API que permita a inclusão de um título em atraso, também uma consulta de uma lista de títulos atrasados e a consulta de um título por ID.

Atendendo aos requisitos do desafio proposto, foi desenvolvido uma API denominado desafiobackapi.
A API foi desenvolvida dentro do padrão REST, é executada em um container Docker.

# Tecnologias, Frameworks e Libraries:

- desafiobackapi foi escrita em C# . NET Core 5.0 e utiliza o EntityFramework, Dapper, Swagger, xUnit para testes unitários.

# Recursos, parâmetros e requisitos:
Cada imagem e suas respectivas portas serão configuradas:

desafiobackapi 5000
  

Para executar a API, o docker deverá estar instalado em execução e deverá entrar no diretório raiz da solução ./DesafioBack e executar o comando:
    docker-compose up -d

Esse comando baixará as imagens e criará os containers e subirá as aplicações.

- Para documentação e testes/utilização da API, acesse o navegador:

DesafioBack: http://localhost:5000/swagger/index.html.


# Referencias:

https://xunit.net 

https://www.youtube.com/watch?v=FcF5iufd2P0 



