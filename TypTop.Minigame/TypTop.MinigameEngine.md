<a name='assembly'></a>
# TypTop.MinigameEngine

## Contents

- [Background](#T-TypTop-MinigameEngine-Background 'TypTop.MinigameEngine.Background')
  - [Height](#P-TypTop-MinigameEngine-Background-Height 'TypTop.MinigameEngine.Background.Height')
  - [Width](#P-TypTop-MinigameEngine-Background-Width 'TypTop.MinigameEngine.Background.Width')
  - [X](#P-TypTop-MinigameEngine-Background-X 'TypTop.MinigameEngine.Background.X')
  - [Y](#P-TypTop-MinigameEngine-Background-Y 'TypTop.MinigameEngine.Background.Y')
- [Count](#T-TypTop-MinigameEngine-Count 'TypTop.MinigameEngine.Count')
  - [Color](#F-TypTop-MinigameEngine-Count-Color 'TypTop.MinigameEngine.Count.Color')
  - [FinishedColor](#F-TypTop-MinigameEngine-Count-FinishedColor 'TypTop.MinigameEngine.Count.FinishedColor')
  - [FontSize](#F-TypTop-MinigameEngine-Count-FontSize 'TypTop.MinigameEngine.Count.FontSize')
  - [Prefix](#F-TypTop-MinigameEngine-Count-Prefix 'TypTop.MinigameEngine.Count.Prefix')
  - [ShowHours](#F-TypTop-MinigameEngine-Count-ShowHours 'TypTop.MinigameEngine.Count.ShowHours')
  - [Suffix](#F-TypTop-MinigameEngine-Count-Suffix 'TypTop.MinigameEngine.Count.Suffix')
  - [Typeface](#F-TypTop-MinigameEngine-Count-Typeface 'TypTop.MinigameEngine.Count.Typeface')
  - [Finished](#P-TypTop-MinigameEngine-Count-Finished 'TypTop.MinigameEngine.Count.Finished')
  - [Seconds](#P-TypTop-MinigameEngine-Count-Seconds 'TypTop.MinigameEngine.Count.Seconds')
  - [SecondsSpent](#P-TypTop-MinigameEngine-Count-SecondsSpent 'TypTop.MinigameEngine.Count.SecondsSpent')
  - [X](#P-TypTop-MinigameEngine-Count-X 'TypTop.MinigameEngine.Count.X')
  - [Y](#P-TypTop-MinigameEngine-Count-Y 'TypTop.MinigameEngine.Count.Y')
  - [Update(deltaTime)](#M-TypTop-MinigameEngine-Count-Update-System-Single- 'TypTop.MinigameEngine.Count.Update(System.Single)')
- [FinishEventArgs](#T-TypTop-MinigameEngine-FinishEventArgs 'TypTop.MinigameEngine.FinishEventArgs')
  - [Count](#F-TypTop-MinigameEngine-FinishEventArgs-Count 'TypTop.MinigameEngine.FinishEventArgs.Count')
  - [ESCPressed](#F-TypTop-MinigameEngine-FinishEventArgs-ESCPressed 'TypTop.MinigameEngine.FinishEventArgs.ESCPressed')
  - [Lives](#F-TypTop-MinigameEngine-FinishEventArgs-Lives 'TypTop.MinigameEngine.FinishEventArgs.Lives')
  - [Score](#F-TypTop-MinigameEngine-FinishEventArgs-Score 'TypTop.MinigameEngine.FinishEventArgs.Score')
  - [Stars](#F-TypTop-MinigameEngine-FinishEventArgs-Stars 'TypTop.MinigameEngine.FinishEventArgs.Stars')
- [FloatDirection](#T-TypTop-MinigameEngine-Score-FloatDirection 'TypTop.MinigameEngine.Score.FloatDirection')
- [FloatingScore](#T-TypTop-MinigameEngine-FloatingScore 'TypTop.MinigameEngine.FloatingScore')
  - [ShowOperator](#F-TypTop-MinigameEngine-FloatingScore-ShowOperator 'TypTop.MinigameEngine.FloatingScore.ShowOperator')
  - [LabelTransformX](#P-TypTop-MinigameEngine-FloatingScore-LabelTransformX 'TypTop.MinigameEngine.FloatingScore.LabelTransformX')
  - [LabelTransformY](#P-TypTop-MinigameEngine-FloatingScore-LabelTransformY 'TypTop.MinigameEngine.FloatingScore.LabelTransformY')
  - [Update(deltaTime)](#M-TypTop-MinigameEngine-FloatingScore-Update-System-Single- 'TypTop.MinigameEngine.FloatingScore.Update(System.Single)')
- [Lives](#T-TypTop-MinigameEngine-Lives 'TypTop.MinigameEngine.Lives')
  - [Amount](#P-TypTop-MinigameEngine-Lives-Amount 'TypTop.MinigameEngine.Lives.Amount')
- [LivesComponent](#T-TypTop-MinigameEngine-Components-LivesComponent 'TypTop.MinigameEngine.Components.LivesComponent')
  - [Hidden](#P-TypTop-MinigameEngine-Components-LivesComponent-Hidden 'TypTop.MinigameEngine.Components.LivesComponent.Hidden')
  - [AddedToEntity()](#M-TypTop-MinigameEngine-Components-LivesComponent-AddedToEntity 'TypTop.MinigameEngine.Components.LivesComponent.AddedToEntity')
  - [Draw(context)](#M-TypTop-MinigameEngine-Components-LivesComponent-Draw-System-Windows-Media-DrawingContext- 'TypTop.MinigameEngine.Components.LivesComponent.Draw(System.Windows.Media.DrawingContext)')
- [Minigame](#T-TypTop-MinigameEngine-Minigame 'TypTop.MinigameEngine.Minigame')
  - [WinCondition](#F-TypTop-MinigameEngine-Minigame-WinCondition 'TypTop.MinigameEngine.Minigame.WinCondition')
  - [Count](#P-TypTop-MinigameEngine-Minigame-Count 'TypTop.MinigameEngine.Minigame.Count')
  - [ESCPressed](#P-TypTop-MinigameEngine-Minigame-ESCPressed 'TypTop.MinigameEngine.Minigame.ESCPressed')
  - [Finish](#P-TypTop-MinigameEngine-Minigame-Finish 'TypTop.MinigameEngine.Minigame.Finish')
  - [Lives](#P-TypTop-MinigameEngine-Minigame-Lives 'TypTop.MinigameEngine.Minigame.Lives')
  - [Score](#P-TypTop-MinigameEngine-Minigame-Score 'TypTop.MinigameEngine.Minigame.Score')
  - [Stars](#P-TypTop-MinigameEngine-Minigame-Stars 'TypTop.MinigameEngine.Minigame.Stars')
  - [Update(deltaTime)](#M-TypTop-MinigameEngine-Minigame-Update-System-Single- 'TypTop.MinigameEngine.Minigame.Update(System.Single)')
- [Score](#T-TypTop-MinigameEngine-Score 'TypTop.MinigameEngine.Score')
  - [Color](#F-TypTop-MinigameEngine-Score-Color 'TypTop.MinigameEngine.Score.Color')
  - [Direction](#F-TypTop-MinigameEngine-Score-Direction 'TypTop.MinigameEngine.Score.Direction')
  - [FontSize](#F-TypTop-MinigameEngine-Score-FontSize 'TypTop.MinigameEngine.Score.FontSize')
  - [LabelTransformX](#F-TypTop-MinigameEngine-Score-LabelTransformX 'TypTop.MinigameEngine.Score.LabelTransformX')
  - [LabelTransformY](#F-TypTop-MinigameEngine-Score-LabelTransformY 'TypTop.MinigameEngine.Score.LabelTransformY')
  - [Negative](#F-TypTop-MinigameEngine-Score-Negative 'TypTop.MinigameEngine.Score.Negative')
  - [Positive](#F-TypTop-MinigameEngine-Score-Positive 'TypTop.MinigameEngine.Score.Positive')
  - [Prefix](#F-TypTop-MinigameEngine-Score-Prefix 'TypTop.MinigameEngine.Score.Prefix')
  - [Right](#F-TypTop-MinigameEngine-Score-Right 'TypTop.MinigameEngine.Score.Right')
  - [ShowOperator](#F-TypTop-MinigameEngine-Score-ShowOperator 'TypTop.MinigameEngine.Score.ShowOperator')
  - [Suffix](#F-TypTop-MinigameEngine-Score-Suffix 'TypTop.MinigameEngine.Score.Suffix')
  - [Typeface](#F-TypTop-MinigameEngine-Score-Typeface 'TypTop.MinigameEngine.Score.Typeface')
  - [Amount](#P-TypTop-MinigameEngine-Score-Amount 'TypTop.MinigameEngine.Score.Amount')
  - [LabelX](#P-TypTop-MinigameEngine-Score-LabelX 'TypTop.MinigameEngine.Score.LabelX')
  - [LabelY](#P-TypTop-MinigameEngine-Score-LabelY 'TypTop.MinigameEngine.Score.LabelY')
  - [DisplayDifference(diff)](#M-TypTop-MinigameEngine-Score-DisplayDifference-System-Int32- 'TypTop.MinigameEngine.Score.DisplayDifference(System.Int32)')
  - [UpdateText()](#M-TypTop-MinigameEngine-Score-UpdateText 'TypTop.MinigameEngine.Score.UpdateText')
- [WinCondition](#T-TypTop-MinigameEngine-WinConditions-WinCondition 'TypTop.MinigameEngine.WinConditions.WinCondition')
  - [Minigame](#P-TypTop-MinigameEngine-WinConditions-WinCondition-Minigame 'TypTop.MinigameEngine.WinConditions.WinCondition.Minigame')

<a name='T-TypTop-MinigameEngine-Background'></a>
## Background `type`

##### Namespace

TypTop.MinigameEngine

<a name='P-TypTop-MinigameEngine-Background-Height'></a>
### Height `property`

##### Summary

Geeft de hoogte van de afbeelding, wanneer de waarde NULL wordt geset, wordt de get berekent aan de hand van de afbeelding proporties. De standaardwaarde is de hoogte van het scherm.

<a name='P-TypTop-MinigameEngine-Background-Width'></a>
### Width `property`

##### Summary

Geeft de breedte van de afbeelding, wanneer de waarde NULL wordt geset, wordt de get berekent aan de hand van de afbeelding proporties. De standaardwaarde is de breedte van het scherm.

<a name='P-TypTop-MinigameEngine-Background-X'></a>
### X `property`

##### Summary

De x-positie van de achtergrond. Standaardwaarde is 0.

<a name='P-TypTop-MinigameEngine-Background-Y'></a>
### Y `property`

##### Summary

De y-positie van de achtergrond. Standaardwaarde is 0.

<a name='T-TypTop-MinigameEngine-Count'></a>
## Count `type`

##### Namespace

TypTop.MinigameEngine

<a name='F-TypTop-MinigameEngine-Count-Color'></a>
### Color `constants`

##### Summary

De kleur die de cijfers van Count moet gebruiken. Standaardwaarde is zwart.

<a name='F-TypTop-MinigameEngine-Count-FinishedColor'></a>
### FinishedColor `constants`

##### Summary

De kleur die de cijfers van Count moet gebruiken als de countdown klaar is met aftellen. Standaardwaarde is donkerrood.

<a name='F-TypTop-MinigameEngine-Count-FontSize'></a>
### FontSize `constants`

##### Summary

De grootte van de cijfers van Count. Standaardwaarde is 30.

<a name='F-TypTop-MinigameEngine-Count-Prefix'></a>
### Prefix `constants`

##### Summary

Een prefix die voor de timer gezet moet worden. Standaardwaarde is NULL.

<a name='F-TypTop-MinigameEngine-Count-ShowHours'></a>
### ShowHours `constants`

##### Summary

Geeft aan of in het visuele gedeelte uren weergegeven moeten worden. Standaardwaarde is false.

<a name='F-TypTop-MinigameEngine-Count-Suffix'></a>
### Suffix `constants`

##### Summary

Een suffix die voor de timer gezet moet worden. Standaardwaarde is NULL.

<a name='F-TypTop-MinigameEngine-Count-Typeface'></a>
### Typeface `constants`

##### Summary

Het lettertype dat Count moet gebruiken. Standaardwaarde is Myriad.

<a name='P-TypTop-MinigameEngine-Count-Finished'></a>
### Finished `property`

##### Summary

Geeft aan of de countdown klaar is met aftellen. Standaardwaarde is false. Werkt niet wanneer de Count gebruikt wordt als stopwatch.

<a name='P-TypTop-MinigameEngine-Count-Seconds'></a>
### Seconds `property`

##### Summary

Het aantal seconden dat de countdown nog moet voordat deze klaar is met aftellen. In het geval van een stopwatch gelijk aan SecondsSpent.

<a name='P-TypTop-MinigameEngine-Count-SecondsSpent'></a>
### SecondsSpent `property`

##### Summary

Het aantal seconden dat verstreken is sinds de timer ingesteld is.

<a name='P-TypTop-MinigameEngine-Count-X'></a>
### X `property`

##### Summary

Get en set de X waarde van de positioncomponent van Count.

<a name='P-TypTop-MinigameEngine-Count-Y'></a>
### Y `property`

##### Summary

Get en set de Y waarde van de positioncomponent van Count.

<a name='M-TypTop-MinigameEngine-Count-Update-System-Single-'></a>
### Update(deltaTime) `method`

##### Summary

Werkt de timer bij inclusief eventuele verandering in de style. Zet ook wanneer de countdown klaar is met aftellen.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| deltaTime | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Verschil in tijd. |

<a name='T-TypTop-MinigameEngine-FinishEventArgs'></a>
## FinishEventArgs `type`

##### Namespace

TypTop.MinigameEngine

<a name='F-TypTop-MinigameEngine-FinishEventArgs-Count'></a>
### Count `constants`

##### Summary

De tijd gespendeerd in het level in seconden. Standaardwaarde is NULL.

<a name='F-TypTop-MinigameEngine-FinishEventArgs-ESCPressed'></a>
### ESCPressed `constants`

##### Summary

Checks if ESC was pressed when finished.

<a name='F-TypTop-MinigameEngine-FinishEventArgs-Lives'></a>
### Lives `constants`

##### Summary

Het aantal levens dat nog over is. Standaardwaarde is NULL.

<a name='F-TypTop-MinigameEngine-FinishEventArgs-Score'></a>
### Score `constants`

##### Summary

De behaalde score. Standaardwaarde is NULL.

<a name='F-TypTop-MinigameEngine-FinishEventArgs-Stars'></a>
### Stars `constants`

##### Summary

Het aantal behaalde sterren in het level. Standaardwaarde is 0.

<a name='T-TypTop-MinigameEngine-Score-FloatDirection'></a>
## FloatDirection `type`

##### Namespace

TypTop.MinigameEngine.Score

##### Summary

De mogelijke richtingen waarop een FloatingScore kan zweven zodra er een verandering in de score optreedt.

<a name='T-TypTop-MinigameEngine-FloatingScore'></a>
## FloatingScore `type`

##### Namespace

TypTop.MinigameEngine

<a name='F-TypTop-MinigameEngine-FloatingScore-ShowOperator'></a>
### ShowOperator `constants`

##### Summary

Geeft aan of de FloatingScore de + / - voor het verschil moet weergeven. Standaardwaarde is true.

<a name='P-TypTop-MinigameEngine-FloatingScore-LabelTransformX'></a>
### LabelTransformX `property`

##### Summary

Het aantal dat moet toegevoegd worden aan de x van de label. Standaardwaarde is de TransformX van de LabelComponent.

<a name='P-TypTop-MinigameEngine-FloatingScore-LabelTransformY'></a>
### LabelTransformY `property`

##### Summary

Het aantal dat moet toegevoegd worden aan de y van de label. Standaardwaarde is de TransformY van de LabelComponent.

<a name='M-TypTop-MinigameEngine-FloatingScore-Update-System-Single-'></a>
### Update(deltaTime) `method`

##### Summary

Voegt een vermindering van de Opacity toe per update en verwijdert zichzelf wanneer de Opacity 0 is.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| deltaTime | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='T-TypTop-MinigameEngine-Lives'></a>
## Lives `type`

##### Namespace

TypTop.MinigameEngine

<a name='P-TypTop-MinigameEngine-Lives-Amount'></a>
### Amount `property`

##### Summary

Wanneer het aantal levens kleiner is dan 0, wordt deze op 0 gezet.

<a name='T-TypTop-MinigameEngine-Components-LivesComponent'></a>
## LivesComponent `type`

##### Namespace

TypTop.MinigameEngine.Components

<a name='P-TypTop-MinigameEngine-Components-LivesComponent-Hidden'></a>
### Hidden `property`

##### Summary

Geeft aan of de hartjes verborgen moeten zijn of niet.

<a name='M-TypTop-MinigameEngine-Components-LivesComponent-AddedToEntity'></a>
### AddedToEntity() `method`

##### Summary

Stelt de _positionComponent voor het tekenen in.

##### Parameters

This method has no parameters.

<a name='M-TypTop-MinigameEngine-Components-LivesComponent-Draw-System-Windows-Media-DrawingContext-'></a>
### Draw(context) `method`

##### Summary

Tekent de hartjes.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.Windows.Media.DrawingContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Media.DrawingContext 'System.Windows.Media.DrawingContext') | DrawingContext. |

<a name='T-TypTop-MinigameEngine-Minigame'></a>
## Minigame `type`

##### Namespace

TypTop.MinigameEngine

<a name='F-TypTop-MinigameEngine-Minigame-WinCondition'></a>
### WinCondition `constants`

##### Summary

Een instantie van een WinCondition, gezien WinCondition abstract is. WinCondition kan niet NULL zijn.

<a name='P-TypTop-MinigameEngine-Minigame-Count'></a>
### Count `property`

##### Summary

Een instantie van Count. Wordt alleen geset indien het level tijd bij moet houden of een countdown gebruikt. Voor meer informatie, zie Class Count.

<a name='P-TypTop-MinigameEngine-Minigame-ESCPressed'></a>
### ESCPressed `property`

##### Summary

Checks if ESC was pressed when finished.

<a name='P-TypTop-MinigameEngine-Minigame-Finish'></a>
### Finish `property`

##### Summary

Een instantie van delegate FinishCondition, wordt elke update uitgevoerd om te controleren of het spel afgesloten moet worden. Als deze NULL is, zal de minigame nooit uit zichzelf stoppen en moet dan altijd van buitenaf gestopt worden.

<a name='P-TypTop-MinigameEngine-Minigame-Lives'></a>
### Lives `property`

##### Summary

Een instantie van Lives. Wordt alleen geset indien het level levens bij moet houden. Voor meer informatie, zie Class Lives.

<a name='P-TypTop-MinigameEngine-Minigame-Score'></a>
### Score `property`

##### Summary

Een instantie van Score. Wordt alleen geset indien het level score bij moet houden. Voor meer informatie, zie Class Score.

<a name='P-TypTop-MinigameEngine-Minigame-Stars'></a>
### Stars `property`

##### Summary

Geeft het aantal sterren dat op dat moment door de speler behaald is. Wordt berekend aan de hand van de WinCondition.

<a name='M-TypTop-MinigameEngine-Minigame-Update-System-Single-'></a>
### Update(deltaTime) `method`

##### Summary

Deze method is hetzelfde als die van Game uit project GameEngine, het voegt alleen de controle toe of het spel beëindigd moet worden.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| deltaTime | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Verschil in tijd. |

<a name='T-TypTop-MinigameEngine-Score'></a>
## Score `type`

##### Namespace

TypTop.MinigameEngine

<a name='F-TypTop-MinigameEngine-Score-Color'></a>
### Color `constants`

##### Summary

De kleur die de cijfers van Score moet gebruiken. Standaardwaarde is zwart.

<a name='F-TypTop-MinigameEngine-Score-Direction'></a>
### Direction `constants`

##### Summary

De richting waarop een FloatingScore zal zweven zodra er een verandering in de score optreedt. Standaardwaarde is None, er zal geen FloatingScore weergegeven worden.

<a name='F-TypTop-MinigameEngine-Score-FontSize'></a>
### FontSize `constants`

##### Summary

De grootte van de cijfers van Score en FloatingScore. Standaardwaarde is 30.

<a name='F-TypTop-MinigameEngine-Score-LabelTransformX'></a>
### LabelTransformX `constants`

##### Summary

Het aantal dat moet toegevoegd worden aan de x van een FloatingScore. Standaardwaarde is 0.

<a name='F-TypTop-MinigameEngine-Score-LabelTransformY'></a>
### LabelTransformY `constants`

##### Summary

Het aantal dat moet toegevoegd worden aan de y van een FloatingScore. Standaardwaarde is 0.

<a name='F-TypTop-MinigameEngine-Score-Negative'></a>
### Negative `constants`

##### Summary

De kleur die de FloatingScore moet gebruiken als er een negatieve verandering in de score optreedt. Standaardwaarde is donkerrood.

<a name='F-TypTop-MinigameEngine-Score-Positive'></a>
### Positive `constants`

##### Summary

De kleur die de FloatingScore moet gebruiken als er een positieve verandering in de score optreedt. Standaardwaarde is donkergroen.

<a name='F-TypTop-MinigameEngine-Score-Prefix'></a>
### Prefix `constants`

##### Summary

Een prefix die voor de score gezet moet worden. Standaardwaarde is NULL.

<a name='F-TypTop-MinigameEngine-Score-Right'></a>
### Right `constants`

##### Summary

Match de positie van de FloatingScore met de beide rechter uiteindes van de Score en FloatingScore. Standaardwaarde is false.

<a name='F-TypTop-MinigameEngine-Score-ShowOperator'></a>
### ShowOperator `constants`

##### Summary

Geeft aan of de FloatingScore de + / - voor het verschil moet weergeven. Standaardwaarde is true.

<a name='F-TypTop-MinigameEngine-Score-Suffix'></a>
### Suffix `constants`

##### Summary

Een suffix die voor de score gezet moet worden. Standaardwaarde is NULL.

<a name='F-TypTop-MinigameEngine-Score-Typeface'></a>
### Typeface `constants`

##### Summary

Het lettertype dat Score moet gebruiken. Standaardwaarde is Myriad.

<a name='P-TypTop-MinigameEngine-Score-Amount'></a>
### Amount `property`

##### Summary

Roept de method DisplayDifference met het verschil zodra de score bijgewerkt wordt.

<a name='P-TypTop-MinigameEngine-Score-LabelX'></a>
### LabelX `property`

##### Summary

Geeft de X van het label dat gebruikt wordt om de score weer te geven.

<a name='P-TypTop-MinigameEngine-Score-LabelY'></a>
### LabelY `property`

##### Summary

Geeft de Y van het label dat gebruikt wordt om de score weer te geven.

<a name='M-TypTop-MinigameEngine-Score-DisplayDifference-System-Int32-'></a>
### DisplayDifference(diff) `method`

##### Summary

Roept eerst UpdateText() aan en maakt vervolgens een nieuwe instantie aan van FloatingScore wanneer het verschil niet 0 is en er een Direction ingesteld is. Kan alleen opgeroepen worden door de score bij te werken via Amount.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| diff | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | Verschil dat weergegeven moet worden. |

<a name='M-TypTop-MinigameEngine-Score-UpdateText'></a>
### UpdateText() `method`

##### Summary

Werkt de score bij inclusief de styling.

##### Parameters

This method has no parameters.

<a name='T-TypTop-MinigameEngine-WinConditions-WinCondition'></a>
## WinCondition `type`

##### Namespace

TypTop.MinigameEngine.WinConditions

<a name='P-TypTop-MinigameEngine-WinConditions-WinCondition-Minigame'></a>
### Minigame `property`

##### Summary

Wordt automatisch geset door Minigame en gebruikt door de methods om te kunnen berekenen wanneer er een ster behaald is.
