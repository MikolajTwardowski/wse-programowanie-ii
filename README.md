# wse-programowanie-ii
Projekt zaliczeniowy na "Podstawy programowania II"

3.0: 1-3 pkt
3.5: 4-5 pkt
4.0: 6-7 pkt
4.5: 8-9 pkt
5.0: 10-11 pkt

Poszczególne wymagania
1. Logiczne rozdzielenie kodu na klasy i metody
2. Poruszanie się postaci po ekranie przez input z klawiatury
3. Ograniczenie poruszania się np. przez nieprzenikalne ściany
4. Poruszanie się NPC
5. Interakcja z NPC - wrodzy/przyjaźni
6. Interakcja z przedmiotami leżącymi na planszy - podnoszenie ich
7. Inwentarz - dodawanie, przechowywanie i zużywanie przedmiotów
8. Losowe rozmieszczenie przedmiotów i NPC
9. Przechodzenie na inną planszępo wejściu na jakiś znak na mapie (schody, drabina czy drzwi na krańcach aktualnej planszy)
10. Walka/zadanie wymagające minigry, np. ciepło-zimno, kamień-papier-nożyce itp.
11. Coś dodatkowego ambitnego spoza tej listy (np. proceduralnie generowane poziomy)

############################################################################################################################

Polecam stosować jednolite nazewnictwo commitów -> [https://gist.github.com/qoomon/5dfcdf8eec66a051ecd85625518cfd13](url)

Generowanie assetów do build & debug
1. Zaznaczamy Program.cs (explorator w VSCode)
2. Klikamy "F1"
3. Wpisujemy "Gen"... -> powinna wyskoczyć podpowiedź uzupełniająca "Generate Assets for Build and Debug"
4. Zatwierdzić komendę kliknięciem
5. (opcjonalnie) w .vscode/launch.json przy parametrze "console" zmienić wartość na "externalTerminal"
