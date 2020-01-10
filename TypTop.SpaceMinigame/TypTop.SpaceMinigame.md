<a name='assembly'></a>
# TypTop.SpaceMinigame

## Contents

- [Enemy](#T-TypTop-SpaceMinigame-Enemy 'TypTop.SpaceMinigame.Enemy')
  - [Update(deltaTime)](#M-TypTop-SpaceMinigame-Enemy-Update-System-Single- 'TypTop.SpaceMinigame.Enemy.Update(System.Single)')
- [LaserComponent](#T-TypTop-SpaceMinigame-Components-LaserComponent 'TypTop.SpaceMinigame.Components.LaserComponent')
  - [Draw(context)](#M-TypTop-SpaceMinigame-Components-LaserComponent-Draw-System-Windows-Media-DrawingContext- 'TypTop.SpaceMinigame.Components.LaserComponent.Draw(System.Windows.Media.DrawingContext)')
- [LineComponent](#T-TypTop-SpaceMinigame-Components-LineComponent 'TypTop.SpaceMinigame.Components.LineComponent')
  - [AddedToEntity()](#M-TypTop-SpaceMinigame-Components-LineComponent-AddedToEntity 'TypTop.SpaceMinigame.Components.LineComponent.AddedToEntity')
  - [Draw(context)](#M-TypTop-SpaceMinigame-Components-LineComponent-Draw-System-Windows-Media-DrawingContext- 'TypTop.SpaceMinigame.Components.LineComponent.Draw(System.Windows.Media.DrawingContext)')
- [SpaceGame](#T-TypTop-SpaceMinigame-SpaceGame 'TypTop.SpaceMinigame.SpaceGame')
  - [OnTextInput(sender,e)](#M-TypTop-SpaceMinigame-SpaceGame-OnTextInput-System-Object,System-Windows-Input-TextCompositionEventArgs- 'TypTop.SpaceMinigame.SpaceGame.OnTextInput(System.Object,System.Windows.Input.TextCompositionEventArgs)')

<a name='T-TypTop-SpaceMinigame-Enemy'></a>
## Enemy `type`

##### Namespace

TypTop.SpaceMinigame

<a name='M-TypTop-SpaceMinigame-Enemy-Update-System-Single-'></a>
### Update(deltaTime) `method`

##### Summary

This method is overridden from entity and is executed every "deltaTime".
The added functionality is checking whether the relevant Enemy is (already) under the line.
If this is the case, this Entity will be removed from the game and from the dependent lists.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| deltaTime | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') |  |

<a name='T-TypTop-SpaceMinigame-Components-LaserComponent'></a>
## LaserComponent `type`

##### Namespace

TypTop.SpaceMinigame.Components

<a name='M-TypTop-SpaceMinigame-Components-LaserComponent-Draw-System-Windows-Media-DrawingContext-'></a>
### Draw(context) `method`

##### Summary

The Draw function originally comes from the IDrawable interface.
This method ensures that the component is drawn.
This will be done every tick of the game.In this case, a dotted line will be drawn between the Player and the relevant Enemy.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.Windows.Media.DrawingContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Media.DrawingContext 'System.Windows.Media.DrawingContext') |  |

<a name='T-TypTop-SpaceMinigame-Components-LineComponent'></a>
## LineComponent `type`

##### Namespace

TypTop.SpaceMinigame.Components

<a name='M-TypTop-SpaceMinigame-Components-LineComponent-AddedToEntity'></a>
### AddedToEntity() `method`

##### Summary

Originally from Component.
This method ensures that the PositionComponent is retrieved from the parent entity.

##### Parameters

This method has no parameters.

<a name='M-TypTop-SpaceMinigame-Components-LineComponent-Draw-System-Windows-Media-DrawingContext-'></a>
### Draw(context) `method`

##### Summary

/// This method ensures that the Spring is drawn at the correct height.
The elevation is taken from _positionComponent. The line is then drawn on the screen.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.Windows.Media.DrawingContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Media.DrawingContext 'System.Windows.Media.DrawingContext') |  |

<a name='T-TypTop-SpaceMinigame-SpaceGame'></a>
## SpaceGame `type`

##### Namespace

TypTop.SpaceMinigame

<a name='M-TypTop-SpaceMinigame-SpaceGame-OnTextInput-System-Object,System-Windows-Input-TextCompositionEventArgs-'></a>
### OnTextInput(sender,e) `method`

##### Summary

This method will be executed with Text input.
For example, several things are done here, such as drawing a laser from killing an enemy.
Remove this Enemy from the correct list.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| sender | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') |  |
| e | [System.Windows.Input.TextCompositionEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Input.TextCompositionEventArgs 'System.Windows.Input.TextCompositionEventArgs') |  |
