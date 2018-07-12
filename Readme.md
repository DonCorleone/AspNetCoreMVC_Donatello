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
