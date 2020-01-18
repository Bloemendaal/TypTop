# TypTop
![Imgur](https://i.imgur.com/LvYQlKZ.jpg)
In dit document zijn de technische ontwerp keuzes de ontwikkelaars van TypTop vastgelegd. Om een duidelijk beeld te geven, wordt gebruik gemaakt van het [C4 model](https://c4model.com/). Aangezien TypTop een losstaande applicatie is, wordt niveau 1, de [systeem context](https://c4model.com/#SystemContextDiagram), overgeslagen.

## Wat is TypTop?
In het kort, TypTop is een applicatie om kinderen te voorzien van een typecursus waarbij de focus ligt op de plezier ervaring. Daarom zal deze cursus bestaan uit verschillende onderdelen, het voornaamste deel bestaat uit minigames. De minigames zijn opgedeeld in werelden, binnen één wereld kan alleen één soort minigame voorkomen. Deze specifieke minigame wordt vervolgens aangeboden in verschillende levels met daarin variaties in moeilijkheidsgraad.

## Leeswijzer
Hier staan een aantal richtlijnen hoe dit document het beste gelezen kan worden.
- Het is aan te raden om eerst het functioneel ontwerp te bekijken om een duidelijk beeld te krijgen van het doel van de applicatie.
- Referenties naar andere onderdelen of hoofdstukken zijn gelinkt om makkelijk te navigeren.
- Documentatie over eventuele properties, variabelen of methodes zijn terug te vinden in de source code.
- Binnen dit document wordt het [C4 model](https://c4model.com/) gehanteerd. Zo zal er ingezoomd worden per onderdeel.
- Bij enkele class diagrams zijn kleuren gebruikt voor verduidelijking. De betekenissen van deze kleuren staan aangegeven in hetzelfde diagram.
- <span style="color:darkgray"> Grijs gemarkeerde tekst </span> is conceptueel en (nog) niet geïmplementeerd.
- Enkele diagrammen kunnen onduidelijk of niet scherp zijn. Deze zullen ook terug te vinden zijn in de bijlage van dit document.

Geschreven over/voor:
- Algemene structuur
- Minigame programmeurs
- Levelmap of Wereldmap programmeurs
- Logica ontwerpers

## Containers
![Imgur](https://i.imgur.com/J1Zg8Ah.png)
De doelgroep van TypTop zijn kinderen onder de twaalf jaar oud die willen leren typen of daartoe de opdracht hebben gekregen van hun ouders/voogden of school Deze rol is te zien als Leerling in het bovenstaande diagram

De leerling gebruikt de TypTop applicatie om te leren typen. Dit gaat gebeuren door middel van minigames die de leerling speelt.

De TypTop applicatie is geschreven in .NET Core en .NET Standard. Deze zal gecompileerd worden in een client-side desktop applicatie. Vervolgens wordt een connectie met de database gemaakt.

Elke leerling heeft een eigen account <span style="color:darkgray"> waarvan de voortgang wordt opgeslagen in een Microsoft SQL Server database. </span> Er wordt Entity Framework gebruikt voor de connectie met en het beheer van de database. Met behulp van Entity Framework is het mogelijk om objecten als instantie in de database te zetten.

### TypTop Applicatie
![Imgur](https://i.imgur.com/5T9Xsbu.png)
[Dependencies Graph full size](https://i.imgur.com/aUyUhei.png)

Bovenstaand diagram is het overzicht van de verschillende componenten van TypTop, dit zijn de ook verschillende projecten van de C# solution. Een pijl betekent dat een bepaald project afhankelijk is van een ander project. Er is een eigen [GameEngine](https://github.com/Bloemendaal/TypTop/tree/dev/TypTop.GameEngine#game) ontwikkelt. Deze engine werkt met het Entity-Component System (ECS). Elke [minigame](https://github.com/Bloemendaal/TypTop#minigames) maakt hier gebruik van. In TypTop.Minigame worden specifiekere onderdelen van de minigames bepaald, zoals levens en score. Om de weergave van het [WorldScreen](https://github.com/Bloemendaal/TypTop/tree/dev/TypTop.WorldScreen#world-screen) en [LevelScreen](https://github.com/Bloemendaal/TypTop/tree/dev/TypTop.LevelScreen#level-screen) te vergemakkelijken worden ook deze als minigame geïmplementeerd en behandeld. 

[LoginGui](https://github.com/Bloemendaal/TypTop/tree/dev/TypTop.LoginGui#login-gui) is de launcher waarin de gebruiker een account aanmaakt en inlogt. [GameGui](https://github.com/Bloemendaal/TypTop/tree/dev/TypTop.GameGui#gamegui) is het venster waar de GameWindow in draait, een WPF control die verantwoordelijk is voor de Update en Draw loops van de Games. [TypTop.Database](https://github.com/Bloemendaal/TypTop/tree/dev/TypTop.LoginGui#login-gui) bevat alles wat te maken heeft met Entity Framework en wordt alleen aangeroepen vanuit [Repository](https://github.com/Bloemendaal/TypTop/tree/dev/TypTop.LoginGui#login-gui), het project dat voor de koppeling tussen Entity Framework en de rest van het programma zorgt. [Logic](https://github.com/Bloemendaal/TypTop/tree/dev/TypTop.Logic#logic) bevat logica die op verschillende punten in de solution wordt gebruikt.

#### Minigames

![Imgur](https://i.imgur.com/VgW58fn.png)
Alle minigames maken gebruik van de [MinigameEngine](https://github.com/Bloemendaal/TypTop/tree/dev/TypTop.Minigame#minigame-engine) die zelf weer overerft van [GameEngine](https://github.com/Bloemendaal/TypTop/tree/dev/TypTop.GameEngine#game). Alle minigames hebben qua constructor eenzelfde opbouw om compatibel te zijn met de Level class, waarin alle benodigde informatie wordt gezet om een minigame te kunnen laden. De properties worden afgelezen en de wincondities worden ingesteld. Sommige minigames vereisen een aantal properties, zonder deze zal er een foutmelding gegeven worden. Alle mogelijke properties staan per minigame aangegeven.

WinCondition is een abstracte class waarvan alle wincondities overerven. Deze bevat onder andere de methodes OneStar(), TwoStar() en ThreeStar() om daarmee het aantal behaalde sterren te kunnen berekenen. Deze zijn in classes verdeeld omdat wincondities bij de meeste minigames overeenkomen.
