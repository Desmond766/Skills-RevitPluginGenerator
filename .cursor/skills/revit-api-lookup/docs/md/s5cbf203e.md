---
kind: method
id: M:Autodesk.Revit.DB.NurbSpline.CreateCurve(Autodesk.Revit.DB.HermiteSpline)
source: html/c0191746-fdd6-4f24-cfb7-29a6a88bc05b.htm
---
# Autodesk.Revit.DB.NurbSpline.CreateCurve Method

Creates a new geometric Curve object by converting the given HermiteSpline.
 The created curve may be a NURBSpline or a simpler curve such as line or arc.

## Syntax (C#)
```csharp
public static Curve CreateCurve(
	HermiteSpline hermiteSpline
)
```

## Parameters
- **hermiteSpline** (`Autodesk.Revit.DB.HermiteSpline`) - The HermiteSpline that will be converted.

## Returns
The new Curve object.

## Remarks
The function does not support periodic Hermite curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given hermite spline has to be non-periodic.
 -or-
 Curve length is too small for Revit's tolerance (as identified by Application.ShortCurveTolerance).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL

