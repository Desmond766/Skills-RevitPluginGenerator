---
kind: method
id: M:Autodesk.Revit.DB.RevolvedSurface.IsValidProfileCurve(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.Curve)
source: html/3391c6e4-35e9-23de-7875-374fe5beeb0d.htm
---
# Autodesk.Revit.DB.RevolvedSurface.IsValidProfileCurve Method

Checks if the input profile curve is valid to create a surface of revolution around the given axis.

## Syntax (C#)
```csharp
public static bool IsValidProfileCurve(
	XYZ axisBasePoint,
	XYZ axisDirection,
	Curve profileCurve
)
```

## Parameters
- **axisBasePoint** (`Autodesk.Revit.DB.XYZ`) - The base point of the axis of revolution.
- **axisDirection** (`Autodesk.Revit.DB.XYZ`) - The direction of the axis.
- **profileCurve** (`Autodesk.Revit.DB.Curve`) - The profile curve.

## Returns
True if the profile curve is valid; False otherwise.

## Remarks
The validity is defined as follows:
 The profile curve is bounded and non-degenerate. It is co-planar with the axis of revolution. It lies on only one side of the axis. Only the end points of the profile curve can touch the axis.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

