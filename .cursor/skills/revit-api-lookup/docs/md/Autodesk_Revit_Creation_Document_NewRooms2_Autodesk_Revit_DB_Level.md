---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewRooms2(Autodesk.Revit.DB.Level)
zh: 文档、文件
source: html/5d5f7f56-c86c-d87e-ff6c-eb4e465a5183.htm
---
# Autodesk.Revit.Creation.Document.NewRooms2 Method

**中文**: 文档、文件

Creates new rooms in each plan circuit found in the given level in the last phase.

## Syntax (C#)
```csharp
public ICollection<ElementId> NewRooms2(
	Level level
)
```

## Parameters
- **level** (`Autodesk.Revit.DB.Level`) - The level from which the circuits are found.

## Returns
If successful, a set of ElementIds which contains the rooms created should be returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - If the view of the relevant level can not be retrieved.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If the phase is invalid, or regeneration fails at the end of the creation.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the level does not exist in the given document.

