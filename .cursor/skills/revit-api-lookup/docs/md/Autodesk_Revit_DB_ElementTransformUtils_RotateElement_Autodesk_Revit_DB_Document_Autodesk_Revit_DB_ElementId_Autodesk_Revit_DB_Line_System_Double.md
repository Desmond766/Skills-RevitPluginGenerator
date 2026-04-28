---
kind: method
id: M:Autodesk.Revit.DB.ElementTransformUtils.RotateElement(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.Line,System.Double)
zh: 旋转
source: html/3968f4e8-759c-f975-6c1f-7de42be633ed.htm
---
# Autodesk.Revit.DB.ElementTransformUtils.RotateElement Method

**中文**: 旋转

Rotates an element about the given axis and angle.

## Syntax (C#)
```csharp
public static void RotateElement(
	Document document,
	ElementId elementToRotate,
	Line axis,
	double angle
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that owns the elements.
- **elementToRotate** (`Autodesk.Revit.DB.ElementId`) - The element to rotate.
- **axis** (`Autodesk.Revit.DB.Line`) - The axis of rotation.
- **angle** (`System.Double`) - The angle of rotation in radians.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element elementToRotate does not exist in the document
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

