---
kind: method
id: M:Autodesk.Revit.DB.CurveByPoints.SortPoints(Autodesk.Revit.DB.ReferencePointArray)
source: html/3da00567-298b-5130-df47-f33ea6a3f0c2.htm
---
# Autodesk.Revit.DB.CurveByPoints.SortPoints Method

Order a set of ReferencePoints in the same way Revit does
when creating a curve from points.

## Syntax (C#)
```csharp
public static bool SortPoints(
	ReferencePointArray arr
)
```

## Parameters
- **arr** (`Autodesk.Revit.DB.ReferencePointArray`) - An array of ReferencePoints. The array is reordered
if sortPoints returns true, and is unchanged if
sortPoints returns false.

## Returns
False if the least-squares method is unable to find a solution;
true otherwise.

## Remarks
Finds a best-fit line to the points by the least squares method,
and orders the points by their projection onto the line.

