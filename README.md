# Cadastro de Produtos API

API ASP.NET Core para gerenciamento de cadastro de produtos com autenticação JWT.

## Funcionalidades

- ✅ Autenticação com JWT
- ✅ CRUD de Produtos (Create, Read, Update, Delete)
- ✅ Controle de acesso baseado em roles (admin)
- ✅ Validações de dados
- ✅ Banco de dados SQLite com Entity Framework Core

## Tecnologias

- .NET 9.0
- ASP.NET Core
- Entity Framework Core
- SQLite
- JWT (JSON Web Tokens)

## Instalação

```bash
dotnet restore
dotnet build
```

## Executar

```bash
dotnet run
```

A API estará disponível em `http://localhost:5233`

## Endpoints

### Autenticação

**POST** `/api/login`
```json
{
  "usuario": "admin",
  "senha": "123456"
}
```

Retorna um token JWT válido por 1 hora.

### Produtos

**GET** `/api/Produtos`
- Lista todos os produtos
- Requer autenticação

**GET** `/api/Produtos/{id}`
- Obtém um produto pelo ID
- Requer autenticação

**POST** `/api/Produtos`
- Cria um novo produto
- Requer autenticação com role `admin`
```json
{
  "nome": "Notebook",
  "preco": 2500.00,
  "estoque": 10
}
```

**PUT** `/api/Produtos/{id}`
- Atualiza um produto existente
- Requer autenticação com role `admin`
```json
{
  "nome": "Notebook",
  "preco": 2800.00,
  "estoque": 15
}
```

**DELETE** `/api/Produtos/{id}`
- Remove um produto
- Requer autenticação com role `admin`

## Estrutura do Projeto

```
CadastroProdutos/
├── Controllers/        # Controladores da API
├── Models/            # Modelos de dados
├── Services/          # Lógica de negócio
├── Database/          # Contexto do banco de dados
├── Migrations/        # Migrations do Entity Framework
└── Program.cs         # Configuração da aplicação
```

## Autenticação

Todos os endpoints (exceto login) requerem um token JWT no header:

```bash
Authorization: Bearer <token>
```

## Validações

- Nome do produto: obrigatório, máximo 1000 caracteres
- Preço: deve ser maior que 0
- Estoque: mínimo 1, máximo 100 unidades
- Nomes específicos ("Produto Padrão") são bloqueados

## Banco de Dados

SQLite com auto-incremento para ID de produtos.

```bash
dotnet ef migrations add NomeDaMigracao
dotnet ef database update
```
