---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewRooms2(Autodesk.Revit.DB.Level,Autodesk.Revit.DB.Phase)
zh: 文档、文件
source: html/716dba64-4853-685b-bb3f-6c071b0cd0c8.htm
---
# Autodesk.Revit.Creation.Document.NewRooms2 Method

**中文**: 文档、文件

Creates new rooms in each plan circuit found in the given level in the given phase.

## Syntax (C#)
```csharp
public ICollection<ElementId> NewRooms2(
	Level level,
	Phase phase
)
```

## Parameters
- **level** (`Autodesk.Revit.DB.Level`) - The level from which the circuits are found.
- **phase** (`Autodesk.Revit.DB.Phase`) - The phase on which the room is to exist.

## Returns
If successful, a set of ElementIds which contains the rooms should be returned, otherwise the exception will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - If the view of the relevant level can not be retrieved.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If the phase is invalid, or regeneration fails at the end of the creation.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the level does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the phase does not exist in the given document.

