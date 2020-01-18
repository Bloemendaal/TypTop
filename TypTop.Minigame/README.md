##### Minigame engine

De minigame engine wordt gebruikt door alle minigames en heeft daarmee als grote verschil ten opzichte van de game engine dat deze de levens, score, tijd, wincondities en eindcondities bij kan houden.

De minigame engine controleert elke update loop of de eindconditie al voltooid is. Wanneer dit het geval is wordt het OnFinished event aangeroepen met de FinishEventArgs om zo de behaalde levelinformatie door te geven.

Belangrijkste toevoegingen ten opzichte van GameEngine:
- Lives wordt gebruikt om het aantal levens bij te houden en weer te geven. Lives heeft een visueel element en krijgt daardoor coördinaten mee om deze te kunnen plaatsen.
- Count kan dienen als countdown of als stopwatch. Wanneer het aantal meegegeven seconden 0 is, wordt er een stopwatch aangemaakt. Anders wordt er afgeteld totdat het verschil in seconden bereikt is. Count heeft een visueel element en krijgt daardoor coördinaten mee om deze te kunnen plaatsen.
- Score wordt gebruikt om het aantal levens bij te houden en weer te geven. Score heeft een visueel element en krijgt daardoor coördinaten mee om deze te kunnen plaatsen.
- Background zet een image als achtergrond.
- De Constructor heeft een string nodig met de locatie van de image. Deze gaat er al vanuit dat er in de map Images gekeken moet worden. De complete locatie wordt dus Images/{string}. Verder moet er nog een instantie van Game meegegeven worden.

###### Code

De figuur is een export vanuit Visual Studio. Zie de pijlen onder de naam van de class voor de overerving.

![Imgur](https://i.imgur.com/A4nt7Pk.png)