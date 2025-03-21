# Biblioteca
Projeto originalmete criado para atender ao Desafio técnico para analista .net Sênior da empresa Basis.

O sistema de biblioteca é para gerenciamento de livros e vendas, desenvolvido com .NET Core e Angular.

# Estrutura

* Biblioteca.Api: API REST em .NET Core, endpoints para CRUD, swagger e relatório.
* Biblioteca.Application: Lógica de negócios e serviços.
* Biblioteca.Domain: Modelos e entidades.
* Biblioteca.Infra.Data: Acesso ao banco com Entity Framework e repositórios.
* Biblioteca.Infra.IoC: Configuração de injeção de dependência.
* Biblioteca.UI -> Frontend: Interface feita em Angular, com CRUD e geração de relatório.

# Pré-Requisitos

* .Net 8 SDK
* SqlServer Express
* SqlServer Management Studio(SSMS)
* EntityFramework
* Node.js e npm
* Angular
* BootStrap
* GIT
* Visual Studio
* VSCode

# RODANDO A APLICAÇÃO API

* Clone o repositório
```bash
 git clone https://github.com/sasquashi/biblioteca.git
```
* Configure a connection string no appsettings.json da Biblioteca.Api
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=Biblioteca;Trusted_Connection=True;Encrypt=False"
}
```
obs.: Encrypt=False desativa o uso de SSL/TLS na conexão, eliminando a necessidade de validar certificados. Devido a alguns problemas localmente tive que remover a validação. Logo, se fosse colocar em algum ambiente como de produção não poderia ter essa opção e modificar o sistema.

* Restaure as dependencias via Nugget ou rode o comando abaixo:
```bash
dotnet restore
dotnet run
```
* A API deverá rodar e estará visível em http://localhost:5000 (verifique a porta que está configurada).

# RODANDO A APLICAÇÃO UI
* Optei por separar as pastas e usar o mesmo diretório. Dessa forma, terá que entrar na pasta Biblioteca.UI baixada e abrir a pasta no VS Code e executar:

```bash
npm install
```
* Depois de executado, rode o comando:
```bash
npm start
```
ou 
```bash
ng serve --open
```

Em tese o npm start deve funcionar pois fiz a configuração para que, ao rodar, o npm start já execute o ng serve --open.

# Funcionalidades
* Listagem, cadastro, edição e exclusão de livros, autor, assunto, vendas, formas de pagamento e formas de venda.
* Exibição de relatório
* Relatório disponível: Livros por autor em PDF, gerado com JSReport
* NavBar com opções de navegação e acesso ao relatório.
* Criei ainda as tabelas de  historico de acao e o historico de venda. Não coloquei elas na aplicação UI, deixei apenas para a lógica na API e para consultas no próprio SQL.
* Para realizar as consultas basta executar os comandos abaixo:
```sql
SELECT * FROM HistoricoVenda
```
ou

```sql
SELECT * FROM HistoricoAcao
```

# Banco de Dados
* Crie o banco Biblioteca no SQL Server. O script foi adicionado no projeto (Biblioteca.Infra.Data) na pasta scripts.


# Tem alguma dúvida: sasquashi@gmail.com =)
