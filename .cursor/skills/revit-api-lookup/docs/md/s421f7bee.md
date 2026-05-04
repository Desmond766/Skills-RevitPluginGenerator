---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Railing.SetMultistoryStairsPlacementLevels(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
zh: 栏杆
source: html/47227a43-299a-e762-1e2a-acafb14093a3.htm
---
# Autodesk.Revit.DB.Architecture.Railing.SetMultistoryStairsPlacementLevels Method

**中文**: 栏杆

Sets the ids of the base levels of the stairs upon which this railing is placed.

## Syntax (C#)
```csharp
public void SetMultistoryStairsPlacementLevels(
	ISet<ElementId> levelIds
)
```

## Parameters
- **levelIds** (`System.Collections.Generic.ISet < ElementId >`) - The ids of levels the railing is placed on.
 If input level id set is empty, railings will placed on all levels of the hosting stairs.

## Remarks
The method is valid only for railings hosted by stairs in MultistoryStairs .
 The input level ids have to be a subset of level ids of the railing stairs.
 See MultistoryStairs for information about the placement levels that may be passed as input.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - All of the level ids in levelIds must be placement levels of stairs.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The railing is not hosted by stairs in MultistoryStairs .

