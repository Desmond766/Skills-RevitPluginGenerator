---
kind: method
id: M:Autodesk.Revit.DB.Ellipse.CreateCurve(Autodesk.Revit.DB.XYZ,System.Double,System.Double,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,System.Double,System.Double)
source: html/a3da8ed5-5fea-087f-6989-c987ce7ae47f.htm
---
# Autodesk.Revit.DB.Ellipse.CreateCurve Method

Creates a new geometric ellipse or elliptical arc object.

## Syntax (C#)
```csharp
public static Curve CreateCurve(
	XYZ center,
	double xRadius,
	double yRadius,
	XYZ xAxis,
	XYZ yAxis,
	double startParameter,
	double endParameter
)
```

## Parameters
- **center** (`Autodesk.Revit.DB.XYZ`) - The center.
- **xRadius** (`System.Double`) - The x vector radius of the ellipse.
- **yRadius** (`System.Double`) - The y vector radius of the ellipse.
- **xAxis** (`Autodesk.Revit.DB.XYZ`) - The x axis to define the ellipse plane. Must be normalized.
- **yAxis** (`Autodesk.Revit.DB.XYZ`) - The y axis to define the ellipse plane. Must be normalized.
- **startParameter** (`System.Double`) - The raw parameter value at the start of the ellipse.
- **endParameter** (`System.Double`) - The raw parameter value at the end of the ellipse.

## Returns
The new ellipse or elliptical arc.

## Remarks
If the angle range is equal to or greater than 2 * PI, the curve will be
 automatically converted to an unbounded ellipse.
 If xRadius and yRadius are almost equal, the curve will be
 returned as an arc.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for xRadius must be greater than 0 and no more than 30000 feet.
 -or-
 The given value for yRadius must be greater than 0 and no more than 30000 feet.
 -or-
 xAxis is not length 1.0.
 -or-
 yAxis is not length 1.0.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The vectors xAxis and yAxis are not perpendicular.
 -or-
 Start parameter must be less than end parameter.
 -or-
 Curve length is too small for Revit's tolerance (as identified by Application.ShortCurveTolerance).

