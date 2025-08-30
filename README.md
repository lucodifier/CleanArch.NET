# Clean Architecture Guideline - .NET

Este projeto serve como um guia prático para implementar Clean Architecture em projetos .NET, demonstrando as melhores práticas e padrões de organização de código.

## 🏗️ Arquitetura

O projeto segue os princípios da Clean Architecture, organizando o código em camadas bem definidas:

```
CleanArchitectureGuideline/
├── CleanArch.Api/           # Camada de apresentação (Controllers, DTOs)
├── CleanArch.Application/    # Camada de aplicação (Use Cases, Commands/Queries)
├── CleanArch.Domain/         # Camada de domínio (Entidades, Regras de negócio)
├── CleanArch.Data/           # Camada de dados (Repositórios, Contexto)
├── CleanArch.Infrastructure/ # Camada de infraestrutura (Serviços externos)
└── CleanArch.CrossCutting/   # Camada transversal (Logging, Cache, etc.)
```

## 🎯 Princípios Implementados

- **Separação de Responsabilidades**: Cada camada tem uma responsabilidade específica
- **Inversão de Dependência**: Dependências apontam para abstrações, não implementações
- **CQRS**: Separação entre comandos (write) e queries (read)
- **MediatR**: Implementação do padrão mediator para desacoplamento
- **Repository Pattern**: Abstração do acesso a dados (não existe acesso a banco, apenas a objetos abstratos)

## 🚀 Funcionalidades

### Produtos
- ✅ Criar produto
- ✅ Buscar produto por ID
- ✅ Listar todos os produtos
- ✅ Atualizar produto
- ✅ Deletar produto

## 🛠️ Tecnologias Utilizadas

- **.NET 8.0**
- **ASP.NET Core Web API**
- **MediatR** - Para implementação do padrão mediator
- **Swagger/OpenAPI** - Para documentação da API

## 📋 Pré-requisitos

- .NET 8.0 SDK
- Visual Studio 2022 ou VS Code
- Git

## 🚀 Como Executar

1. **Clone o repositório**
   ```bash
   git clone <repository-url>
   cd CleanArchitectureGuideline
   ```

2. **Restore as dependências**
   ```bash
   dotnet restore
   ```

3. **Execute o projeto**
   ```bash
   dotnet run --project CleanArch.Api
   ```

4. **Acesse a API**
   - Swagger UI: https://localhost:7001/swagger
   - API Base: https://localhost:7001/api

## 🧪 Testando a API

### Usando o arquivo HTTP
O projeto inclui um arquivo `CleanArch.Api.http` com exemplos de todas as operações.

### Usando Swagger
1. Acesse https://localhost:7001/swagger
2. Teste os endpoints diretamente na interface

### Exemplos de uso

#### Criar Produto
```http
POST /api/products
Content-Type: application/json

{
  "name": "Produto Teste",
  "price": 29.99
}
```

#### Buscar Produto
```http
GET /api/products/{id}
```

#### Atualizar Produto
```http
PUT /api/products/{id}
Content-Type: application/json

{
  "id": "{id}",
  "name": "Produto Atualizado",
  "price": 39.99
}
```

#### Deletar Produto
```http
DELETE /api/products/{id}
```

## 📚 Estrutura do Código

### Domain Layer
- **Entities**: Entidades de negócio com regras de validação
- **Value Objects**: Objetos de valor (futuro)
- **Domain Services**: Serviços de domínio (futuro)

### Application Layer
- **Commands**: Comandos para operações de escrita
- **Queries**: Consultas para operações de leitura (futuro)
- **Handlers**: Manipuladores dos comandos/queries
- **Contracts**: Interfaces dos repositórios

### Data Layer
- **Repositories**: Implementação dos repositórios
- **DbContext**: Contexto do Entity Framework (futuro)

### API Layer
- **Controllers**: Controladores REST
- **DTOs**: Objetos de transferência de dados (futuro)
- **Filters**: Filtros de validação (futuro)

## 🔄 Padrões Utilizados

### CQRS (Command Query Responsibility Segregation)
- **Commands**: Para operações de escrita (Create, Update, Delete)
- **Queries**: Para operações de leitura (Get, List)

### Repository Pattern
- Abstração do acesso a dados
- Facilita testes unitários
- Permite troca de implementações

### Mediator Pattern
- Desacoplamento entre componentes
- Facilita implementação de CQRS
- Melhora testabilidade

## 📖 Referências

- [Clean Architecture by Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Microsoft .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [MediatR Documentation](https://github.com/jbogard/MediatR)

## 🤝 Contribuição

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 👨‍💻 Autor

Luciano - [lucianorieth@outlook.com](mailto:lucianorieth@outlook.com)

---

⭐ Se este projeto te ajudou, considere dar uma estrela!
