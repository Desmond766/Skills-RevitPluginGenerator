---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewRooms2(Autodesk.Revit.DB.Phase,System.Int32)
zh: 文档、文件
source: html/d17f1295-77c6-f8ca-2e5e-6351ef0f520a.htm
---
# Autodesk.Revit.Creation.Document.NewRooms2 Method

**中文**: 文档、文件

Creates new unplaced rooms in the given phase.

## Syntax (C#)
```csharp
public ICollection<ElementId> NewRooms2(
	Phase phase,
	int count
)
```

## Parameters
- **phase** (`Autodesk.Revit.DB.Phase`) - The phase on which the rooms are to exist.
- **count** (`System.Int32`) - The number of the rooms to be created.

## Returns
If successful, a set of ElementIds which contains the rooms should be returned, otherwise the exception will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If the room can not be created successfully or regeneration fails at the end of the creation.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the phase does not exist in the given document.

