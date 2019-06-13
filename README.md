# Buchhaltung
Dieses Repository enthält die Dokumentation sowie das Programm zum Berechnen diverser Buchhaltungen.
Umgesetzt wird es in ASP.Net MVC.

## Inhalt
Auf unserer Seite können die Benutzer Bilanzen und die Erfolgsrechnung erstellen. Dafür wird zuerst die Eröffnungsbilanz mit den Anfangsbeständen erstellt. 
Danach werden für die einzelnen aktiv und passiv Konten (wie Kasse, VLL oder Eigenkapital) mit den Buchunssätze erfasst (Zunahmen & Abnahmen) 
und diese berechneten Saldos in die Bilanz übertragen, damit die Schlussbilanz mit berechnetem Gewinn oder Verlust ausgegeben wird.

Das Projekt wurde in ASP.NET MVC mit dem UnitOfWork Pattern unter verwendung des Entity Frameworks umgsetzt.

## Gruppenmitglieder
* [Gian](https://github.com/Nichtgian)
* [Manuel](https://github.com/ManuelTroxler)

## Mockup
Die Mockups wurden mit Ninjamock erstellt.

![Mockup Bilanz](src/Mockup-Bilanz.png)
![Mockup Journal](src/Mockup-Journal.png)
![Mockup Adding](src/Mockup-Adding.png)

## Datenbank
Erstes und veraltetes Schema
![DB Schema](src/db.jpg)

ERM
![DB ERM](src/ERM.png)

## Momentaner Stand
![Screenshot Bilanzen](src/Bilanz.png)
![Screenshot Bilanz Details](src/Bilanz-Details.png)
![Screenshot Buchungssatz](src/Buchungssatz.png)
![Screenshot Anfangsbetrag](src/Anfangsbetrag.png)

## Berechnung
Logik nachder Berechnung durch Zunahmen und Abnahmen bei den (aktiv) Konten erfolgt.

![Aktivkonto Kasse](src/Kasse-Logik.png)
 
Die konkrete Logik nachder die Berechnung der Bilanz mit den erfassten Geschäftsfällen erfolgt.
 
![Bilanz](src/Bilanz-Logik.png)

Bei vorhanderner Zeit möchten wir auch das Erstellen der Erfolgsrechnung ermöglichen. Dazu können die die einzelnen Aufwände oder Erträge
erfasst und je nach verlangen als 1-, 2- oder 3-Stufige ER darstellen. 

![Erfolgsrechnung](src/Erfolgsrechnung-Logik.png)
