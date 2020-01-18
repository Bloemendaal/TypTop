#### Game
![Imgur](https://i.imgur.com/uUN9i8J.png)

TypTop.Game is een basis engine die werkt met het Entity-Component System (ECS). Elke [minigame]([minigame](https://github.com/Bloemendaal/TypTop#minigames)) maakt hier gebruik van. Een project in de Minigame folder hoeft niet perse een game te zijn. De menu’s zijn namelijk ook geïmplementeerd als minigame. Dit is bewust gedaan om compatibiliteit te houden met de GameWindow. Hierdoor kan een menu op dezelfde manier geladen worden als een Minigame.

[Entity–component–system (ECS)](https://en.wikipedia.org/wiki/Entity_component_system) is een architectuur die vooral wordt gebruikt bij de ontwikkeling van games. ECS volgt het principe van ‘compositie over overerving’. Dit houdt in dat componenten gebruikt worden door door deze te initialiseren in de constructor van entities. Dit maakt het eenvoudig om componenten te hergebruiken in verschillende entities. Elke entity bestaat uit een of meer components die gedrag of functionaliteit toevoegen. Deze manier van entities opbouwen voorkomt diepe en complexe overerving van classes.

De Game class is de context waarbinnen de entities functioneren. De kernfunctionaliteiten zijn de Update en Draw functies. Deze itereren over de entities en roepen de Render en Update functie van de betreffende entities aan.

##### Timers

Timers worden gebruik om acties uit te stellen of om acties te herhalen. Dit gebeurt op basis van de delta tijd uit de update functie. Alle callbacks uit de timers draaien daardoor op dezelfde thread. Dit heeft als voordeel dat de code thread safe is en minder processor kernen gebruikt.

##### Entity

Entities vertegenwoordigen de individuele "entiteiten" in de Game. Een entity bestaat uit een of meerdere components. De componenten bevatten de data en functionaliteit die samen de entity vormen. De Update en Draw functies van de entity itereren over de components en roepen vervolgens de Render functie aan op components die IDrawable implementeren en de Update functie voor de componenten die IUpdateable implementeren.

##### Component

Components worden toegevoegd aan en beheerd door een entity. Ze vormen de kern van de game en zijn herbruikbare stukjes code die bepalen hoe de entities zich gedragen. Veelvoorkomende components zijn voorgedefinieerd in de engine en kunnen dus in andere games worden gebruikt.

Onderstaande components worden gedeelt tussen alle minigames:

###### Acceleration

Accelereert de component in de richting van de meegegeven vector. Werkt de Velocity bij.

Vereist de componenten:
- Position
- Velocity

###### Camera

Transformeert de positie van de Position zodat het lijkt alsof de Entity meebeweegt met de camera. Camera is static per instantie van een game en transformeert dus alle entities met dezelfde waarde.

###### Click

De Click component wordt gebruikt om muisclicks af te vangen. Entiteiten en andere componenten kunnen dit afvangen door middel van het Click event. Dit event bevat informatie over de positie van de Click.

###### Collision

Collision component wordt gebruikt om collisies tussen entiteiten te detecteren. Collisies worden afgevangen door middel van het Collision event. Dit event wordt aangeroepen als 2 entiteiten met elkaar botsen en bevat informatie over de andere entiteit en een tweedementionale overlap vector.

###### Hover

De Hover component wordt gebruikt om muis hover af te vangen. Entiteiten en andere componenten kunnen dit afvangen door middel van het Hover event.

###### Image

Rendert een afbeelding op het scherm op de positie van Position. Wanneer Width en Height beide niet ingesteld zijn, heeft de afbeelding het originele formaat. Wanneer Width of Height ingesteld zijn, wordt de ander aangepast zodat de afbeelding zijn oorspronkelijke verhoudingen behoudt. Wanneer Width en Height beide ingesteld zijn, wordt de afbeelding gestretcht. Let op, bij het draaien van de afbeelding worden de oorspronkelijke verhoudingen aangehouden, dit betekent dat draaien kan veroorzaken dat de afbeelding kleiner op het scherm lijkt te staan. Probeer draaien zo min mogelijk te gebruiken aangezien dit relatief veel CPU vereist.

Vereist de componenten:
- Position

###### Label

Rendert een FormattedText op de positie van Position met optionele transformatie via TransformX en TransformY. Met de opties Center en Middle kan de anchorpoint van het label horizontaal en verticaal gecentreerd worden (t.o.v. de oorspronkelijke top left).

Vereist de componenten:
- Position

###### Position

Geeft de positie van de Entity. De X en Y geven de relatieve positie terug wanneer de Camera is ingesteld. Let op, wanneer de Camera is ingesteld, blijft de setter van X en Y de absolute positie en wordt dit niet de relatieve positie. Gebruik van de += en -= zijn hierdoor niet meer betrouwbaar, gebruik altijd AbsoluteX en AbsoluteY hiervoor.

Optioneel vooraf toevoegen:
- Camera

###### Velocity

De snelheid van de component in de richting van de meegegeven vector. Werkt de Position bij.

Vereist de componenten:
- Position

###### Word

Rendert een woord op de positie van Position met optionele transformatie via TransformX en TransformY. Met de opties Center en Middle kan de anchorpoint van het label horizontaal en verticaal gecentreerd worden (t.o.v. de oorspronkelijke top left). Kleuren kunnen ingesteld worden waardoor de voortgang van het typen van de woorden gevisualiseerd wordt.

Vereist de componenten:
- Position

##### Code
![Imgur](https://i.imgur.com/gUkA4nq.png)

Hierboven is de klassendiagram van GameEngine weergegeven, uitgezonderd van de map Components.

![Imgur](https://i.imgur.com/NwcGUHN.png)

Hierboven zijn de klassen uit de map Components in GameEngine weergegeven in betrekking tot andere klassen uit GameEngine.