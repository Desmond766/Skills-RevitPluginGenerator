---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewSpace(Autodesk.Revit.DB.Phase)
zh: 文档、文件
source: html/ea6a14cd-5ffb-4220-e4d4-401a44c8234b.htm
---
# Autodesk.Revit.Creation.Document.NewSpace Method

**中文**: 文档、文件

Creates a new unplaced space on a given phase.

## Syntax (C#)
```csharp
public Space NewSpace(
	Phase phase
)
```

## Parameters
- **phase** (`Autodesk.Revit.DB.Phase`) - The phase in which the space is to exist.

## Returns
If successful the new space should be returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the phase does not exist in the given document.

