---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.CopyElement(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ)
zh: 复制
source: html/d0f532b7-2d30-c1d2-cd58-16237ec168e3.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.CopyElement Method

**中文**: 复制

Copies an element and places the copy at a location indicated by a given transformation.

## Syntax (C#)
```csharp
public static ICollection<ElementId> CopyElement(
	Document document,
	ElementId elementToCopy,
	XYZ translation
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the element.
- **elementToCopy** (`Autodesk.Revit.DB.ElementId`) - The id of the element to copy.
- **translation** (`Autodesk.Revit.DB.XYZ`) - The translation vector for the new element.

## Returns
The ids of the newly created copied elements. More than one element may be created due to dependencies.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elementToCopy does not exist in the document
 -or-
 The input element is a Sketch member and there is no Sketch in the edit mode to place this element in.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - It is not allowed to copy Sketch member to non-parallel sketch.
 -or-
 If we are not able to copy the element.

