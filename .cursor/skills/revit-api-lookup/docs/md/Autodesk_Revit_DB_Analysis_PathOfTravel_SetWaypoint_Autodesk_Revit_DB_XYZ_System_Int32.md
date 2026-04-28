---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.SetWaypoint(Autodesk.Revit.DB.XYZ,System.Int32)
source: html/32d98435-a0bb-148f-1139-4b338b4ccd6b.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.SetWaypoint Method

Updates the specified waypoint.

## Syntax (C#)
```csharp
public void SetWaypoint(
	XYZ waypoint,
	int index
)
```

## Parameters
- **waypoint** (`Autodesk.Revit.DB.XYZ`) - The new point for the waypoint.
- **index** (`System.Int32`) - The index of the waypoint to update.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Index refers to a non-existent waypoint.
 -or-
 This functionality is not available in Revit LT.
 -or-
 Cannot perform this operation for a path of travel in a group.

