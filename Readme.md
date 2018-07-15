# ASP.NET Core 2.1 MVC Project

## Source

[https://jonhilton.podia.com](https://jonhilton.podia.com)

## Scaffold

### Controller

    cd Controllers
    dotnet aspnet-codegenerator --project ../. controller -name BoardController -namespace Donatello.Controllers --relativeFolderPath ./Controllers/

### View

    cd views
    cd xxx

    dotnet aspnet-codegenerator --project ../../. view Index Empty --relativeFolderPath ./Views/xxx/

### ViewModel

    VSCode > NewFile "ViewModel.cs"

## Style

### Materialize

[https://materializecss.com/](https://materializecss.com/)

## EF Core

### Add EF Core

    dotnet add package Pomelo.EntityFrameworkCore.MySql --version 2.1.1
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 2.1.1

### Dotnet EF CLI

#### Docs
[https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet)

#### Add-Migration

    dotnet ef migrations add InitialCreate

#### Update-Database

    dotnet ef database update