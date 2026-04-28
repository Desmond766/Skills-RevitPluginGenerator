---
kind: method
id: M:Autodesk.Revit.DB.Architecture.Railing.GetMultistoryStairsPlacementLevels
zh: 栏杆
source: html/aac188d3-7c62-e74c-3579-cdcb8dc5c7f3.htm
---
# Autodesk.Revit.DB.Architecture.Railing.GetMultistoryStairsPlacementLevels Method

**中文**: 栏杆

Gets the ids of the base levels of the stairs upon which this railing is placed.

## Syntax (C#)
```csharp
public ISet<ElementId> GetMultistoryStairsPlacementLevels()
```

## Returns
The ids of levels the railing is placed on.
 The returned set consists of a subset of the base level ids of the corresponding stairs in the MultistoryStairs .

## Remarks
The method is valid only for railings hosted by stairs in MultistoryStairs .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The railing is not hosted by stairs in MultistoryStairs .

