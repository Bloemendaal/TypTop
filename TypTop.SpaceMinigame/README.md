##### Space Minigame

![Imgur](https://i.imgur.com/5yUh9qJ.png)

Support voor de volgende wincondities:
- <strong>ScoreCondition</strong>
    - Sterren gebaseerd op score.
    - Finish gebaseerd op levens en countdown.
    - Vereist de volgende properties:
        - <strong>Lives : long</strong>
        Aantal levens

Optionele properties:
- <strong>EnemyAmount : long</strong>
    Aantal Enemy’s dat geladen moet worden. Standaard is gelijk aan het aantal woorden.
- <strong>EnemyVelocity : double</strong>
    Snelheid dat de Enemy’s moeten gaan. Standaard is 1. 
- <strong>EnemyVelocityOffset : double</strong>
    Maximale offset van de snelheid van de Enemy’s. Standaard is 0.
- <strong>LineHeight : double</strong>
    Hoogte van de lijn. Standaard is 950.

###### Code

![Imgur](https://i.imgur.com/cLocLkZ.png)

In de bovenstaande afbeelding is het class diagram te zien van de SpaceGame. In deze diagram worden de entity, component en minigame als black box gezien. Vanwege de reden van eventuele onduidelijkheden zijn hier ook geen generalisaties getekend. Dit is opgelost door de zichtbare kleuren. Een voorbeeld: Laser erft over van Entity, SpaceGame van Minigame en LineComponent van Component. 

Ook zijn in dit diagram zichtbaar welke entities gebruik maken van een Components die uit GameEngine voortkomen, dit geldt ook voor de Entities die voortkomen uit MinigameEngine. InputList is aan de rechterzijde van het diagram zichtbaar in het cyaan, de class komt uit Logic.
