# Backend aplikacji webowej w ASP.NET Core

## Spis treści
* [Struktura projektu](#struktura-projektu)
* [Uruchomienie](#uruchomienie)
* [Technologie](#technologie)
* [pgAdmin 4](#pgadmin-4)
* [Swagger](#swagger)
* [Pliki *.http](#pliki-*.http)

## Struktura projektu

 ```
WebApp - główny folder projektu
├── README.md
├── WebApp.Api - endpointy, Swagger itp.
├── WebApp.Appliaction - modele DTO, implementacja serwisów, interfejsy serwisów i repozytoriów itp.
├── WebApp.Domain - modele encji i modele tzw. common 
├── WebApp.Infrastructure - implementacja repozytoriów, zewnętrznego API Dubailand, kontekst bazy danych, migracje itp.
├── WebApp.sln
└── docker-compose.yml - konfiguracja od lokalnej baza danych na silniku PostgreSQL i panelu administracyjnyego pgAdmin 4
 ```

## Uruchomienie

Do uruchomienia projektu należy pierwszo skorzystać z Dockera w celu uruchomienia bazy danych.

W folderze głównym projektu, gdzie znajduje się plik docker-compose.yml uruchomić jedno z poniższych poleceń w terminalu:

 1.  Przypadek I: Jeśli kontenery od tego projektu nie są zbudowane, należy użyć poniżej komendy do budowania i automatycznego ich uruchmienia:

 ```
 docker-compose up --build
 ```
 2.  Przypadek II: Jeśli kontenery od tego projektu są już zbudowane, należy je jedynie uruchomić za pomocą poniżeszgo polecnia:

  ```
 docker-compose up

 ```

Kolejno należy dodać i zaaplikować migracje raz na początku po zbudowaniu kontenera z bazą danych (musi być on uruchomiony przy tym) przy czym WebApp.Api musi być ustawiony jako startowym projekt, a WebApp.Infrastructure jako domyślny w Powershell z PMC w Visual Studio, korzystając z poniższych poleceń:

1. Do dodawania migracji:

 ```PowerShell z PMC w Visula Studio
 Add-Migration nazwa_migracji
 ```

lub z folderu głównego projektu \WebApp:

```z terminala
dotnet ef migrations add nazwa_migracji --project sciezka_do_projektu_domyslnego --startup-project sciezka_do_projektu_startowego
```

2. Do aplikowania migracji:

```PowerShell z PMC w Visula Studio
Update-Database
```

lub z folderu głównego projektu \WebApp:

```z terminala
dotnet ef database update --project sciezka_do_projektu_domyslnego --startup-project sciezka_do_projektu_startowego
```

- sciezka_do_projektu_domyslnego - ścieżka absolutna do projektu domyślnego, gdzie jest plik \WebApp\WebApp.Infrastructure\WebApp.Infrastructure.csproj, zacznając od głównego folderu projektu,
- sciezka_do_projektu_startowego - ścieżka absolutna do projektu domyślnego, gdzie jest plik \WebApp\WebApp.Api\WebApp.Api.csproj, zacznając od głównego folderu projektu.

 Następnie, aby uruchomić aplikację, należy użyć poniżej komendy w terminalu w folderze /WebApp/Sources/WebApp.Api przy wyłączonym kontenerze od bazy danych.

 
   ```
 dotnet run

 ```

## Technologie

* ASP.NET Core
* .NET 9.0
* Swashbuckle.AspNetCore.SwaggerUI 9.0.3
* Swashbuckle.AspNetCore.SwaggerGen 9.0.3
* Microsoft.EntityFrameworkCore.Tools 9.0.7
* Microsoft.EntityFrameworkCore.Design 9.0.7
* Microsoft.Extensions.DependencyInjection.Abstractions 9.0.7
* Microsoft.EntityFrameworkCore 9.0.7
* Microsoft.Extensions.Http 9.0.7
* Npgsql.EntityFrameworkCore.PostgreSQL 9.0.4
* ITBees.WebApiHttpFilesGenerator 7.0.131
* FluentResults 4.0.0
* Docker
* PostgreSQL
* pgAdmin 4

##  pgAdmin 4

pgAdmin4 działa na http://localhost:8080 po uruchomieniu kontenerów tego projektu za pomocą Dockera.

W celu zalogowania się należy podać dane logowania:
- adres e-mail/nazwa użytkownika: exmaple@mail.com,
- hasło: password.

Następnie dodajemy nowy serwer. 
W zakładce *General* w polu *Name* nazwa dowolna, a w zakładce *Connection* należy podać dane zgodnie z następującymi polami:
- host name/addres: postgres,
- maintenance database: postgresDB,
- username: postgresUser,
- password: password.

## Swagger

Dokumentacja API Swaggera można znaleść po uruchomieniu aplikacji w trybie developerskim pod /swagger.


## Pliki *.http

Do szybkiego testowania wraz z przykładami wywołań endpointów został wygenerowany w folderze /Sources/WebApp.Api/HttpApi.

Jest to plik TransactionsController.http - dotyczy endpointów transakcji.

Porty z pliku /WebApp/Sources/WebApp.Api/http-client.env.json muszą być takie same jak przy port uruchomionej aplikacji, aby zapytania wykonały się poprawnie.