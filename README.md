# iTasks - Sistema de Gestão de Tarefas Kanban

Um sistema de gestão de tarefas baseado na metodologia Kanban, desenvolvido em C# com Windows Forms.

## 📋 Descrição

O iTasks é uma aplicação desktop que permite a gestão eficiente de tarefas através de um board Kanban visual. O sistema suporta diferentes tipos de utilizadores (Gestores e Programadores) com permissões específicas para cada função.

## 🚀 Funcionalidades Principais

### 👥 Gestão de Utilizadores
- **Gestores (Managers)**: Podem criar e gerir tarefas, utilizadores e tipos de tarefas
- **Programadores**: Podem executar e acompanhar as suas tarefas atribuídas

### 📊 Sistema Kanban
- **ToDo**: Tarefas por fazer
- **Doing**: Tarefas em execução (máximo 2 por programador)
- **Done**: Tarefas concluídas

### 🔧 Funcionalidades Avançadas
- Criação e edição de tarefas com Story Points
- Gestão de tipos de tarefas personalizáveis
- Sistema de ordem obrigatória de execução
- Cálculo automático de previsões baseado em dados históricos
- Exportação de relatórios para CSV
- Consulta de tarefas concluídas e em curso

## 🛠️ Tecnologias Utilizadas

- **Framework**: .NET Framework 4.8
- **Interface**: Windows Forms
- **Base de Dados**: Entity Framework 6.5.1 com SQL Server
- **Arquitetura**: MVC (Model-View-Controller)

## 📁 Estrutura do Projeto

```
iTasks/
├── Models/
│   ├── User.cs
│   ├── Manager.cs
│   ├── Programmer.cs
│   ├── Task.cs
│   ├── TypeTask.cs
│   └── ...
├── Controllers/
│   ├── TaskController.cs
│   └── UserController.cs
├── Views/
│   ├── frmKanban.cs
│   ├── frmLogin.cs
│   ├── frmGereUtilizadores.cs
│   └── ...
└── iTaskContext.cs
```

## ⚙️ Configuração e Instalação

### Pré-requisitos
- Visual Studio 2017 ou superior
- .NET Framework 4.8
- SQL Server (LocalDB ou instância completa)

### Passos de Instalação

1. **Clone o repositório**
   ```bash
   git clone (https://github.com/RRG00/Group3_iTask)
   ```

2. **Abra o projeto no Visual Studio**
   ```
   iTasks.sln
   ```

3. **Restaure os pacotes NuGet**
   ```
   Tools > NuGet Package Manager > Restore NuGet Packages
   ```

4. **Configure a string de conexão**
   - Edite o ficheiro `App.config`
   - Ajuste a connection string para a sua instância SQL Server

5. **Execute a aplicação**
   - A base de dados será criada automaticamente
   - Um utilizador admin será criado por defeito:
     - **Username**: admin
     - **Password**: admin

## 👤 Utilizadores por Defeito

| Tipo | Username | Password | Permissões |
|------|----------|----------|------------|
| Gestor | admin | admin | Todas as funcionalidades |

## 🎯 Como Usar

### Para Gestores:
1. Faça login com as credenciais de gestor
2. Crie tipos de tarefas personalizados
3. Gira utilizadores (programadores)
4. Crie e atribua tarefas aos programadores
5. Acompanhe o progresso através do board Kanban
6. Consulte relatórios e estatísticas

### Para Programadores:
1. Faça login com as suas credenciais
2. Visualize as tarefas atribuídas no board Kanban
3. Mova as tarefas através dos estados (ToDo → Doing → Done)
4. Respeite a ordem de execução definida pelo gestor
5. Mantenha máximo 2 tarefas em "Doing" simultaneamente

## 📊 Funcionalidades do Sistema

### 🔄 Fluxo de Tarefas
1. **Criação**: Gestor cria tarefa e atribui a programador
2. **Execução**: Programador move tarefa para "Doing"
3. **Conclusão**: Programador marca tarefa como "Done"

### 📈 Relatórios Disponíveis
- Tarefas concluídas com tempo real vs. previsto
- Tarefas em curso por gestor
- Previsão de conclusão baseada em dados históricos
- Exportação para CSV

### 🔒 Regras de Negócio
- Programadores só podem mover as suas próprias tarefas
- Máximo de 2 tarefas em "Doing" por programador
- Tarefas devem ser executadas pela ordem definida
- Apenas gestores podem criar/editar tarefas e utilizadores

## 🗃️ Base de Dados

O sistema utiliza Entity Framework Code First com as seguintes entidades principais:

- **Users**: Utilizadores base
- **Managers**: Gestores (herda de Users)
- **Programmers**: Programadores (herda de Users)
- **Tasks**: Tarefas do sistema
- **TypeTasks**: Tipos de tarefas

**Desenvolvido em 2025** - Sistema de Gestão de Tarefas iTasks
