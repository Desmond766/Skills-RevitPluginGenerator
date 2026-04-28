---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.CreateViaThicken(Autodesk.Revit.DB.Curve,System.Double,Autodesk.Revit.DB.XYZ)
source: html/596ccb71-a32f-0a01-8366-58619263c733.htm
---
# Autodesk.Revit.DB.CurveLoop.CreateViaThicken Method

Creates a new closed curve loop by thickening the input curve with respect to a given plane.

## Syntax (C#)
```csharp
public static CurveLoop CreateViaThicken(
	Curve pCurve,
	double thickness,
	XYZ normal
)
```

## Parameters
- **pCurve** (`Autodesk.Revit.DB.Curve`) - The input curve.
- **thickness** (`System.Double`) - The distance between the offset curves created on either side of the input curve.
- **normal** (`Autodesk.Revit.DB.XYZ`) - The normal vector to the plane used for thickening.

## Returns
The new curve loop.

## Remarks
The new loop will be created via
 offsets of the input curve (in the plane of the normal vector) with the endpoints
 connected with lines.The original curve will be at the center of the new loop.
 Note that for input elliptical fragments and NurbSpline curves, any offsets will be created as HermiteSplines.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input thickness is too short for a curve.
 -or-
 The input pCurve points to a helical curve and is not supported for this operation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Throws if the input curve could not be thickened.

