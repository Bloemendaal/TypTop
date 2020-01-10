<a name='assembly'></a>
# TypTop.JumpMinigame

## Contents

- [EnemyType](#T-TypTop-JumpMinigame-JumpGame-EnemyType 'TypTop.JumpMinigame.JumpGame.EnemyType')
- [JumpGame](#T-TypTop-JumpMinigame-JumpGame 'TypTop.JumpMinigame.JumpGame')
  - [JumpHeight](#F-TypTop-JumpMinigame-JumpGame-JumpHeight 'TypTop.JumpMinigame.JumpGame.JumpHeight')
  - [EnemyAmount](#P-TypTop-JumpMinigame-JumpGame-EnemyAmount 'TypTop.JumpMinigame.JumpGame.EnemyAmount')
  - [EnemyMovement](#P-TypTop-JumpMinigame-JumpGame-EnemyMovement 'TypTop.JumpMinigame.JumpGame.EnemyMovement')
  - [EnemySpawnHeight](#P-TypTop-JumpMinigame-JumpGame-EnemySpawnHeight 'TypTop.JumpMinigame.JumpGame.EnemySpawnHeight')
  - [LaneAmount](#P-TypTop-JumpMinigame-JumpGame-LaneAmount 'TypTop.JumpMinigame.JumpGame.LaneAmount')
  - [LaneWidth](#P-TypTop-JumpMinigame-JumpGame-LaneWidth 'TypTop.JumpMinigame.JumpGame.LaneWidth')
  - [MaximumDistance](#P-TypTop-JumpMinigame-JumpGame-MaximumDistance 'TypTop.JumpMinigame.JumpGame.MaximumDistance')
  - [MinimalDistance](#P-TypTop-JumpMinigame-JumpGame-MinimalDistance 'TypTop.JumpMinigame.JumpGame.MinimalDistance')
  - [PlatformBreakAmount](#P-TypTop-JumpMinigame-JumpGame-PlatformBreakAmount 'TypTop.JumpMinigame.JumpGame.PlatformBreakAmount')
  - [PlatformBreakOffset](#P-TypTop-JumpMinigame-JumpGame-PlatformBreakOffset 'TypTop.JumpMinigame.JumpGame.PlatformBreakOffset')
  - [PlatformSolidRatio](#P-TypTop-JumpMinigame-JumpGame-PlatformSolidRatio 'TypTop.JumpMinigame.JumpGame.PlatformSolidRatio')
  - [SaveJump](#P-TypTop-JumpMinigame-JumpGame-SaveJump 'TypTop.JumpMinigame.JumpGame.SaveJump')
  - [SwitchWords](#P-TypTop-JumpMinigame-JumpGame-SwitchWords 'TypTop.JumpMinigame.JumpGame.SwitchWords')
  - [CheckGeneratePlatforms()](#M-TypTop-JumpMinigame-JumpGame-CheckGeneratePlatforms 'TypTop.JumpMinigame.JumpGame.CheckGeneratePlatforms')
  - [GeneratePlatforms(init,diff)](#M-TypTop-JumpMinigame-JumpGame-GeneratePlatforms-System-Boolean,System-Single- 'TypTop.JumpMinigame.JumpGame.GeneratePlatforms(System.Boolean,System.Single)')
- [Player](#T-TypTop-JumpMinigame-Player 'TypTop.JumpMinigame.Player')
  - [Lane](#P-TypTop-JumpMinigame-Player-Lane 'TypTop.JumpMinigame.Player.Lane')

<a name='T-TypTop-JumpMinigame-JumpGame-EnemyType'></a>
## EnemyType `type`

##### Namespace

TypTop.JumpMinigame.JumpGame

##### Summary

All possible ways an enemy can move.

<a name='T-TypTop-JumpMinigame-JumpGame'></a>
## JumpGame `type`

##### Namespace

TypTop.JumpMinigame

<a name='F-TypTop-JumpMinigame-JumpGame-JumpHeight'></a>
### JumpHeight `constants`

##### Summary

Maximum height the player can jump.

<a name='P-TypTop-JumpMinigame-JumpGame-EnemyAmount'></a>
### EnemyAmount `property`

##### Summary

Amount of enemies to spawn per 100 platforms.

<a name='P-TypTop-JumpMinigame-JumpGame-EnemyMovement'></a>
### EnemyMovement `property`

##### Summary

Set movement of the enemies.

<a name='P-TypTop-JumpMinigame-JumpGame-EnemySpawnHeight'></a>
### EnemySpawnHeight `property`

##### Summary

Minimal height of an enemy to spawn. Default is after one screen height.

<a name='P-TypTop-JumpMinigame-JumpGame-LaneAmount'></a>
### LaneAmount `property`

##### Summary

Amount of lanes that should be used for this level. Minimum amount of unique words must be equal to this value.

<a name='P-TypTop-JumpMinigame-JumpGame-LaneWidth'></a>
### LaneWidth `property`

##### Summary

Width that the lanes should have.

<a name='P-TypTop-JumpMinigame-JumpGame-MaximumDistance'></a>
### MaximumDistance `property`

##### Summary

Maximum distance between the platforms.

<a name='P-TypTop-JumpMinigame-JumpGame-MinimalDistance'></a>
### MinimalDistance `property`

##### Summary

Minimal distance between the platforms.

<a name='P-TypTop-JumpMinigame-JumpGame-PlatformBreakAmount'></a>
### PlatformBreakAmount `property`

##### Summary

Amount of jumps the player can make on a platform until it breaks. 0 will instantly break.

<a name='P-TypTop-JumpMinigame-JumpGame-PlatformBreakOffset'></a>
### PlatformBreakOffset `property`

##### Summary

Offset when generating random Platform break amounts.

<a name='P-TypTop-JumpMinigame-JumpGame-PlatformSolidRatio'></a>
### PlatformSolidRatio `property`

##### Summary

Percentage solid platforms. Default is solid platforms only.

<a name='P-TypTop-JumpMinigame-JumpGame-SaveJump'></a>
### SaveJump `property`

##### Summary

Save the players jump when their timing is not accurate.

<a name='P-TypTop-JumpMinigame-JumpGame-SwitchWords'></a>
### SwitchWords `property`

##### Summary

Switch words when the word was typed correctly.

<a name='M-TypTop-JumpMinigame-JumpGame-CheckGeneratePlatforms'></a>
### CheckGeneratePlatforms() `method`

##### Summary

Checks if platforms should be generated.

##### Parameters

This method has no parameters.

<a name='M-TypTop-JumpMinigame-JumpGame-GeneratePlatforms-System-Boolean,System-Single-'></a>
### GeneratePlatforms(init,diff) `method`

##### Summary

Generate platforms for the player to jump on

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| init | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | Indicates of a starting platform should be drawn. |
| diff | [System.Single](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Single 'System.Single') | The estimated distance that is gerenated. Due to random occurences, it is typically rendered lower than the set difference. Do not go lower than the jumpheight. |

<a name='T-TypTop-JumpMinigame-Player'></a>
## Player `type`

##### Namespace

TypTop.JumpMinigame

<a name='P-TypTop-JumpMinigame-Player-Lane'></a>
### Lane `property`

##### Summary

Current lane the player is jumping in.
