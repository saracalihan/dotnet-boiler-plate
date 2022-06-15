# DotNet Boilerplate
A basic boilerplate with authentication**, **services**, **repositories** and **models** for DotNet Core 5.0

## Table of Contents
+ [Folder Structure](#folder-structure)
+ [Commands](#commands)
  - [Install](#install)
  - [Run](#run)
  - [Run for development](#run-for-development)
  - [Publish](#publish)
+ [Contributing](#contributing)
+ [Contributors](#contributors)

## Folder Structure

```bash
.
├── Controllers # API endpoints handlers
│   ├── < Endpoint >Controller.cs
│   ├── AuthenticationController.cs
│   └── UsersController.cs
├── DTOs # Data Transfer Objects for get data from body
│   ├── < Category >
│   │   └── < UseCase >DTO.cs
│   ├── Authentication
│   │   ├── LoginDTO.cs
│   │   └── SigninDTO.cs
│   └── User
│       ├── CreateUserDTO.cs
│       └── UpdateUserDTO.cs
├── DapperExample.csproj
├── DapperExample.csproj.user
├── LICENSE # Lic
├── Models
│   ├── < Entity >Model.cs
│   └── UserModel.cs
├── Program.cs # Projects start point
├── Properties
│   └── launchSettings.json
├── README.md
├── Services # Entity's business logic's
│   ├── < UseCase >Service.cs
│   ├── AuthenticationService.cs
│   ├── DatabaseService.cs
│   └── UserServices.cs
├── Startup.cs
├── appsettings.Development.json
├── appsettings.json
├── bin # Executables
└── obj # Compiled files
```
[Go to table of contents](#table-of-contents) 
## Commands
Install this project then run is as you want.
### Install
Clone and move into this repository
```bash
git clone https://github.com/saracalihan/dotnet-boiler-plate.git
cd dotnet-boiler-plate 
```

### Run
Run project with dotnet cli or use Visual Studio
```bash
dotnet run

```

### Run for Development
DotNet CLI can track file or folders and if project has any changes it will hotreload the project
```bash
dotnet watch run
```

### Publish
Build to generate executable and DLL's
```bash
dotnet publish
```

[Go to table of contents](#table-of-contents) 

## Contributing
If you want to contribute to the project, please first **check** if the work you are doing is already an **issue**. If there is an issue and there is someone assigned to the issue, **contact that person**. If there is no issue, you can send your development to the project managers by opening a **pull request**. Please read [CONTRIBUTING.md](./CONTRIBUTING.md)

[Go to table of contents](#table-of-contents) 
## Contributors
<a href = "https://github.com/saracalihan/dotnet-boiler-plate/graphs/contributors">
  <img src = "https://contrib.rocks/image?repo=saracalihan/dotnet-boiler-plate"/>
</a>

[Go to table of contents](#table-of-contents) 

## LICENSE
[GNU GENERAL PUBLIC LICENSE Version 3](./LICENSE)

[Go to table of contents](#table-of-contents) 
