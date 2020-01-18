#### GameWindow
![Imgur](https://i.imgur.com/bgRwfNC.png)

GameWindow is een WPF control die verantwoordelijk is voor de Update en Draw loops van de Games. Games kunnen alleen in een GameWindow draaien, omdat de Draw functie afhankelijk is van een DrawingContext. Dit is een WPF class die gebruikt wordt voor het renderen. De DrawingContext wordt als parameter meegegeven aan de <em> OnRender </em> functie. De OnRender functie wordt aangeroepen voor het tekenen van een control. In GameWindow is deze functie overridden en wordt hij gebruikt voor het renderen van de game. Om er zeker van te zijn dat de GameWindow bij iedere update opnieuw getekend wordt, wordt aan het einde van de update de <em> InvalidateVisual </em> functie aangeroepen.

Een game kan geladen worden door middel van de Start functie. Als een game gestart is, worden de Update en Draw functies van de geladen Game continu aangeroepen. De timer die dit uitvoert, is ingesteld op 60 ticks per seconde. Dit kan echter afwijken, omdat de timers in Windows niet nauwkeurig genoeg zijn. Om er voor te zorgen dat de game goed blijft functioneren met verschillende intervals, wordt gebruik gemaakt van delta tijd.

##### Delta tijd

Delta tijd is het tijdsverschil tussen de vorige frame en de huidige frame. De berekeningen in de minigames worden gebaseerd op dit tijdsverschil. Dit zorgt er voor dat de games niet afhankelijk zijn van de framerate. Het gevolg is dat de games hetzelfde functioneren bij een hoge framerate of een lage framerate.

##### Resolutie
Een lastig probleem bij het renderen van Games is de resolutie. De weergave van de game moet kloppen op verschillende beeldschermen. Het schalen en dynamisch berekenen van alle grafische onderdelen bleek te veel tijd met zich mee te brengen. Daarom heeft het development team ervoor gekozen om 1920X1080 als resolutie aan te houden en GameWindow in een ViewBox te plaatsen. ViewBox is een WPF control die gebruikt wordt om andere controls te schalen. De schaal method van de ViewBox is ingesteld op Uniform. Uniforme schaling vergroot of verkleint met een schaalfactor die in alle richtingen gelijk is. De nadelen van deze methode zijn dat er aan de boven- en onderkant van het scherm zwarte randen kunnen ontstaan en dat de game wazig wordt bij vergroten en minder precies bij verkleinen.

