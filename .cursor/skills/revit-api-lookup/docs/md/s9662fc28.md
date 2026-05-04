---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.InsertWaypoint(Autodesk.Revit.DB.XYZ,System.Int32)
source: html/75f4e1f0-a543-5f50-9958-030c0fa2a2dd.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.InsertWaypoint Method

Insert a waypoint at the specified index

## Syntax (C#)
```csharp
public void InsertWaypoint(
	XYZ waypoint,
	int index
)
```

## Parameters
- **waypoint** (`Autodesk.Revit.DB.XYZ`) - The waypoint to insert.
- **index** (`System.Int32`) - The index to insert the waypoint at.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Index is invalid for an existing or new waypoint for this path.
 -or-
 This functionality is not available in Revit LT.
 -or-
 Cannot perform this operation for a path of travel in a group.

