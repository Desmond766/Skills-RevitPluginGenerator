---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewZone(Autodesk.Revit.DB.Level,Autodesk.Revit.DB.Phase)
zh: 文档、文件
source: html/a0731d97-81ba-be0b-b2df-48f55b06363a.htm
---
# Autodesk.Revit.Creation.Document.NewZone Method

**中文**: 文档、文件

Creates a new Zone element.

## Syntax (C#)
```csharp
public Zone NewZone(
	Level level,
	Phase phase
)
```

## Parameters
- **level** (`Autodesk.Revit.DB.Level`) - The level on which the Zone is to exist.
- **phase** (`Autodesk.Revit.DB.Phase`) - The associative phase on which the Zone is to exist.

## Returns
If successful a new Zone element within the project, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the specified parameter Value is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the electrical system cannot be created by these input phase and level.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the level does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the phase does not exist in the given document.

