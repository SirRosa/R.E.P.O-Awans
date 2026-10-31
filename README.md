# R.E.P.O Awans — testowy fork Improve 1.2.1

Oparty na [headclef/Repo-Improve](https://github.com/headclef/Repo-Improve/tree/development) (licencja MIT).

**Zmiana:** otwieranie okna levelowania klawiszem **F5** w **menu głównym** R.E.P.O. 0.5.0. Usunięto dodawane do menu przyciski, których pozycjonowanie kolidowało z nowym układem. Korzysta z REPOModding MenuLib 2.6.0.

Klawisz można skonfigurować w `BepInEx/config/headclef.Improve.cfg` — sekcja `[Interface]`.

### Instalacja
1. Wyłącz oryginalny **Improve**; oba mody mają ten sam GUID `headclef.Improve` i nie mogą działać jednocześnie.
2. Zainstaluj BepInEx 5.4.2305, **MenuLib 2.6.0** i **Relay 1.0.0**.
3. Umieść `Improve.dll` z testowej paczki GitHub Actions w katalogu `BepInEx/plugins`.
4. Naciśnij **F5** w menu głównym. Skrót nie jest przeznaczony do lobby ani rozgrywki.

### Bezpieczeństwo danych
Pozostawiono oryginalny identyfikator, kod naliczania haul/statystyk, synchronizację i format zapisów. Przed testem wykonaj kopię danych Improve.
To **wersja testowa**. Poprawna kompilacja nie oznacza potwierdzonej kompatybilności wszystkich hooków z R.E.P.O. 0.5.0.

### Kompilacja
.NET 8 SDK. Pobierz `Relay.dll` 1.0.0 do `libs/Relay.dll` i uruchom `dotnet build Improve.csproj -c Release`.
Workflow GitHub Actions pobiera Relay automatycznie, kompiluje i udostępnia paczkę ZIP w artefaktach.

### Autorstwo
Oryginalny kod: headclef, MIT. Szczegóły w `LICENSE` i `docs/UPSTREAM_README.md`. To nieoficjalna aktualizacja.
