##### Tavern minigame
![Imgur](https://i.imgur.com/2SUzdEk.png)

Er is support voor de volgende wincondities:
- <strong>ScoreCondition</strong>
    - Sterren gebaseerd op score.
    - Finish gebaseerd op countdown.
    - Vereist de volgende properties:
        - <strong>Seconds : long </strong>
        Aantal seconden van de countdown.
- <strong>LifeCondition</strong>
    - Sterren gebaseerd op levens.
    - Finish gebaseerd op levens en countdown.
    - Vereist de volgende properties:
        - <strong>Lives : long </strong>
        Aantal levens
        - <strong>Seconds : long </strong>
        Aantal seconden van de countdown.
- <strong>TimeCondition</strong>
    - Sterren gebaseerd op tijd.
    - Finish gebaseerd op aantal Customer’s in de queue.
    - Vereist de volgende properties:
        - <strong>Queue : long </strong>
        Aantal klanten dat moet toegevoegd worden aan de rij vanaf de start.

Optionele properties:
- <strong> TileAmount : long </strong>
    Aantal Tile’s met unieke Order’s. Standaard 3, minimaal 1 en maximaal 8.
- <strong> MaxCustomers : long </strong>
    Maximaal aantal Customer’s dat in de taverne getekend wordt voordat ze in de  CustomerQueue gestopt worden. Minimaal aantal is 0, maximaal en standaard is 3.
- <strong> ShowSatisfaction : bool </strong>
    Tevredenheid van klanten weergeven. Standaard is false.
- <strong> StartSatisfaction : long </strong>
    Tevredenheid waarop de klanten starten (range 5 - 1, tevreden - boos). Standaard is 5, 0 is weglopen.
- <strong> SatisfactionTiming :  Dictionary<int, int> </strong>
    Tijd dat klanten erover doen om weg te lopen. TKey is de satisfaction (1 - 5) en TValue het aantal milliseconden. Standaard is TValue = 0 is niet van satisfaction veranderen.
- <strong> CustomerSpawnSpeed : long </strong>
    Snelheid in milliseconden waarin de klanten spawnen. Standaard is 4000.
- <strong> CustomerSpawnSpeedOffset : long </strong>
    Maximale offset in milliseconden van de klanten spawnsnelheid. Standaard is 1000.
- <strong> CustomerSpawnSpeedMultiplier : double </strong>
    Vermenigvuldig de spawnsnelheid van Customer’s met 1 + (x * [amount of customers in the queue]). Standaard is 0,1.
- <strong> CustomerMinOrderAmount : long </strong>
    Minimaal aantal bestellingen per Customer. Standaard 1, minimaal 1 en maximaal - CustomerMaxOrderAmount.
- <strong> CustomerMaxOrderAmount : long </strong>
    Minimaal aantal bestellingen per Customer. Standaard 4, maximaal 4 en maximaal CustomerMinOrderAmount.

<strong> Let op! </strong> Het aantal woorden meegegeven in de WordProvider moet groter of gelijk zijn aan het aantal Tiles.

###### Code

![Imgur](https://i.imgur.com/ZpTAVLK.png)

Hierboven is een klassendiagram van de Tavern Minigame weergegeven. Hierbij is door middel van kleurcoderingen onderscheid gemaakt tussen klassen die direct onder TavernGame horen (geel en groen) en externe klassen (lichtere kleuren).

De TavernGame klasse zelf heeft een gele kleur, deze maakt gebruik van verschillende entity-klassen (objecten die van Entity overerven), weergegeven in groen. Al deze klassen maken op hun beurt gebruik van externe Entities (lichtgroen), Components (lichtturkoois) en andere classes (cyaan).



