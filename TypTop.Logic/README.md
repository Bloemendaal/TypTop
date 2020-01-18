#### Logic

![Imgur](https://i.imgur.com/msHyfZZ.png)

Het project Logic zal gezien kunnen worden als een ‘helper’. In Logic staat namelijk logica zoals de naam zelf zegt. Deze logica wordt gebruikt op verschillende punten in de gehele solution van TypTop. 

De belangrijkste functionaliteit van Logic is het checken van input / woorden. Dit zal plaatsvinden door de woorden van een minigame in te laden in een lijst. Uitleg over de verschillende lijsten is te vinden in de volgende paragraaf. 

Alle karakters van een woord uit een lijst zijn traceerbaar. Door de traceerbaarheid van de individuele letters zijn de volgende functies mogelijk:
- Het vorige getypte character te vinden.
- Hoofdlettergevoelig maken van woorden. 
- Negeren van:
    - Nummers
    - Interpunctie
    - Spaties
    - Speciale karakters 
- Toestaan van spaties bij het typen van een woord.
- Het verwijderen van een woord uit de lijst bij een spatie.
- Het woord verwijderen uit een lijst als hij klaar is. 

Los hiervan biedt Logic ook de functionaliteit om op een gegeven lijst filters toe te passen. Deze zal vervolgens teruggegeven worden voor het gebruik bij een minigame. Bij deze filters zal er gedacht moeten worden aan het stellen van eisen waar een woord aan zal moeten voldoen. De volgende filters zijn beschikbaar:
- Minimale lengte van een woord.
- Maximale lengte van een woord.
- Maximaal aantal woorden in de lijst.
- Het husselen van de woorden. (De woorden staan standaard op alfabetische volgorde).
- Het verplichte gebruik van een set van letters waar minimaal één van deze letters in een woord moet voorkomen.
- Het verplichte gebruik van een set van letters die allemaal in een woord moeten voorkomen.

##### Code

![Imgur](https://i.imgur.com/WEYMVcy.png)

Bovenstaand zichtbaar is het class diagram van Logic. Zoals eerder besproken is er de mogelijkheid om een woord te traceren binnen een lijst. Dit woord is bovenstaand zichtbaar als de class Word, hier zullen ook de individuele letters in worden opgeslagen. Alleen zal dit woord niet traceerbaar zijn zonder een lijst waar dit woord in staat. De filters die op een woord kunnen worden toegepast staan namelijk in de class Input. Hiervan zal een List, Queue of Stack van woorden gemaakt kunnen worden. 
De woorden zullen ook op die manier getraceerd worden, dus bij een InputStack elke keer het meest bovenop liggende woord. Bij een InputQueue, het vooraanstaande woord en bij een InputList zal alles toegankelijk zijn, zoals in een Lijst hoort. 

Naast deze functionaliteit om de woorden te checken is er ook de mogelijkheid om een verzameling woorden te filteren op vereisten. Dit zal plaatsvinden, bij de WordProvider zal een lijst met initiële woorden aangeleverd moeten moeten. Deze zullen vervolgens gefilterd kunnen worden. Voor de uitleg en gebruik hiervan verwijs ik graag door naar de documentatie in de code.

