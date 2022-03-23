# Nyhetssida 
Nyhetssida som tar in nyheter från olika flöden

# Teknik
Framework:
.NET 6

Programming Language:
 C#

Frontend:
 BLAZOR WebAssembly

Database:
 Entity Framework
 MSSql

# Projektbeskrivning

Applikationen hämtar in nyheter från angivna källor

Nyheterna kommer i form av en XML

Applikationen läser in XML filen och parsar om xml datat till en lista av en Nyhets object som jag valt att kalla Post

Post innehåller följanded:

• Titel
• Bild, om finns
• Text
• Publiceringsdatum
• Kategori, om finns
• Länk till nyheten som öppnas i nytt fönster
• Källa

Applikationen går igenom vara enda item och lägger till item i vår lista utav post.

Nu när vi har en list av alla post så retunerar vi listan till vår get metod i vårat WebApi.

I Get metoden så sorteras listan baserat på senaste datumet.

I frontenend så kallar vi på get metoden för att få en lista av alla post som vi sen visar upp.

Trycker man på kategori så kommer man till en sida för alla nyheter för kategorin

Det finns en Admin Sida för att kunna lägga till källor.

Det går att spara ner källor i databasen.

