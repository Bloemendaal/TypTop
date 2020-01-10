<a name='assembly'></a>
# TypTop.GameGui

## Contents

- [App](#T-TypTop-GameGui-App 'TypTop.GameGui.App')
  - [InitializeComponent()](#M-TypTop-GameGui-App-InitializeComponent 'TypTop.GameGui.App.InitializeComponent')
  - [Main()](#M-TypTop-GameGui-App-Main 'TypTop.GameGui.App.Main')
- [ExitGame](#T-TypTop-GameGui-ExitGame 'TypTop.GameGui.ExitGame')
- [GameLoader](#T-TypTop-GameGui-GameLoader 'TypTop.GameGui.GameLoader')
  - [#ctor(gameWindow,worlds)](#M-TypTop-GameGui-GameLoader-#ctor-TypTop-GameWindow-GameWindow,System-Collections-Generic-IList{TypTop-GameGui-World}- 'TypTop.GameGui.GameLoader.#ctor(TypTop.GameWindow.GameWindow,System.Collections.Generic.IList{TypTop.GameGui.World})')
  - [LoadLevelMap(world)](#M-TypTop-GameGui-GameLoader-LoadLevelMap-TypTop-GameGui-World- 'TypTop.GameGui.GameLoader.LoadLevelMap(TypTop.GameGui.World)')
  - [LoadMinigame(level)](#M-TypTop-GameGui-GameLoader-LoadMinigame-TypTop-Logic-Level- 'TypTop.GameGui.GameLoader.LoadMinigame(TypTop.Logic.Level)')
  - [LoadWorldMap()](#M-TypTop-GameGui-GameLoader-LoadWorldMap 'TypTop.GameGui.GameLoader.LoadWorldMap')
- [MainWindow](#T-TypTop-GameGui-MainWindow 'TypTop.GameGui.MainWindow')
  - [InitializeComponent()](#M-TypTop-GameGui-MainWindow-InitializeComponent 'TypTop.GameGui.MainWindow.InitializeComponent')

<a name='T-TypTop-GameGui-App'></a>
## App `type`

##### Namespace

TypTop.GameGui

##### Summary

Interaction logic for App.xaml

<a name='M-TypTop-GameGui-App-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

InitializeComponent

##### Parameters

This method has no parameters.

<a name='M-TypTop-GameGui-App-Main'></a>
### Main() `method`

##### Summary

Application Entry Point.

##### Parameters

This method has no parameters.

<a name='T-TypTop-GameGui-ExitGame'></a>
## ExitGame `type`

##### Namespace

TypTop.GameGui

##### Summary

Null object, only used for fade when game closes.

<a name='T-TypTop-GameGui-GameLoader'></a>
## GameLoader `type`

##### Namespace

TypTop.GameGui

##### Summary

Used for loading game screens

##### See Also

- [TypTop.Logic.IGameLoader](#T-TypTop-Logic-IGameLoader 'TypTop.Logic.IGameLoader')

<a name='M-TypTop-GameGui-GameLoader-#ctor-TypTop-GameWindow-GameWindow,System-Collections-Generic-IList{TypTop-GameGui-World}-'></a>
### #ctor(gameWindow,worlds) `constructor`

##### Summary

Initializes a new instance of the [GameLoader](#T-TypTop-GameGui-GameLoader 'TypTop.GameGui.GameLoader') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| gameWindow | [TypTop.GameWindow.GameWindow](#T-TypTop-GameWindow-GameWindow 'TypTop.GameWindow.GameWindow') | The game window. |
| worlds | [System.Collections.Generic.IList{TypTop.GameGui.World}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IList 'System.Collections.Generic.IList{TypTop.GameGui.World}') | The worlds. |

<a name='M-TypTop-GameGui-GameLoader-LoadLevelMap-TypTop-GameGui-World-'></a>
### LoadLevelMap(world) `method`

##### Summary

Loads the level map.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| world | [TypTop.GameGui.World](#T-TypTop-GameGui-World 'TypTop.GameGui.World') | The world. |

<a name='M-TypTop-GameGui-GameLoader-LoadMinigame-TypTop-Logic-Level-'></a>
### LoadMinigame(level) `method`

##### Summary

Loads the specified minigame.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| level | [TypTop.Logic.Level](#T-TypTop-Logic-Level 'TypTop.Logic.Level') | The level. |

<a name='M-TypTop-GameGui-GameLoader-LoadWorldMap'></a>
### LoadWorldMap() `method`

##### Summary

Loads the world map.

##### Parameters

This method has no parameters.

<a name='T-TypTop-GameGui-MainWindow'></a>
## MainWindow `type`

##### Namespace

TypTop.GameGui

##### Summary

Interaction logic for MainWindow.xaml

<a name='M-TypTop-GameGui-MainWindow-InitializeComponent'></a>
### InitializeComponent() `method`

##### Summary

InitializeComponent

##### Parameters

This method has no parameters.
