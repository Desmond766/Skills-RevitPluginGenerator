---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewSpace(Autodesk.Revit.DB.Level,Autodesk.Revit.DB.Phase,Autodesk.Revit.DB.UV)
zh: 文档、文件
source: html/ce49bd88-7d6b-b3ca-bd4c-497233718ffb.htm
---
# Autodesk.Revit.Creation.Document.NewSpace Method

**中文**: 文档、文件

Creates a new space element on the given level, at the given location, and assigned to the given phase.

## Syntax (C#)
```csharp
public Space NewSpace(
	Level level,
	Phase phase,
	UV point
)
```

## Parameters
- **level** (`Autodesk.Revit.DB.Level`) - The level on which the room is to exist.
- **phase** (`Autodesk.Revit.DB.Phase`) - The phase in which the room is to exist.
- **point** (`Autodesk.Revit.DB.UV`) - A 2D point that dictates the location on that specified level.

## Returns
If successful a new Space element within the project, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when level, phase or point is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the space cannot be created.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the level does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the phase does not exist in the given document.

