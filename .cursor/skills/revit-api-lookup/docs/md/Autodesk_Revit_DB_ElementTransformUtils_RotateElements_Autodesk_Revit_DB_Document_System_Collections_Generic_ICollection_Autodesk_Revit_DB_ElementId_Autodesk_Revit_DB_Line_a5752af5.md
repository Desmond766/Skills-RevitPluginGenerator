---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.RotateElements(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.Line,System.Double)
zh: 旋转
source: html/5d62fb23-60c1-b740-b02c-d0b6fd1d8ed0.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.RotateElements Method

**中文**: 旋转

Rotates a set of elements about the given axis and angle.

## Syntax (C#)
```csharp
public static void RotateElements(
	Document document,
	ICollection<ElementId> elementsToRotate,
	Line axis,
	double angle
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the elements.
- **elementsToRotate** (`System.Collections.Generic.ICollection < ElementId >`) - The set of elements to rotate.
- **axis** (`Autodesk.Revit.DB.Line`) - The axis of rotation.
- **angle** (`System.Double`) - The angle of rotation in radians.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given element id set is empty.
 -or-
 One or more elements in elementsToRotate do not exist in the document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

