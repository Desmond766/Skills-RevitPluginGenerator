---
kind: method
id: M:Autodesk.Revit.DB.Transform.CreateRotation(Autodesk.Revit.DB.XYZ,System.Double)
zh: 变换
source: html/01cddc01-b348-3c51-d2ad-c61ac64c6da4.htm
---
# Autodesk.Revit.DB.Transform.CreateRotation Method

**中文**: 变换

Creates a transform that represents a rotation about the given axis at (0, 0, 0).

## Syntax (C#)
```csharp
public static Transform CreateRotation(
	XYZ axis,
	double angle
)
```

## Parameters
- **axis** (`Autodesk.Revit.DB.XYZ`) - The rotation axis.
- **angle** (`System.Double`) - The angle.

## Returns
The new transform.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for angle is not finite
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - axis has zero length.

