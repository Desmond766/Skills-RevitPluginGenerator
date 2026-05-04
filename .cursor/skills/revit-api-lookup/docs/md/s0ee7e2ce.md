---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.FindEndsOfShortestPaths(Autodesk.Revit.DB.View,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/607571b1-bebe-f647-28c1-30b409475c65.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.FindEndsOfShortestPaths Method

For a floor plan view, calculates the paths from each start point to its closest destination and return the path end points.

## Syntax (C#)
```csharp
public static IList<XYZ> FindEndsOfShortestPaths(
	View DBView,
	IList<XYZ> destinationPoints,
	IList<XYZ> startPoints
)
```

## Parameters
- **DBView** (`Autodesk.Revit.DB.View`) - The floor plan view to use when computing the points.
- **destinationPoints** (`System.Collections.Generic.IList < XYZ >`) - Destination points. The input Z coordinates are ignored and set to the view's level elevation.
- **startPoints** (`System.Collections.Generic.IList < XYZ >`) - Start points for which shortest path end points are calculated.

## Returns
End points of paths calculated from each start point to its corresponding closest destination.
 If a path cannot be calculated the corresponsing end point is set to the corresponding start point.

## Remarks
The calculation is done in a floor plan with one or more destinationPoints and one or more startPoints.
 The shortest path is calculated from each start point to its corresponding closest destination.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - View is not a floor plan view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Path of Travel calculation service is not available
 -or-
 This functionality is not available in Revit LT.

