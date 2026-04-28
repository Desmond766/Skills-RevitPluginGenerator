---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewSpace(Autodesk.Revit.DB.Level,Autodesk.Revit.DB.UV)
zh: 文档、文件
source: html/43059324-6e95-706b-ea39-627601d0419c.htm
---
# Autodesk.Revit.Creation.Document.NewSpace Method

**中文**: 文档、文件

Creates a new space element on the given level at the given location.

## Syntax (C#)
```csharp
public Space NewSpace(
	Level level,
	UV point
)
```

## Parameters
- **level** (`Autodesk.Revit.DB.Level`) - The level on which the space is to exist.
- **point** (`Autodesk.Revit.DB.UV`) - A 2D point that dictates the location on that specified level.

## Returns
If successful the new space element is returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when level or point is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the space cannot be created.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the level does not exist in the given document.

