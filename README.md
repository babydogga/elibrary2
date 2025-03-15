# e-Biblioteka

## Spis treści

- [Opis projektu](#opis-projektu)
- [Funkcjonalności](#funkcjonalności)
- [Technologie](#technologie)
- [Instalacja](#instalacja)
- [Konfiguracja bazy danych](#konfiguracja-bazy-danych)
- [Użytkowanie](#użytkowanie)
- [Struktura projektu](#struktura-projektu)
- [Kontrybucja](#kontrybucja)
- [Licencja](#licencja)

## Opis projektu

**e-Biblioteka** to aplikacja umożliwiająca zarządzanie zasobami biblioteki, takimi jak książki, autorzy i wydawnictwa. Użytkownik może dodawać nowe pozycje, usuwać istniejące oraz przeglądać szczegółowe informacje o nich. Aplikacja wykorzystuje bazę danych SQL do przechowywania informacji.

## Funkcjonalności

- **Zarządzanie książkami**:
  - Dodawanie nowej książki
  - Usuwanie książki
  - Wyświetlanie szczegółów książki

- **Zarządzanie autorami**:
  - Dodawanie nowego autora
  - Usuwanie autora
  - Wyświetlanie szczegółów autora

- **Zarządzanie wydawnictwami**:
  - Dodawanie nowego wydawnictwa
  - Usuwanie wydawnictwa
  - Wyświetlanie szczegółów wydawnictwa

## Technologie

- Język programowania: C#
- Framework: .NET 9
- Baza danych: SQL Server

## Instalacja

1. **Klonowanie repozytorium**:

   ```bash
   git clone https://github.com/babydogga/elibrary2.git
   cd elibrary2

   2. **Przygotowanie środowiska**:

   - Upewnij się, że masz zainstalowany .NET 6 SDK.
   - Zainstaluj SQL Server lub skonfiguruj inną kompatybilną bazę danych SQL.

3. **Instalacja zależności**:

   ```bash
   dotnet restore
   ```

## Konfiguracja bazy danych

1. **Utworzenie bazy danych**:

   - Otwórz SQL Server Management Studio (SSMS) lub inną aplikację do zarządzania bazą danych.
   - Utwórz nową bazę danych o nazwie `eBiblioteka`.

2. **Konfiguracja połączenia**:

   - W pliku `appsettings.json` wprowadź dane do połączenia z bazą danych:
     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=localhost;Database=eBiblioteka;User Id=sa;Password=TwojeHaslo;"
       }
     }
     ```

3. **Migracje bazy danych**:

   - Wykonaj migracje, aby utworzyć odpowiednie tabele w bazie danych:
     ```bash
     dotnet ef database update
     ```

## Użytkowanie

1. **Uruchomienie aplikacji**:

   ```bash
   dotnet run
   ```

2. **Dostęp do aplikacji**:

   - Otwórz przeglądarkę i przejdź pod adres `https://localhost:5001`.

3. **Zarządzanie zasobami**:

   - **Książki**:

     - Przejdź do zakładki "Książki".
     - Aby dodać nową książkę, kliknij "Dodaj książkę" i wypełnij formularz.
     - Aby usunąć książkę, kliknij "Usuń" obok wybranej pozycji.
     - Aby wyświetlić szczegóły książki, kliknij "Szczegóły".

   - **Autorzy**:

     - Przejdź do zakładki "Autorzy".
     - Aby dodać nowego autora, kliknij "Dodaj autora" i wypełnij formularz.
     - Aby usunąć autora, kliknij "Usuń" obok wybranej osoby.
     - Aby wyświetlić szczegóły autora, kliknij "Szczegóły".

   - **Wydawnictwa**:

     - Przejdź do zakładki "Wydawnictwa".
     - Aby dodać nowe wydawnictwo, kliknij "Dodaj wydawnictwo" i wypełnij formularz.
     - Aby usunąć wydawnictwo, kliknij "Usuń" obok wybranego wydawnictwa.
     - Aby wyświetlić szczegóły wydawnictwa, kliknij "Szczegóły".

## Struktura projektu

```
e-biblioteka/
|
├── e-biblioteka.sln
├── README.md
├── appsettings.json
├── Program.cs
├── Controllers/
│   ├── BooksController.cs
│   ├── AuthorsController.cs
│   └── PublishersController.cs
├── Models/
│   ├── Book.cs
│   ├── Author.cs
│   └── Publisher.cs
├── Views/
│   ├── Books/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   ├── Authors/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   └── Publishers/
│       ├── Index.cshtml
│       ├── Create.cshtml
│       ├── Details.cshtml
│       └── Delete.cshtml
└── Data/
    ├── ApplicationDbContext.cs
    └── Migrations/
```

## Kontrybucja

1. Sforkuj repozytorium.
2. Utwórz nową gałąź dla swojej funkcji (`git checkout -b funkcja`).
3. Wprowadź zmiany i skomituj je (`git commit -m 'Dodano nową funkcję'`).
4. Wypchnij zmiany do swojego forka (`git push origin funkcja`).
5. Otwórz Pull Request w oryginalnym repozytorium.

## Licencja

Projekt jest udostępniany na licencji MIT.
