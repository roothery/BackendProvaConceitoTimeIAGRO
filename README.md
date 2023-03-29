Um cliente tem necessidade de buscar livros em um catálogo. Esse cliente quer ler e buscar esse catálogo de um arquivo JSON, e esse arquivo não pode ser modificado. Então com essa informação, é preciso desenvolver:

- Criar uma API para buscar produtos no arquivo JSON disponibilizado.
- Que seja possível buscar livros por suas especificações(autor, nome do livro ou outro atributo)
- É preciso que o resultado possa ser ordenado pelo preço.(asc e desc)
- Disponibilizar um método que calcule o valor do frete em 20% o valor do livro.

Será avaliado no desafio:

- Organização de código;
- Manutenibilidade;
- Princípios de orientação à objetos;
- Padrões de projeto;
- Teste unitário

Para nos enviar o código, crie um fork desse repositório e quando finalizar, mande um pull-request para nós.

O projeto deve ser desenvolvido em C#, utilizando o .NET Core 3.1 ou superior.

Gostaríamos que fosse evitado a utilização de frameworks, e que tivesse uma explicação do que é necessário para funcionar o projeto e os testes.

## Notas importantes

- Precisa utilizar o .NET 6 SDK
- [Download .NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

## Documentação da API

#### Retorna catálogo de livros convertido do JSON, com escolha de ordenação.
```bash
  GET /api/BookCatalog/book-catalog
```

#### Retorna catálogo de livros baseado nas opções de filtros aplicados.
```bash
  GET /api/BookCatalog/book-catalog-filter
```

#### Retorna um determinado livro com o valor do frete calculado.
```bash
  GET /api/BookCatalog/book-shipping
```

## Rodando localmente

Clone o projeto

```bash
  git clone https://github.com/roothery/BackendProvaConceitoTimeIAGRO.git
```

Entre no diretório do projeto

```bash
  cd ../BackendProvaConceitoTimeIAGRO
```

Execute o comando para compilar o projeto e suas dependências

```bash
  dotnet build
```

Execute o comando para rodar a aplicação. 
Ela estará disponível aqui: [https://localhost:7182/swagger/index.html](https://localhost:7182/swagger/index.html)

```bash
  dotnet run -- project .\BookCatalog.Domain.Api\
```

Para rodar os testes, no diretório do projeto execute: 

```bash
  cd .\BookCatalog.Domain.Tests\
  dotnet test
```

## Rodando pelo Visual Studio 2022

- Abra o projeto pela opção `Open a project or solution`
- Digite o comando `Ctrl+Alt+L` para abrir a `Solution Explorer`
- Na `Solution Explorer`, identifique e clique com o botão direito na `Solution BookCatalog` e selecione **Rebuild Solution**
- Depois, clique com o botão direito na `BookCatalog.Domain.Api` e selecione **Set as Startup Project**
- No topo do programa, clique no ícone semelhante a este `▶️ BookCatalog.Domain.Api` para rodar a aplicação
