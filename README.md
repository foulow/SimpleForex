# SimpleForex

A small foreign currency exchange project made with ASP.NET Core 3.1 (API) and Angular 2+ (Web Client)

## Project Setup

### Prerequisites

Follow the installation instructions for each dependency on their respective official web pages. (link over the dependency name)

[Windows compatible with .NET Core 3.1 runtime or any other compatible system](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=netcore31)

[.NET Core 3.1 LTS (SDK and Runtime)](https://dotnet.microsoft.com/download/dotnet-core/3.1)

[SQL Server 2019 (Developer or Express)](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

[Node package manager (npm == lts~v14.15.4)](https://nodejs.org/es/download/package-manager/)

### Manual development environment setup

In the root directory of the repository. Open a command prompt of your choice and enter the following commands:

#### 1. _install ef and create the database_

> skip this step if you want to use in-memory database.

```bash
  dotnet tool install --global dotnet-ef
  dotnet build
  dotnet ef database update --project ./Source/SimpleForex.API/
```

#### 2. _install node modules_

```bash
  cd ./Source/SimpleForex.WebClient/
  npm install
```

### Running the projects

To run the API and Angular projects, you will need to open a command prompt for each one. Go to the repository path, from there run:

#### 1. _Running the API_

```bash
  dotnet run --project ./Source/SimpleForex.API
```

> The database should already be migrated in order for the API to function correctly. use one of the migration options below. to do it.

also you can pass an application argument `migrate` to make the initial migration and run the API.

```bash
  dotnet run --project ./Source/SimpleForex.API -- migrate
```

additionally you can pass the argument `--configuration MOCK` or `-c MOCK` to use `SQLIte` instead of `SQLServer` as the persistence handler for a quick test.

```bash
  dotnet run --project ./Source/SimpleForex.API -c MOCK -- migrate
```

if you are using **Visual Studio Code** you can launch the debugger by pressing:

<kbd>F5</kbd>

#### 2. _Running the Web Client_

```bash
  cd Source/SimpleForex.WebClient/
  ng serve --host 127.0.0.1 --port 8081 --o
```

if you are using **Visual Studio Code** you can run the task `npm: serve - Source/SimpleForex.WebClient`, by using.

<kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>P</kbd> then select `Tasks: Run Task` > `npm: serve - Source/SimpleForex.WebClient`.

## Project details

### General information

This is a demo application using .NET Core 3.1 and Angular 2+. Consist on a currency exchange API/Web client for consulting and purchasing foreign currency units.

Each currency is defined by its code, here is a list with the currently supported currencies.

- American dollar (USD) / Argentinian peso (ARS) => USD_ARS
- Brazilian Real (BRL) / Argentinian peso (ARS) => BRL_ARS

> More foreign currencies will be added in the future. like the Canadian Dollar (CAD)
> For more information about international monetary units go [here](https://es.wikipedia.org/wiki/ISO_4217#C%C3%B3digos_de_divisa_ISO_4217[6]%E2%80%8B).

Each user has a limit on the amount of foreign currency they can purchase in a month:

- 200 for the American Dollars (USD)
- 300 for the Brazilian Real (BRL)


#### Architectures

| API      | Web Client      |
| :------- | :-------------- |
| N-Layers | Component-Based |
| Onion    | Atomic          |

#### Code principles

- Clean
- SOLID
- Defensive Coding

#### Design patterns

- Command
- Factory
- Builder
- Dependency Injection
- Repository
- Unit of Work

#### Libraries

| API                 | Web Client |
| :------------------ | :--------- |
| EntityFrameworkCore | lottie-web |
| FluentValidations   | ngx-toastr |
| AutoMapper          | bootstrap  |
| Serilog             | ngrx/store |
| GuardClauses        | angular/forms |
| OpenApi             | angular/router |
| Newtonsoft.Json     | ngx-lottie |

#### Have a great time

I hope you find this material very educational and useful. :-)
