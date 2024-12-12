MagnetApi

MagnetApi to aplikacja stworzona w języku C# z wykorzystaniem platformy .NET, 
To nowoczesne oprogramowanie do prowadzenia sprzedaży oraz 
wystawiania dokumentów sprzedażowych, dedykowane dla małych
i średnich firm. 
System łączy intuicyjną obsługę z zaawansowanymi funkcjonalnościami, 
co czyni go wszechstronnym narzędziem wspomagającym zarządzanie firmą..
Wymagania systemowe

    .NET Core 3.1 lub nowszy
    System operacyjny: Windows, macOS lub Linux

Instalacja

    Klonowanie repozytorium: Pobierz kod źródłowy z GitHub:

git clone https://github.com/bsdnetpl/MagnetApi.git

Przygotowanie środowiska: Przejdź do katalogu projektu:

cd MagnetApi/MagnetApi

Przywracanie zależności: Użyj narzędzia .NET CLI do przywrócenia pakietów:

dotnet restore

Kompilacja projektu: Skompiluj projekt poleceniem:

    dotnet build

Uruchamianie aplikacji

Aby uruchomić aplikację w trybie deweloperskim, wykonaj:

dotnet run

Aplikacja domyślnie nasłuchuje na porcie 5000.
Konfiguracja

Ustawienia aplikacji znajdują się w pliku appsettings.json. Możesz tam dostosować parametry takie jak połączenie z bazą danych czy ustawienia logowania.
Struktura projektu

    Program.cs: Punkt wejścia aplikacji, konfiguruje i uruchamia hosta.
    Startup.cs: Zawiera konfigurację usług i potoków przetwarzania żądań.
    Controllers/: Zawiera kontrolery obsługujące żądania HTTP.
    Models/: Definiuje modele danych używane w aplikacji.
    Services/: Zawiera logikę biznesową aplikacji.

Testowanie

Projekt zawiera zestaw testów jednostkowych. Aby je uruchomić, przejdź do katalogu z testami i wykonaj:

dotnet test

Wkład

Wszelkie sugestie i wkład w rozwój projektu są mile widziane. Prosimy o tworzenie zgłoszeń (issues) oraz pull requestów na GitHubie.
Licencja

Ten projekt jest licencjonowany na warunkach licencji MIT. Szczegółowe informacje znajdują się w pliku LICENSE.
Kontakt

W razie pytań lub sugestii prosimy o kontakt poprzez [adres e-mail] lub utworzenie zgłoszenia na GitHubie.
