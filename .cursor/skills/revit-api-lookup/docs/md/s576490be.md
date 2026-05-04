---
kind: method
id: M:Autodesk.Revit.DB.Line.CreateBound(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
zh: 线、直线
source: html/7885bdf9-3007-ea60-af6b-a96ac7672c18.htm
---
# Autodesk.Revit.DB.Line.CreateBound Method

**中文**: 线、直线

Creates a new instance of a bound linear curve.

## Syntax (C#)
```csharp
public static Line CreateBound(
	XYZ endpoint1,
	XYZ endpoint2
)
```

## Parameters
- **endpoint1** (`Autodesk.Revit.DB.XYZ`) - The first line endpoint.
- **endpoint2** (`Autodesk.Revit.DB.XYZ`) - The second line endpoint.

## Returns
The new bound line.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Curve length is too small for Revit's tolerance (as identified by Application.ShortCurveTolerance).

