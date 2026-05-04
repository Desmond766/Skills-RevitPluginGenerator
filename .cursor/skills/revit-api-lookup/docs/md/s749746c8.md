---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.FindShortestPaths(Autodesk.Revit.DB.View,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/ed038de8-768b-f9ce-91f5-c25ac559d5fe.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.FindShortestPaths Method

For a floor plan view, calculates paths from each start point to its closest destinations.
 Returns the path, represented by an array of XYZ points.

## Syntax (C#)
```csharp
public static IList<IList<XYZ>> FindShortestPaths(
	View DBView,
	IList<XYZ> destinationPoints,
	IList<XYZ> startPoints
)
```

## Parameters
- **DBView** (`Autodesk.Revit.DB.View`) - The floor plan view to use when computing the points.
- **destinationPoints** (`System.Collections.Generic.IList < XYZ >`) - Destination points. The input Z coordinates are ignored and set to the view's level elevation.
- **startPoints** (`System.Collections.Generic.IList < XYZ >`) - Start points for which shortest paths are calculated.

## Returns
Array of paths calculated from each start point to its corresponding closest destination.
 If a path cannot be caculated the corresponsing sub-array is set to an empty array.

## Remarks
The calculation is done in a floor plan with one or more destinationPoints and one or more startPoints.
 The shortest path is calculated from each start point to its closest destination point.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - View is not a floor plan view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Path of Travel calculation service is not available
 -or-
 This functionality is not available in Revit LT.

