---
kind: method
id: M:Autodesk.Revit.DB.Infrastructure.Alignment.GetDistance(System.Double,System.Double)
source: html/1a8c7baa-0653-8d1b-06f4-c3bd4cd5953f.htm
---
# Autodesk.Revit.DB.Infrastructure.Alignment.GetDistance Method

Calculates the relative distance along the alignment between two stations based on their alignment distances
 according to Revit Internal Origin Coordinate Base. The distance may be positive or negative depending on
 the relative positions of the input stations on the alignment.

## Syntax (C#)
```csharp
public double GetDistance(
	double fromStation,
	double toStation
)
```

## Parameters
- **fromStation** (`System.Double`) - The displayed alignment station from which 2D length is to be calculated, in Revit internal model units (standard Imperial feet).
- **toStation** (`System.Double`) - The displayed alignment station to which 2D length is to be calculated, in Revit internal model units (standard Imperial feet).

## Returns
Distance (positive or negative) along the alignment between two stations. The sign of the distance
 depends on the relative positions of the input stations on the alignment.

