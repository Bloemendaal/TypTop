<a name='assembly'></a>
# TypTop.GameEngine

## Contents

- [AccelerationComponent](#T-TypTop-GameEngine-Components-AccelerationComponent 'TypTop.GameEngine.Components.AccelerationComponent')
  - [Acceleration](#P-TypTop-GameEngine-Components-AccelerationComponent-Acceleration 'TypTop.GameEngine.Components.AccelerationComponent.Acceleration')
  - [Speed](#P-TypTop-GameEngine-Components-AccelerationComponent-Speed 'TypTop.GameEngine.Components.AccelerationComponent.Speed')
- [CameraComponent](#T-TypTop-GameEngine-Components-CameraComponent 'TypTop.GameEngine.Components.CameraComponent')
  - [Position](#P-TypTop-GameEngine-Components-CameraComponent-Position 'TypTop.GameEngine.Components.CameraComponent.Position')
  - [X](#P-TypTop-GameEngine-Components-CameraComponent-X 'TypTop.GameEngine.Components.CameraComponent.X')
  - [Y](#P-TypTop-GameEngine-Components-CameraComponent-Y 'TypTop.GameEngine.Components.CameraComponent.Y')
  - [GetPosition(game)](#M-TypTop-GameEngine-Components-CameraComponent-GetPosition-TypTop-GameEngine-Game- 'TypTop.GameEngine.Components.CameraComponent.GetPosition(TypTop.GameEngine.Game)')
  - [GetX(game)](#M-TypTop-GameEngine-Components-CameraComponent-GetX-TypTop-GameEngine-Game- 'TypTop.GameEngine.Components.CameraComponent.GetX(TypTop.GameEngine.Game)')
  - [GetY(game)](#M-TypTop-GameEngine-Components-CameraComponent-GetY-TypTop-GameEngine-Game- 'TypTop.GameEngine.Components.CameraComponent.GetY(TypTop.GameEngine.Game)')
  - [RemoveCamera(game)](#M-TypTop-GameEngine-Components-CameraComponent-RemoveCamera-TypTop-GameEngine-Game- 'TypTop.GameEngine.Components.CameraComponent.RemoveCamera(TypTop.GameEngine.Game)')
  - [SetPosition(position,game)](#M-TypTop-GameEngine-Components-CameraComponent-SetPosition-System-Numerics-Vector2,TypTop-GameEngine-Game- 'TypTop.GameEngine.Components.CameraComponent.SetPosition(System.Numerics.Vector2,TypTop.GameEngine.Game)')
  - [SetX(x,game)](#M-TypTop-GameEngine-Components-CameraComponent-SetX-System-Single,TypTop-GameEngine-Game- 'TypTop.GameEngine.Components.CameraComponent.SetX(System.Single,TypTop.GameEngine.Game)')
  - [SetY(y,game)](#M-TypTop-GameEngine-Components-CameraComponent-SetY-System-Single,TypTop-GameEngine-Game- 'TypTop.GameEngine.Components.CameraComponent.SetY(System.Single,TypTop.GameEngine.Game)')
- [ClickComponent](#T-TypTop-MinigameEngine-ClickComponent 'TypTop.MinigameEngine.ClickComponent')
  - [Bounds](#P-TypTop-MinigameEngine-ClickComponent-Bounds 'TypTop.MinigameEngine.ClickComponent.Bounds')
  - [CaptureClick(point)](#M-TypTop-MinigameEngine-ClickComponent-CaptureClick-System-Windows-Point- 'TypTop.MinigameEngine.ClickComponent.CaptureClick(System.Windows.Point)')
- [CollisionComponent](#T-TypTop-GameEngine-Components-CollisionComponent 'TypTop.GameEngine.Components.CollisionComponent')
  - [Bounding](#F-TypTop-GameEngine-Components-CollisionComponent-Bounding 'TypTop.GameEngine.Components.CollisionComponent.Bounding')
  - [Update(deltaTime)](#M-TypTop-GameEngine-Components-CollisionComponent-Update-System-Single- 'TypTop.GameEngine.Components.CollisionComponent.Update(System.Single)')
- [CollisionEventArgs](#T-TypTop-GameEngine-Components-CollisionEventArgs 'TypTop.GameEngine.Components.CollisionEventArgs')
  - [Entity](#P-TypTop-GameEngine-Components-CollisionEventArgs-Entity 'TypTop.GameEngine.Components.CollisionEventArgs.Entity')
  - [PenetrationVector](#P-TypTop-GameEngine-Components-CollisionEventArgs-PenetrationVector 'TypTop.GameEngine.Components.CollisionEventArgs.PenetrationVector')
- [Component](#T-TypTop-GameEngine-Component 'TypTop.GameEngine.Component')
  - [Entity](#P-TypTop-GameEngine-Component-Entity 'TypTop.GameEngine.Component.Entity')
  - [AddedToEntity()](#M-TypTop-GameEngine-Component-AddedToEntity 'TypTop.GameEngine.Component.AddedToEntity')
- [DelayedAction](#T-TypTop-GameEngine-DelayedAction 'TypTop.GameEngine.DelayedAction')
- [Entity](#T-TypTop-GameEngine-Entity 'TypTop.GameEngine.Entity')
  - [#ctor(minigame)](#M-TypTop-GameEngine-Entity-#ctor-TypTop-GameEngine-Game- 'TypTop.GameEngine.Entity.#ctor(TypTop.GameEngine.Game)')
  - [ZIndex](#F-TypTop-GameEngine-Entity-ZIndex 'TypTop.GameEngine.Entity.ZIndex')
  - [Game](#P-TypTop-GameEngine-Entity-Game 'TypTop.GameEngine.Entity.Game')
  - [AddComponent(component)](#M-TypTop-GameEngine-Entity-AddComponent-TypTop-GameEngine-Component- 'TypTop.GameEngine.Entity.AddComponent(TypTop.GameEngine.Component)')
  - [Draw(drawingContext)](#M-TypTop-GameEngine-Entity-Draw-System-Windows-Media-DrawingContext- 'TypTop.GameEngine.Entity.Draw(System.Windows.Media.DrawingContext)')
  - [GetComponent\`\`1()](#M-TypTop-GameEngine-Entity-GetComponent``1 'TypTop.GameEngine.Entity.GetComponent``1')
  - [HasComponent\`\`1()](#M-TypTop-GameEngine-Entity-HasComponent``1 'TypTop.GameEngine.Entity.HasComponent``1')
  - [TryGetComponent\`\`1(component)](#M-TypTop-GameEngine-Entity-TryGetComponent``1-``0@- 'TypTop.GameEngine.Entity.TryGetComponent``1(``0@)')
  - [Update(deltaTime)](#M-TypTop-GameEngine-Entity-Update-System-Single- 'TypTop.GameEngine.Entity.Update(System.Single)')
- [Game](#T-TypTop-GameEngine-Game 'TypTop.GameEngine.Game')
  - [Height](#F-TypTop-GameEngine-Game-Height 'TypTop.GameEngine.Game.Height')
  - [Rnd](#F-TypTop-GameEngine-Game-Rnd 'TypTop.GameEngine.Game.Rnd')
  - [Width](#F-TypTop-GameEngine-Game-Width 'TypTop.GameEngine.Game.Width')
  - [AddDelayedAction(callback,millisecondsDelay,cancellationToken)](#M-TypTop-GameEngine-Game-AddDelayedAction-System-Action,System-Int32,System-Threading-CancellationToken- 'TypTop.GameEngine.Game.AddDelayedAction(System.Action,System.Int32,System.Threading.CancellationToken)')
  - [AddEntity(entity)](#M-TypTop-GameEngine-Game-AddEntity-TypTop-GameEngine-Entity- 'TypTop.GameEngine.Game.AddEntity(TypTop.GameEngine.Entity)')
  - [AddTimer(callback,interval)](#M-TypTop-GameEngine-Game-AddTimer-System-Action,System-Int32- 'TypTop.GameEngine.Game.AddTimer(System.Action,System.Int32)')
  - [Draw(drawingContext)](#M-TypTop-GameEngine-Game-Draw-System-Windows-Media-DrawingContext- 'TypTop.GameEngine.Game.Draw(System.Windows.Media.DrawingContext)')
  - [GetEntitiesWithComponent\`\`1()](#M-TypTop-GameEngine-Game-GetEntitiesWithComponent``1 'TypTop.GameEngine.Game.GetEntitiesWithComponent``1')
  - [OnMouseDown(point)](#M-TypTop-GameEngine-Game-OnMouseDown-System-Windows-Point- 'TypTop.GameEngine.Game.OnMouseDown(System.Windows.Point)')
  - [OnMouseHover(point)](#M-TypTop-GameEngine-Game-OnMouseHover-System-Windows-Point- 'TypTop.GameEngine.Game.OnMouseHover(System.Windows.Point)')
  - [OnTextInput(e)](#M-TypTop-GameEngine-Game-OnTextInput-System-Windows-Input-TextCompositionEventArgs- 'TypTop.GameEngine.Game.OnTextInput(System.Windows.Input.TextCompositionEventArgs)')
  - [RemoveEntity(entity)](#M-TypTop-GameEngine-Game-RemoveEntity-TypTop-GameEngine-Entity- 'TypTop.GameEngine.Game.RemoveEntity(TypTop.GameEngine.Entity)')
  - [RemoveEntity\`\`1()](#M-TypTop-GameEngine-Game-RemoveEntity``1 'TypTop.GameEngine.Game.RemoveEntity``1')
  - [Update(deltaTime)](#M-TypTop-GameEngine-Game-Update-System-Single- 'TypTop.GameEngine.Game.Update(System.Single)')
- [GameTimer](#T-TypTop-GameEngine-GameTimer 'TypTop.GameEngine.GameTimer')
- [HoverComponent](#T-TypTop-MinigameEngine-HoverComponent 'TypTop.MinigameEngine.HoverComponent')
  - [Bounds](#P-TypTop-MinigameEngine-HoverComponent-Bounds 'TypTop.MinigameEngine.HoverComponent.Bounds')
  - [CaptureHover(point)](#M-TypTop-MinigameEngine-HoverComponent-CaptureHover-System-Windows-Point- 'TypTop.MinigameEngine.HoverComponent.CaptureHover(System.Windows.Point)')
- [IDrawable](#T-TypTop-GameEngine-IDrawable 'TypTop.GameEngine.IDrawable')
  - [Draw(context)](#M-TypTop-GameEngine-IDrawable-Draw-System-Windows-Media-DrawingContext- 'TypTop.GameEngine.IDrawable.Draw(System.Windows.Media.DrawingContext)')
- [ITimer](#T-TypTop-GameEngine-ITimer 'TypTop.GameEngine.ITimer')
  - [Interval](#P-TypTop-GameEngine-ITimer-Interval 'TypTop.GameEngine.ITimer.Interval')
- [IUpdateable](#T-TypTop-GameEngine-IUpdateable 'TypTop.GameEngine.IUpdateable')
  - [Update(deltaTime)](#M-TypTop-GameEngine-IUpdateable-Update-System-Single- 'TypTop.GameEngine.IUpdateable.Update(System.Single)')
- [ImageComponent](#T-TypTop-GameEngine-Components-ImageComponent 'TypTop.GameEngine.Components.ImageComponent')
  - [Height](#P-TypTop-GameEngine-Components-ImageComponent-Height 'TypTop.GameEngine.Components.ImageComponent.Height')
  - [Hidden](#P-TypTop-GameEngine-Components-ImageComponent-Hidden 'TypTop.GameEngine.Components.ImageComponent.Hidden')
  - [Rotation](#P-TypTop-GameEngine-Components-ImageComponent-Rotation 'TypTop.GameEngine.Components.ImageComponent.Rotation')
  - [Width](#P-TypTop-GameEngine-Components-ImageComponent-Width 'TypTop.GameEngine.Components.ImageComponent.Width')
  - [Draw(context)](#M-TypTop-GameEngine-Components-ImageComponent-Draw-System-Windows-Media-DrawingContext- 'TypTop.GameEngine.Components.ImageComponent.Draw(System.Windows.Media.DrawingContext)')
  - [UpdateImage(bitmapImage)](#M-TypTop-GameEngine-Components-ImageComponent-UpdateImage-System-Windows-Media-Imaging-BitmapImage- 'TypTop.GameEngine.Components.ImageComponent.UpdateImage(System.Windows.Media.Imaging.BitmapImage)')
- [LabelComponent](#T-TypTop-GameEngine-Components-LabelComponent 'TypTop.GameEngine.Components.LabelComponent')
  - [Center](#F-TypTop-GameEngine-Components-LabelComponent-Center 'TypTop.GameEngine.Components.LabelComponent.Center')
  - [Middle](#F-TypTop-GameEngine-Components-LabelComponent-Middle 'TypTop.GameEngine.Components.LabelComponent.Middle')
  - [Text](#F-TypTop-GameEngine-Components-LabelComponent-Text 'TypTop.GameEngine.Components.LabelComponent.Text')
  - [TransformX](#F-TypTop-GameEngine-Components-LabelComponent-TransformX 'TypTop.GameEngine.Components.LabelComponent.TransformX')
  - [TransformY](#F-TypTop-GameEngine-Components-LabelComponent-TransformY 'TypTop.GameEngine.Components.LabelComponent.TransformY')
  - [Height](#P-TypTop-GameEngine-Components-LabelComponent-Height 'TypTop.GameEngine.Components.LabelComponent.Height')
  - [Width](#P-TypTop-GameEngine-Components-LabelComponent-Width 'TypTop.GameEngine.Components.LabelComponent.Width')
- [PositionComponent](#T-TypTop-GameEngine-Components-PositionComponent 'TypTop.GameEngine.Components.PositionComponent')
  - [AbsolutePosition](#P-TypTop-GameEngine-Components-PositionComponent-AbsolutePosition 'TypTop.GameEngine.Components.PositionComponent.AbsolutePosition')
  - [Position](#P-TypTop-GameEngine-Components-PositionComponent-Position 'TypTop.GameEngine.Components.PositionComponent.Position')
  - [X](#P-TypTop-GameEngine-Components-PositionComponent-X 'TypTop.GameEngine.Components.PositionComponent.X')
  - [Y](#P-TypTop-GameEngine-Components-PositionComponent-Y 'TypTop.GameEngine.Components.PositionComponent.Y')
- [RectangleExtension](#T-TypTop-GameEngine-Components-RectangleExtension 'TypTop.GameEngine.Components.RectangleExtension')
  - [Center(rect)](#M-TypTop-GameEngine-Components-RectangleExtension-Center-System-Windows-Rect- 'TypTop.GameEngine.Components.RectangleExtension.Center(System.Windows.Rect)')
- [Utils](#T-TypTop-GameEngine-Utils 'TypTop.GameEngine.Utils')
  - [GetRectangle(index,total,columns,spacing,columnWidth,columnHeight)](#M-TypTop-GameEngine-Utils-GetRectangle-System-Int32,System-Int32,System-Int32,System-Single,System-Single,System-Single- 'TypTop.GameEngine.Utils.GetRectangle(System.Int32,System.Int32,System.Int32,System.Single,System.Single,System.Single)')
  - [ToPoint(vector2)](#M-TypTop-GameEngine-Utils-ToPoint-System-Numerics-Vector2- 'TypTop.GameEngine.Utils.ToPoint(System.Numerics.Vector2)')
  - [ToVector2(point)](#M-TypTop-GameEngine-Utils-ToVector2-System-Windows-Point- 'TypTop.GameEngine.Utils.ToVector2(System.Windows.Point)')
- [VelocityComponent](#T-TypTop-GameEngine-Components-VelocityComponent 'TypTop.GameEngine.Components.VelocityComponent')
  - [Speed](#P-TypTop-GameEngine-Components-VelocityComponent-Speed 'TypTop.GameEngine.Components.VelocityComponent.Speed')
  - [Velocity](#P-TypTop-GameEngine-Components-VelocityComponent-Velocity 'TypTop.GameEngine.Components.VelocityComponent.Velocity')
- [WordComponent](#T-TypTop-GameEngine-Components-WordComponent 'TypTop.GameEngine.Components.WordComponent')

<a name='T-TypTop-GameEngine-Components-AccelerationComponent'></a>
## AccelerationComponent `type`

##### Namespace

TypTop.GameEngine.Components

##### Summary

Adds acceleration behaviour to target entity

##### See Also

- [TypTop.GameEngine.Component](#T-TypTop-GameEngine-Component 'TypTop.GameEngine.Component')
- [TypTop.GameEngine.IUpdateable](#T-TypTop-GameEngine-IUpdateable 'TypTop.GameEngine.IUpdateable')

<a name='P-TypTop-GameEngine-Components-AccelerationComponent-Acceleration'></a>
### Acceleration `property`

##### Summary

Acceleration direction

<a name='P-TypTop-GameEngine-Components-AccelerationComponent-Speed'></a>
### Speed `property`

##### Summary

Acceleration speed

<a name='T-TypTop-GameEngine-Components-CameraComponent'></a>
## CameraComponent `type`

##### Namespace

TypTop.GameEngine.Components

<a name='P-TypTop-GameEngine-Components-CameraComponent-Position'></a>
### Position `property`

##### Summary

Position of the camera.

<a name='P-TypTop-GameEngine-Components-CameraComponent-X'></a>
### X `property`

##### Summary

X coordinate of the camera.

<a name='P-TypTop-GameEngine-Components-CameraComponent-Y'></a>
### Y `property`

##### Summary

Y coordinate of the camera.

<a name='M-TypTop-GameEngine-Components-CameraComponent-GetPosition-TypTop-GameEngine-Game-'></a>
### GetPosition(game) `method`

##### Summary

Get Position by key.

##### Returns

Vector2 coordinates.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | [TypTop.GameEngine.Game](#T-TypTop-GameEngine-Game 'TypTop.GameEngine.Game') | TKey of the Dictionary. |

<a name='M-TypTop-GameEngine-Components-CameraComponent-GetX-TypTop-GameEngine-Game-'></a>
### GetX(game) `method`

##### Summary

Get X by key.

##### Returns

X coordinate.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | [TypTop.GameEngine.Game](#T-TypTop-GameEngine-Game 'TypTop.GameEngine.Game') | TKey of the Dictionary. |

<a name='M-TypTop-GameEngine-Components-CameraComponent-GetY-TypTop-GameEngine-Game-'></a>
### GetY(game) `method`

##### Summary

Get Y by key.

##### Returns

Y coordinate.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | [TypTop.GameEngine.Game](#T-TypTop-GameEngine-Game 'TypTop.GameEngine.Game') | TKey of the Dictionary. |

<a name='M-TypTop-GameEngine-Components-CameraComponent-RemoveCamera-TypTop-GameEngine-Game-'></a>
### RemoveCamera(game) `method`

##### Summary

Removes a camera from the Dictionary of running games. Do not use while running the game.

##### Returns

If the removal was successfull.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| game | [TypTop.GameEngine.Game](#T-TypTop-GameEngine-Game 'TypTop.GameEngine.Game') | TKey of the Dictionary. |

<a name='M-TypTop-GameEngine-Components-CameraComponent-SetPosition-System-Numerics-Vector2,TypTop-GameEngine-Game-'></a>
### SetPosition(position,game) `method`

##### Summary

Set Position by key.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| position | [System.Numerics.Vector2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Numerics.Vector2 'System.Numerics.Vector2') | Vector2 coordinates. |
| game | [TypTop.GameEngine.Game](#T-TypTop-GameEngine-Game 'TypTop.GameEngine.Game') | TKey of the Dictionary. |

<a name='M-TypTop-GameEngine-Components-CameraComponent-SetX-System-Single,TypTop-GameEngine-Game-'></a>
### SetX(x,game) `method`

##### Summary

Set X by key.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| x | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | X coordinate. |
| game | [TypTop.GameEngine.Game](#T-TypTop-GameEngine-Game 'TypTop.GameEngine.Game') | TKey of the Dictionary. |

<a name='M-TypTop-GameEngine-Components-CameraComponent-SetY-System-Single,TypTop-GameEngine-Game-'></a>
### SetY(y,game) `method`

##### Summary

Set Y by key.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| y | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Y coordinate. |
| game | [TypTop.GameEngine.Game](#T-TypTop-GameEngine-Game 'TypTop.GameEngine.Game') | TKey of the Dictionary. |

<a name='T-TypTop-MinigameEngine-ClickComponent'></a>
## ClickComponent `type`

##### Namespace

TypTop.MinigameEngine

##### Summary

Captures mouse clicks

##### See Also

- [TypTop.GameEngine.Component](#T-TypTop-GameEngine-Component 'TypTop.GameEngine.Component')

<a name='P-TypTop-MinigameEngine-ClickComponent-Bounds'></a>
### Bounds `property`

##### Summary

Click capture bounds

<a name='M-TypTop-MinigameEngine-ClickComponent-CaptureClick-System-Windows-Point-'></a>
### CaptureClick(point) `method`

##### Summary

Raises the click event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| point | [System.Windows.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Point 'System.Windows.Point') | The point. |

<a name='T-TypTop-GameEngine-Components-CollisionComponent'></a>
## CollisionComponent `type`

##### Namespace

TypTop.GameEngine.Components

##### Summary

Used for making entities collectable

##### See Also

- [TypTop.GameEngine.Component](#T-TypTop-GameEngine-Component 'TypTop.GameEngine.Component')
- [TypTop.GameEngine.IUpdateable](#T-TypTop-GameEngine-IUpdateable 'TypTop.GameEngine.IUpdateable')

<a name='F-TypTop-GameEngine-Components-CollisionComponent-Bounding'></a>
### Bounding `constants`

##### Summary

The collision bounding

<a name='M-TypTop-GameEngine-Components-CollisionComponent-Update-System-Single-'></a>
### Update(deltaTime) `method`

##### Summary

Updates the component with the specified delta time.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| deltaTime | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The delta time. |

<a name='T-TypTop-GameEngine-Components-CollisionEventArgs'></a>
## CollisionEventArgs `type`

##### Namespace

TypTop.GameEngine.Components

##### Summary

Collision information

<a name='P-TypTop-GameEngine-Components-CollisionEventArgs-Entity'></a>
### Entity `property`

##### Summary

Entity collided with.

<a name='P-TypTop-GameEngine-Components-CollisionEventArgs-PenetrationVector'></a>
### PenetrationVector `property`

##### Summary

Overlap of the collision

<a name='T-TypTop-GameEngine-Component'></a>
## Component `type`

##### Namespace

TypTop.GameEngine

##### Summary

Components are added to give entities extra behaviour

<a name='P-TypTop-GameEngine-Component-Entity'></a>
### Entity `property`

##### Summary

The entity the components is added to

<a name='M-TypTop-GameEngine-Component-AddedToEntity'></a>
### AddedToEntity() `method`

##### Summary

Callback when added to entity.

##### Parameters

This method has no parameters.

<a name='T-TypTop-GameEngine-DelayedAction'></a>
## DelayedAction `type`

##### Namespace

TypTop.GameEngine

##### Summary

Used for executing delayed actions in the game

##### See Also

- [TypTop.GameEngine.ITimed](#T-TypTop-GameEngine-ITimed 'TypTop.GameEngine.ITimed')

<a name='T-TypTop-GameEngine-Entity'></a>
## Entity `type`

##### Namespace

TypTop.GameEngine

##### Summary

Entities with components form the game objects.

<a name='M-TypTop-GameEngine-Entity-#ctor-TypTop-GameEngine-Game-'></a>
### #ctor(minigame) `constructor`

##### Summary

Initializes a new instance of the [Entity](#T-TypTop-GameEngine-Entity 'TypTop.GameEngine.Entity') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| minigame | [TypTop.GameEngine.Game](#T-TypTop-GameEngine-Game 'TypTop.GameEngine.Game') | The minigame. |

<a name='F-TypTop-GameEngine-Entity-ZIndex'></a>
### ZIndex `constants`

##### Summary

De draw depth

<a name='P-TypTop-GameEngine-Entity-Game'></a>
### Game `property`

##### Summary

The game the component is in

<a name='M-TypTop-GameEngine-Entity-AddComponent-TypTop-GameEngine-Component-'></a>
### AddComponent(component) `method`

##### Summary

Adds the component.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| component | [TypTop.GameEngine.Component](#T-TypTop-GameEngine-Component 'TypTop.GameEngine.Component') | The component. |

<a name='M-TypTop-GameEngine-Entity-Draw-System-Windows-Media-DrawingContext-'></a>
### Draw(drawingContext) `method`

##### Summary

Draws the entity.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| drawingContext | [System.Windows.Media.DrawingContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Media.DrawingContext 'System.Windows.Media.DrawingContext') | The drawing context. |

<a name='M-TypTop-GameEngine-Entity-GetComponent``1'></a>
### GetComponent\`\`1() `method`

##### Summary

Gets the component.

##### Returns



##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TComponent | The type of the component. |

##### Remarks

If the component is empty it throws an error

<a name='M-TypTop-GameEngine-Entity-HasComponent``1'></a>
### HasComponent\`\`1() `method`

##### Summary

Determines whether the entity has a component.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TComponent | The type of the component. |

<a name='M-TypTop-GameEngine-Entity-TryGetComponent``1-``0@-'></a>
### TryGetComponent\`\`1(component) `method`

##### Summary

Tries to get the component.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| component | [\`\`0@](#T-``0@ '``0@') | The component. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TComponent | The type of the component. |

<a name='M-TypTop-GameEngine-Entity-Update-System-Single-'></a>
### Update(deltaTime) `method`

##### Summary

Updates the components with the specified delta time.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| deltaTime | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The delta time. |

<a name='T-TypTop-GameEngine-Game'></a>
## Game `type`

##### Namespace

TypTop.GameEngine

<a name='F-TypTop-GameEngine-Game-Height'></a>
### Height `constants`

##### Summary

The height
of the resolution

<a name='F-TypTop-GameEngine-Game-Rnd'></a>
### Rnd `constants`

##### Summary

Helper for generating random values

<a name='F-TypTop-GameEngine-Game-Width'></a>
### Width `constants`

##### Summary

The width
of the resolution

<a name='M-TypTop-GameEngine-Game-AddDelayedAction-System-Action,System-Int32,System-Threading-CancellationToken-'></a>
### AddDelayedAction(callback,millisecondsDelay,cancellationToken) `method`

##### Summary

Adds a delayed action.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callback | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | The callback. |
| millisecondsDelay | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The milliseconds delay. |
| cancellationToken | [System.Threading.CancellationToken](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Threading.CancellationToken 'System.Threading.CancellationToken') | The cancellation token. |

<a name='M-TypTop-GameEngine-Game-AddEntity-TypTop-GameEngine-Entity-'></a>
### AddEntity(entity) `method`

##### Summary

Adds an entity.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| entity | [TypTop.GameEngine.Entity](#T-TypTop-GameEngine-Entity 'TypTop.GameEngine.Entity') | The entity. |

<a name='M-TypTop-GameEngine-Game-AddTimer-System-Action,System-Int32-'></a>
### AddTimer(callback,interval) `method`

##### Summary

Adds a callback timer.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| callback | [System.Action](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Action 'System.Action') | The callback. |
| interval | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The interval. |

<a name='M-TypTop-GameEngine-Game-Draw-System-Windows-Media-DrawingContext-'></a>
### Draw(drawingContext) `method`

##### Summary

Draws the game.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| drawingContext | [System.Windows.Media.DrawingContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Media.DrawingContext 'System.Windows.Media.DrawingContext') | The drawing context. |

<a name='M-TypTop-GameEngine-Game-GetEntitiesWithComponent``1'></a>
### GetEntitiesWithComponent\`\`1() `method`

##### Summary

Gets the entities with the specified component.

##### Returns



##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TComponent | The type of the component. |

<a name='M-TypTop-GameEngine-Game-OnMouseDown-System-Windows-Point-'></a>
### OnMouseDown(point) `method`

##### Summary

Raises the click event in all components

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| point | [System.Windows.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Point 'System.Windows.Point') | The point. |

<a name='M-TypTop-GameEngine-Game-OnMouseHover-System-Windows-Point-'></a>
### OnMouseHover(point) `method`

##### Summary

Raises the hover event in all components

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| point | [System.Windows.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Point 'System.Windows.Point') | The point. |

<a name='M-TypTop-GameEngine-Game-OnTextInput-System-Windows-Input-TextCompositionEventArgs-'></a>
### OnTextInput(e) `method`

##### Summary

Raises the [](#E-TextInput 'TextInput') event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| e | [System.Windows.Input.TextCompositionEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Input.TextCompositionEventArgs 'System.Windows.Input.TextCompositionEventArgs') | The [TextCompositionEventArgs](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Input.TextCompositionEventArgs 'System.Windows.Input.TextCompositionEventArgs') instance containing the event data. |

<a name='M-TypTop-GameEngine-Game-RemoveEntity-TypTop-GameEngine-Entity-'></a>
### RemoveEntity(entity) `method`

##### Summary

Removes the entity.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| entity | [TypTop.GameEngine.Entity](#T-TypTop-GameEngine-Entity 'TypTop.GameEngine.Entity') | The entity. |

<a name='M-TypTop-GameEngine-Game-RemoveEntity``1'></a>
### RemoveEntity\`\`1() `method`

##### Summary

Removes the entity by type.

##### Returns



##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TEntity | The type of the entity. |

<a name='M-TypTop-GameEngine-Game-Update-System-Single-'></a>
### Update(deltaTime) `method`

##### Summary

Updates the game with the specified delta time.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| deltaTime | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The delta time. |

<a name='T-TypTop-GameEngine-GameTimer'></a>
## GameTimer `type`

##### Namespace

TypTop.GameEngine

##### Summary

Used for executing timed actions

##### See Also

- [TypTop.GameEngine.ITimed](#T-TypTop-GameEngine-ITimed 'TypTop.GameEngine.ITimed')
- [TypTop.GameEngine.ITimer](#T-TypTop-GameEngine-ITimer 'TypTop.GameEngine.ITimer')

<a name='T-TypTop-MinigameEngine-HoverComponent'></a>
## HoverComponent `type`

##### Namespace

TypTop.MinigameEngine

##### Summary

Used to capture mouse hover

##### See Also

- [TypTop.GameEngine.Component](#T-TypTop-GameEngine-Component 'TypTop.GameEngine.Component')

<a name='P-TypTop-MinigameEngine-HoverComponent-Bounds'></a>
### Bounds `property`

##### Summary

Hover capture bounds

<a name='M-TypTop-MinigameEngine-HoverComponent-CaptureHover-System-Windows-Point-'></a>
### CaptureHover(point) `method`

##### Summary

Raised the hover event.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| point | [System.Windows.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Point 'System.Windows.Point') | The point. |

<a name='T-TypTop-GameEngine-IDrawable'></a>
## IDrawable `type`

##### Namespace

TypTop.GameEngine

##### Summary

Inherited by components that are drawable

<a name='M-TypTop-GameEngine-IDrawable-Draw-System-Windows-Media-DrawingContext-'></a>
### Draw(context) `method`

##### Summary

Draws the component.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.Windows.Media.DrawingContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Media.DrawingContext 'System.Windows.Media.DrawingContext') | The context. |

<a name='T-TypTop-GameEngine-ITimer'></a>
## ITimer `type`

##### Namespace

TypTop.GameEngine

##### Summary

Returned by timed actions. The Dispose method is used for stopping the timer

##### See Also

- [System.IDisposable](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IDisposable 'System.IDisposable')

<a name='P-TypTop-GameEngine-ITimer-Interval'></a>
### Interval `property`

##### Summary

Controls the interval of the timer.

<a name='T-TypTop-GameEngine-IUpdateable'></a>
## IUpdateable `type`

##### Namespace

TypTop.GameEngine

##### Summary

Inherited by components that are updateable

<a name='M-TypTop-GameEngine-IUpdateable-Update-System-Single-'></a>
### Update(deltaTime) `method`

##### Summary

Updates the component with the specified delta time.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| deltaTime | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The delta time. |

<a name='T-TypTop-GameEngine-Components-ImageComponent'></a>
## ImageComponent `type`

##### Namespace

TypTop.GameEngine.Components

##### Summary

Used to render image on entity

##### See Also

- [TypTop.GameEngine.Component](#T-TypTop-GameEngine-Component 'TypTop.GameEngine.Component')
- [TypTop.GameEngine.IDrawable](#T-TypTop-GameEngine-IDrawable 'TypTop.GameEngine.IDrawable')

<a name='P-TypTop-GameEngine-Components-ImageComponent-Height'></a>
### Height `property`

##### Summary

Height of the image

<a name='P-TypTop-GameEngine-Components-ImageComponent-Hidden'></a>
### Hidden `property`

##### Summary

Indicating whether the image is hidden.

<a name='P-TypTop-GameEngine-Components-ImageComponent-Rotation'></a>
### Rotation `property`

##### Summary

Rotation of the image

<a name='P-TypTop-GameEngine-Components-ImageComponent-Width'></a>
### Width `property`

##### Summary

Width of the image

<a name='M-TypTop-GameEngine-Components-ImageComponent-Draw-System-Windows-Media-DrawingContext-'></a>
### Draw(context) `method`

##### Summary

Draws the component.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [System.Windows.Media.DrawingContext](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Media.DrawingContext 'System.Windows.Media.DrawingContext') | The context. |

<a name='M-TypTop-GameEngine-Components-ImageComponent-UpdateImage-System-Windows-Media-Imaging-BitmapImage-'></a>
### UpdateImage(bitmapImage) `method`

##### Summary

Updates the image with a new bitmap.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bitmapImage | [System.Windows.Media.Imaging.BitmapImage](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Media.Imaging.BitmapImage 'System.Windows.Media.Imaging.BitmapImage') | The bitmap image. |

<a name='T-TypTop-GameEngine-Components-LabelComponent'></a>
## LabelComponent `type`

##### Namespace

TypTop.GameEngine.Components

##### Summary

Used to render text on entity

##### See Also

- [TypTop.GameEngine.Component](#T-TypTop-GameEngine-Component 'TypTop.GameEngine.Component')
- [TypTop.GameEngine.IDrawable](#T-TypTop-GameEngine-IDrawable 'TypTop.GameEngine.IDrawable')

<a name='F-TypTop-GameEngine-Components-LabelComponent-Center'></a>
### Center `constants`

##### Summary

Center rendering of the label

<a name='F-TypTop-GameEngine-Components-LabelComponent-Middle'></a>
### Middle `constants`

##### Summary

Vertical centration

<a name='F-TypTop-GameEngine-Components-LabelComponent-Text'></a>
### Text `constants`

##### Summary

The text
to render

<a name='F-TypTop-GameEngine-Components-LabelComponent-TransformX'></a>
### TransformX `constants`

##### Summary

horizontal offset

<a name='F-TypTop-GameEngine-Components-LabelComponent-TransformY'></a>
### TransformY `constants`

##### Summary

vertical offset

<a name='P-TypTop-GameEngine-Components-LabelComponent-Height'></a>
### Height `property`

##### Summary

Height of the text

<a name='P-TypTop-GameEngine-Components-LabelComponent-Width'></a>
### Width `property`

##### Summary

With of te label

<a name='T-TypTop-GameEngine-Components-PositionComponent'></a>
## PositionComponent `type`

##### Namespace

TypTop.GameEngine.Components

##### Summary

Used by other components to determine Entity position

##### See Also

- [TypTop.GameEngine.Component](#T-TypTop-GameEngine-Component 'TypTop.GameEngine.Component')

<a name='P-TypTop-GameEngine-Components-PositionComponent-AbsolutePosition'></a>
### AbsolutePosition `property`

##### Summary

Gets or sets the absolute position.

<a name='P-TypTop-GameEngine-Components-PositionComponent-Position'></a>
### Position `property`

##### Summary

Render position

<a name='P-TypTop-GameEngine-Components-PositionComponent-X'></a>
### X `property`

##### Summary

Horizontal position where the entity is rendered

<a name='P-TypTop-GameEngine-Components-PositionComponent-Y'></a>
### Y `property`

##### Summary

Vertical Position where the entity is rendered

<a name='T-TypTop-GameEngine-Components-RectangleExtension'></a>
## RectangleExtension `type`

##### Namespace

TypTop.GameEngine.Components

<a name='M-TypTop-GameEngine-Components-RectangleExtension-Center-System-Windows-Rect-'></a>
### Center(rect) `method`

##### Summary

Gets the center of a rectangle

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rect | [System.Windows.Rect](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Rect 'System.Windows.Rect') | The rect. |

<a name='T-TypTop-GameEngine-Utils'></a>
## Utils `type`

##### Namespace

TypTop.GameEngine

<a name='M-TypTop-GameEngine-Utils-GetRectangle-System-Int32,System-Int32,System-Int32,System-Single,System-Single,System-Single-'></a>
### GetRectangle(index,total,columns,spacing,columnWidth,columnHeight) `method`

##### Summary

Gets aligned rectangle.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The index. |
| total | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The total. |
| columns | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The columns. |
| spacing | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The spacing. |
| columnWidth | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Width of the column. |
| columnHeight | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | Height of the column. |

<a name='M-TypTop-GameEngine-Utils-ToPoint-System-Numerics-Vector2-'></a>
### ToPoint(vector2) `method`

##### Summary

Converts to point.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vector2 | [System.Numerics.Vector2](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Numerics.Vector2 'System.Numerics.Vector2') | The vector2. |

<a name='M-TypTop-GameEngine-Utils-ToVector2-System-Windows-Point-'></a>
### ToVector2(point) `method`

##### Summary

Converts to vector2.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| point | [System.Windows.Point](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Windows.Point 'System.Windows.Point') | The point. |

<a name='T-TypTop-GameEngine-Components-VelocityComponent'></a>
## VelocityComponent `type`

##### Namespace

TypTop.GameEngine.Components

##### Summary

Controls the speed of the component in the direction of the given vector.

##### See Also

- [TypTop.GameEngine.Component](#T-TypTop-GameEngine-Component 'TypTop.GameEngine.Component')
- [TypTop.GameEngine.IUpdateable](#T-TypTop-GameEngine-IUpdateable 'TypTop.GameEngine.IUpdateable')

<a name='P-TypTop-GameEngine-Components-VelocityComponent-Speed'></a>
### Speed `property`

##### Summary

Velocity speed multiplier

<a name='P-TypTop-GameEngine-Components-VelocityComponent-Velocity'></a>
### Velocity `property`

##### Summary

Velocity direction

<a name='T-TypTop-GameEngine-Components-WordComponent'></a>
## WordComponent `type`

##### Namespace

TypTop.GameEngine.Components

##### Summary

Renders a word at the position of Position with optional transformation via TransformX and TransformY. With the options Center and Middle,
the anchor point of the label can be centered horizontally and vertically (relative to the original top left).
Colors can be set to visualize the progress of typing the words.

##### See Also

- [TypTop.GameEngine.Component](#T-TypTop-GameEngine-Component 'TypTop.GameEngine.Component')
- [TypTop.GameEngine.IDrawable](#T-TypTop-GameEngine-IDrawable 'TypTop.GameEngine.IDrawable')
