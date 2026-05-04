---
kind: method
id: M:Autodesk.Revit.Creation.Document.NewSpaces2(Autodesk.Revit.DB.Level,Autodesk.Revit.DB.Phase,Autodesk.Revit.DB.View)
zh: 文档、文件
source: html/94b4e479-2301-2e78-6201-5bb5614ed796.htm
---
# Autodesk.Revit.Creation.Document.NewSpaces2 Method

**中文**: 文档、文件

Creates new spaces on the available plan circuits of a the given level.

## Syntax (C#)
```csharp
public ICollection<ElementId> NewSpaces2(
	Level level,
	Phase phase,
	View view
)
```

## Parameters
- **level** (`Autodesk.Revit.DB.Level`) - The level on which the spaces is to exist.
- **phase** (`Autodesk.Revit.DB.Phase`) - The phase in which the spaces is to exist.
- **view** (`Autodesk.Revit.DB.View`) - The view on which the space tags for the spaces are to display.

## Returns
If successful, a set of ElementIds which contains the rooms should be returned, otherwise the exception will be thrown.

## Remarks
This method will regenerate the document even in manual regeneration mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The view of the relevant level can not be retrieved.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The phase is invalid or regeneration fails at the end of the creation.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the level does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the phase does not exist in the given document.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the view does not exist in the given document.

