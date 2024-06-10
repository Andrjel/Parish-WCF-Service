# Serwis Parafii
Projekt usługi pozwalającej na udostępnienie REST api za pomocą WCF, aby odczytywać i zapisywać dane dotyczące parafii w bazie danych. 
## Struktura projektu
```
#Parish 
|-IParishService.cs -> Interfejs/Kontrakt usługi
|-ParishService.cs -> Implementacja kontraktu
|-ParishService.svc -> Plik host'a
|-Web.config -> Plik konfiguracyjny host'a
#Parish.Domain
|-ParishModel.cs -> Model wykorzystany jako encja bazy danych i kontrakt danych w API
#Parish.Infrastructure
|-ParishContext.cs -> Podłączenie do bazy danych mssql za pomocą EF - Code First
#Parish.Tests
|-ParishIntegrationTests.cs -> Testy do wywołania requestów 
|-ParishUnitTests.cs -> Testy jednostkowe 
```
W projekcie wykorzystałem bazę mssql postawioną na kontenerze Docker'a. Aby uruchomić bazę danych należy mieć zainstalowanego Docker Client'a na Win/Mac lub Docker + Docker Compose na systemach Linux. Następnie:
```
# otworzyć terminal/cmd/powershell w katalogu solucji, gdzie znajduje się docker-compose.yaml i wykonać
docker compose up --build -d
# po kilku sekundach baza danych powinna być dostępna, connString znajduję się
# w Web.config
# Aby wyłączyć bazę danych należy wykonać:
docker compose down -v
# Można też użyć lokalnego mssql, należy zmienic config, skrypt inicjujący bazę danych znajduję się w
# mssql/initDB.sql
```
## Testy
Do przetestowania serwisu napisane są testy, po zhostowaniu usługi w IIS można sprawdzić endpointy testami w klasie ParishIntegrationTests.cs.
W folderze znajduje się również pakiet zapytań do Postman'a, tam również można sprawdzić funkcjonalność endpointów.
## Licencja
[Unlicence](https://choosealicense.com/licenses/unlicense/)