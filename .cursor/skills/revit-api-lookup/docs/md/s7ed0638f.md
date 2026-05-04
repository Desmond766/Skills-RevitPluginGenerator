---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.MoveElement(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ)
zh: 移动
source: html/aaddd413-01b0-2878-3f79-a281abb6d364.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.MoveElement Method

**中文**: 移动

Moves one element by a given transformation.

## Syntax (C#)
```csharp
public static void MoveElement(
	Document document,
	ElementId elementToMove,
	XYZ translation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the elements.
- **elementToMove** (`Autodesk.Revit.DB.ElementId`) - The id of the element to move.
- **translation** (`Autodesk.Revit.DB.XYZ`) - The translation vector for the elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elementToMove does not exist in the document
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If we are not able to move the element (for example, if it is pinned).
 -or-
 Move operation failed.

