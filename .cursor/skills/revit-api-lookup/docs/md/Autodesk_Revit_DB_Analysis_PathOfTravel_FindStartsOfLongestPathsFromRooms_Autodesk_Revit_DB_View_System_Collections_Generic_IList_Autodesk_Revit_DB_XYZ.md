---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.FindStartsOfLongestPathsFromRooms(Autodesk.Revit.DB.View,System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ})
source: html/d76f7dbc-c20e-ea61-8c6b-a4bd59f444c2.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.FindStartsOfLongestPathsFromRooms Method

For a floor plan view, calculates paths from points inside rooms to the closests of the destinations.
 Returns the start points of the longest path(s). If multiple paths have the same longest length, returns multiple start points.

## Syntax (C#)
```csharp
public static IList<XYZ> FindStartsOfLongestPathsFromRooms(
	View DBView,
	IList<XYZ> destinationPoints
)
```

## Parameters
- **DBView** (`Autodesk.Revit.DB.View`) - The floor plan view to use when computing the points.
- **destinationPoints** (`System.Collections.Generic.IList < XYZ >`) - Destination points. The input Z coordinates are ignored and set to the view's level elevation.

## Returns
Start points of the paths with longest lengths.
 The array is empty if there are no valid paths from any points in rooms to any of the destination points.

## Remarks
The entire plan is divided in small tiles, and the distance to the closest destination point
 is calculated for each tile center point. Only tile center points that are located in rooms in the view are taken into account.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - View is not a floor plan view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Path of Travel calculation service is not available
 -or-
 This functionality is not available in Revit LT.

