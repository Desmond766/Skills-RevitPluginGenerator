---
kind: method
id: M:Autodesk.Revit.DB.Infrastructure.Alignment.GetClosestStation(Autodesk.Revit.DB.XYZ)
source: html/0054066e-cde3-f2bc-4d19-ad09432e0004.htm
---
# Autodesk.Revit.DB.Infrastructure.Alignment.GetClosestStation Method

Calculates the alignment station closest to the given model point.

## Syntax (C#)
```csharp
public double GetClosestStation(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The model point for which to calculate the closest station.

## Returns
The alignment station closest to the given model point, in Revit internal model units (standard Imperial feet).

