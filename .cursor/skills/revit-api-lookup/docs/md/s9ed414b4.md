---
kind: method
id: M:Autodesk.Revit.DB.Analysis.PathOfTravel.RemoveWaypoint(System.Int32)
source: html/180917fd-f296-54f9-a824-301b99376fb5.htm
---
# Autodesk.Revit.DB.Analysis.PathOfTravel.RemoveWaypoint Method

Remove a waypoint.

## Syntax (C#)
```csharp
public void RemoveWaypoint(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the waypoint to remove.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Index refers to a non-existent waypoint.
 -or-
 This functionality is not available in Revit LT.
 -or-
 Cannot perform this operation for a path of travel in a group.

