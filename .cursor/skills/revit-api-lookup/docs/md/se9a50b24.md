---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.MoveElements(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.XYZ)
zh: 移动
source: html/3cf8c9dc-f4d1-12f0-d7a9-e126331cd858.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.MoveElements Method

**中文**: 移动

Moves a set of elements by a given transformation.

## Syntax (C#)
```csharp
public static void MoveElements(
	Document document,
	ICollection<ElementId> elementsToMove,
	XYZ translation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the elements.
- **elementsToMove** (`System.Collections.Generic.ICollection < ElementId >`) - The set of elements to move.
- **translation** (`Autodesk.Revit.DB.XYZ`) - The translation vector for the elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element id set is empty.
 -or-
 One or more elements in elementsToMove do not exist in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If we are not able to move all the elements (for example, if one or more elements is pinned).
 -or-
 Move operation failed.

