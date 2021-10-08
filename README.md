## O que encontrará neste projeto
### Tela Principal
- Contém a listagem de produtos cadastrados no banco e botões para adicionar ao carrinho.

### Carrinho de Compras
- Listagem de todos os produtos selecionados na tela anterior e nesta tela é possivel aumentar, diminuir e retirar um produto do carrinho.

### Identificação do Cliente
- Nesta tela será solicitado o nome, e-mail e telefone do cliente antes de finalizar a compra.

### Detalhes do Pedido
- Nesta tela, é exibido as informações do cliente, o número do pedido e todos os produtos adquiridos.

## Tecnologias Utilizadas
- Angular
- .NET 5.0 
- SQL Server

## Como utilizar o projeto
- O SQL para a inserção dos produtos se encontra na pasta **sql_ecommerce**.
- É necessário alterar a string de conexão do arquivo **ApiContext.cs** dentro da API, sendo localizada dentro da pasta **Back\Data\Context**.
- Para a estrutura do banco de dados é necessario executar o arquivo de migrations. Executando um **Update-Database** ou **dotnet ef database update**
