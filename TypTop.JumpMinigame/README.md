##### Jump Minigame

Support voor de volgende wincondities:
- <strong> ScoreCondition</strong>
    - Sterren gebaseerd op score.
    - Finish gebaseerd op spelerhoogte (en eventueel op countdown en levens).
        
Optionele properties:
- <strong> LaneAmount : long</strong>
Aantal lanes dat gebruikt moet worden. Standaard 5 en minimaal 2.
 - <strong> <span style="color:darkgray"> EnemySpawnHeight : double</strong>
Minimale hoogte voordat Enemy’s gespawnd mogen worden. Standaard de hoogte van het scherm.</span>
- <strong> <span style="color:darkgray">EnemyAmount : double</strong>
Aantal Enemy’s per 100 Platform’s. Standaard is 0. </span>
- <strong> <span style="color:darkgray">EnemyMovement : int || EnemyType</strong>
Richting waarop de Enemy’s bewegen. Standaard is All (Static, Horizontal & Vertical). </span>
- <strong> MinimalDistance : long</strong>
Minimale afstand tussen de platformen. Standaard en minimum is Platform.Height + 5, maximum is MaximumDistance.
- <strong> MaximumDistance : long</strong>
Maximale afstand tussen de platformen. Standaard en maximum is JumpHeight (400), minimum is MinimalDistance.
- <strong> PlatformBreakAmount : long</strong>
Aantal keer dat de Player op de Platforms kan springen. Standaard is 0 en breekt in 1 keer.
- <strong> PlatformBreakOffset : long</strong>
Maximale willekeurige break offset die gebruikt wordt bij het genereren van Platform’s. Standaard is 0.
- <strong> PlatformSolidRatio : double</strong>
Ratio tussen breekbare en vaste Platforms. Waarde tussen 0 en 1 (percentage). Standaard is 1 (alles vast).
- <strong> SwitchWords : bool</strong>
Wissel van woorden als de speler een woord goed getypt heeft. Standaard is true.
- <strong> Seconds : long</strong>
Aantal seconden dat het level duurt. Standaard is zonder countdown. Beïnvloed de finish conditie.
- <strong> Lives : long</strong>
Aantal levens dat de speler heeft. Wordt alleen geset als het EnemyAmount groter is dan 0. Standaard is zonder levens, Enemy aanraken is per direct af.
- <strong> SaveJump : bool</strong>
Red de speler wanneer de timing niet goed was door een keer extra in de lucht te springen. Standaard is false.



<strong> Let op! </strong> Het aantal woorden meegegeven in de WordProvider moet groter of gelijk zijn aan het aantal Lanes.

###### Code

![Imgur](https://i.imgur.com/0i6S3vD.png)

In bovenstaand figuur worden enkel de public attributes, properties en methods weergegeven die niet overriden of al bestaan in een ander diagram. Zie links onderaan voor de legenda.

