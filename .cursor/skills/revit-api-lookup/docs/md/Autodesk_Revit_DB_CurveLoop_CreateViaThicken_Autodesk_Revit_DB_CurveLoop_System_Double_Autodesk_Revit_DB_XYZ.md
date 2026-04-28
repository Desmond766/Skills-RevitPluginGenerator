---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.CreateViaThicken(Autodesk.Revit.DB.CurveLoop,System.Double,Autodesk.Revit.DB.XYZ)
source: html/1755d6bf-5993-58dd-a966-98c83ef86891.htm
---
# Autodesk.Revit.DB.CurveLoop.CreateViaThicken Method

Creates a new closed curve loop by thickening the input open curve loop with respect to a given plane.

## Syntax (C#)
```csharp
public static CurveLoop CreateViaThicken(
	CurveLoop curveLoop,
	double thickness,
	XYZ normal
)
```

## Parameters
- **curveLoop** (`Autodesk.Revit.DB.CurveLoop`) - The input curve loop.
- **thickness** (`System.Double`) - The distance between the offset curves created on either side of the input curve.
- **normal** (`Autodesk.Revit.DB.XYZ`) - The normal vector to the plane used for thickening.

## Returns
The new curve loop.

## Remarks
The new loop will be created via
 offsets of the input curve loop (in the plane of the normal vector) with the endpoints
 connected with lines.The original curve loop will be at the center of the new loop.
 If the curve loop contains curves such as elliptical segments or splines, it is possible the offset creation will fail if
 Revit will not be able to trim contiguous curves to meet one another. If the offset is successful, offsets of those curve types
 will be created as HermiteSplines.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input thickness is too short for a curve.
 -or-
 the curve loop is not marked as open.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Throws if the input curve could not be thickened.

