---
kind: method
id: M:Autodesk.Revit.DB.Transform.CreateRotationAtPoint(Autodesk.Revit.DB.XYZ,System.Double,Autodesk.Revit.DB.XYZ)
zh: 变换
source: html/8da64cca-bea9-4750-1f79-f6de3867191e.htm
---
# Autodesk.Revit.DB.Transform.CreateRotationAtPoint Method

**中文**: 变换

Creates a transform that represents a rotation about the given axis at the specified point.

## Syntax (C#)
```csharp
public static Transform CreateRotationAtPoint(
	XYZ axis,
	double angle,
	XYZ origin
)
```

## Parameters
- **axis** (`Autodesk.Revit.DB.XYZ`) - The rotation axis.
- **angle** (`System.Double`) - The angle.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The origin point.

## Returns
The new transform.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for angle is not finite
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - axis has zero length.

