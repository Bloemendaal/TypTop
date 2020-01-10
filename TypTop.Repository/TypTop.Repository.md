<a name='assembly'></a>
# TypTop.Repository

## Contents

- [ILevelRepository](#T-TypTop-Repository-ILevelRepository 'TypTop.Repository.ILevelRepository')
  - [AddLevel(worldId,index,winCondition,wordProvider,thresholdOneStar,thresholdTwoStars,thresholdThreeStars,variables)](#M-TypTop-Repository-ILevelRepository-AddLevel-System-Int32,System-Int32,TypTop-Shared-WinConditionType,System-String,System-Int32,System-Int32,System-Int32,System-Collections-Generic-Dictionary{System-String,System-Object}- 'TypTop.Repository.ILevelRepository.AddLevel(System.Int32,System.Int32,TypTop.Shared.WinConditionType,System.String,System.Int32,System.Int32,System.Int32,System.Collections.Generic.Dictionary{System.String,System.Object})')

<a name='T-TypTop-Repository-ILevelRepository'></a>
## ILevelRepository `type`

##### Namespace

TypTop.Repository

<a name='M-TypTop-Repository-ILevelRepository-AddLevel-System-Int32,System-Int32,TypTop-Shared-WinConditionType,System-String,System-Int32,System-Int32,System-Int32,System-Collections-Generic-Dictionary{System-String,System-Object}-'></a>
### AddLevel(worldId,index,winCondition,wordProvider,thresholdOneStar,thresholdTwoStars,thresholdThreeStars,variables) `method`

##### Summary

Adds level with given values to the database.
WordProvider as JSON string ( JsonConvert.SerializeObject() ).
Variables as Dictionary.
WORLDID IS DATABASE ID, NOT INDEX.
Use UnitOfWork.Complete() to save in db.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| worldId | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| winCondition | [TypTop.Shared.WinConditionType](#T-TypTop-Shared-WinConditionType 'TypTop.Shared.WinConditionType') |  |
| wordProvider | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
| thresholdOneStar | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| thresholdTwoStars | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| thresholdThreeStars | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| variables | [System.Collections.Generic.Dictionary{System.String,System.Object}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.Dictionary 'System.Collections.Generic.Dictionary{System.String,System.Object}') |  |
