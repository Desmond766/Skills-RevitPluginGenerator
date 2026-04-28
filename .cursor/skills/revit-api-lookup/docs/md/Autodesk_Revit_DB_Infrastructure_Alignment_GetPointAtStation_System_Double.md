---
kind: method
id: M:Autodesk.Revit.DB.Infrastructure.Alignment.GetPointAtStation(System.Double)
source: html/1b4cc73b-dc00-0439-5480-fd7979b1e106.htm
---
# Autodesk.Revit.DB.Infrastructure.Alignment.GetPointAtStation Method

Calculates the model point for a given alignment station.

## Syntax (C#)
```csharp
public XYZ GetPointAtStation(
	double station
)
```

## Parameters
- **station** (`System.Double`) - The alignment station for which to calculate the point, in Revit internal model units (standard Imperial feet).

## Returns
The model point at the given alignment station.

