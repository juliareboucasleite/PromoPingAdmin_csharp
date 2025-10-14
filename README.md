# Painel Administração PromoPing Csharp

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white) ![MySQL](https://img.shields.io/badge/mysql-4479A1.svg?style=for-the-badge&logo=mysql&logoColor=white) ![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D4.svg?style=for-the-badge&logo=windows&logoColor=white)

Um painel administrativo completo desenvolvido em C# com Windows Forms para gestão de produtos, utilizadores e notificações.

## Funcionalidades

### Autenticação
- Sistema de login seguro
- Registro de novos utilizadores
- Gestão de sessões

### Dashboard
- Visão geral dos dados principais
- Contadores em tempo real:
  - Total de utilizadores
  - Total de produtos
  - Notificações ativas
  - Valor total poupado

### Gestão de Utilizadores
- Listagem de utilizadores
- Criação de novos perfis
- Edição de dados pessoais
- Gestão de preferências de notificação

### Gestão de Produtos
- Listagem de produtos
- Adição de novos produtos
- Edição de produtos existentes
- Controle de preços e metas

### Sistema de Notificações
- Configuração de preferências
- Gestão de notificações ativas
- Sistema de alertas personalizado

### Suporte
- Interface de suporte integrada
- Sistema de tickets

## Tecnologias Utilizadas

- **C#** - Linguagem principal
- **Windows Forms** - Interface gráfica
- **MySQL** - Base de dados
- **BCrypt** - Criptografia de senhas
- **MaterialSkin** - Design moderno

## Estrutura do Projeto

```
Painel_Admin_csharp/
├── Auth/                    # Módulo de autenticação
│   ├── FormLogin.cs
│   ├── FormRegistar.cs
│   └── Sessao.cs
├── Core/                    # Configurações centrais
│   ├── DbConfig.cs
│   └── App.config
├── Produtos/               # Gestão de produtos
│   ├── FormProdutoAdicionar.cs
│   ├── FormProdutoEditar.cs
│   └── ProdutosListForm.cs
├── Utilizadores/           # Gestão de utilizadores
│   ├── FormUtilizadoresList.cs
│   ├── FormPerfilDetalhes.cs
│   └── FormNotificacoes.cs
├── Repositories/           # Camada de dados
│   ├── ProdutoRepository.cs
│   ├── UtilizadorRepository.cs
│   └── PreferenciaNotificacaoRepository.cs
└── Resources/             # Recursos visuais
    ├── Imagens
    └── Ícones
```

## Como Executar

### Pré-requisitos
- Visual Studio 2019 ou superior
- MySQL Server
- .NET Framework 4.8

### Instalação
1. Clone o repositório:
```bash
git clone https://github.com/juliareboucasleite/Painel_Admin_csharp.git
```

2. Abra o projeto no Visual Studio

3. Configure a base de dados no arquivo `Core/DbConfig.cs`:
```csharp
public static string ConnectionString { get; } =
    "Server=localhost;Database=pap;Uid=root;Pwd=sua_senha;SslMode=none;";
```

4. Execute o projeto (F5)

## Base de Dados

O sistema utiliza as seguintes tabelas principais:
- `utilizadores` - Dados dos utilizadores
- `produtos` - Catálogo de produtos
- `preferenciasnotificacao` - Configurações de notificação

## Interface

O painel possui uma interface moderna e intuitiva com:
Dashboard com métricas em tempo real
Menu de navegação organizado
Formulários responsivos
Design Material Design

## Configuração

### Base de Dados
Certifique-se de que o MySQL está rodando e que a base de dados `pap` existe.

### Conexão
Ajuste a string de conexão no arquivo `Core/DbConfig.cs` conforme sua configuração local.

## Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## Autor

**Julia Rebouças Leite**
GitHub: [@juliareboucasleite](https://github.com/juliareboucasleite)

<img width="100%" src="https://capsule-render.vercel.app/api?type=waving&color=228B22&height=120&section=footer"/>

Se este projeto foi útil para você, considere dar uma estrela!
