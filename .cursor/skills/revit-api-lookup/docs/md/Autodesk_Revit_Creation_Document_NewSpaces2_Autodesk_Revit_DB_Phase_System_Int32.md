---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewSpaces2(Autodesk.Revit.DB.Phase,System.Int32)
zh: 文档、文件
source: html/5727a24c-310b-a76f-b9fa-0a7b0697e902.htm
---
# Autodesk.Revit.Creation.Document.NewSpaces2 Method

**中文**: 文档、文件

Creates a set of new unplaced spaces on a given phase.

## Syntax (C#)
```csharp
public ICollection<ElementId> NewSpaces2(
	Phase phase,
	int count
)
```

## Parameters
- **phase** (`Autodesk.Revit.DB.Phase`) - The phase in which the spaces are to exist.
- **count** (`System.Int32`)

## Returns
If successful, a set of ElementIds of new unplaced spaces are be returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the phase does not exist in the given document.

