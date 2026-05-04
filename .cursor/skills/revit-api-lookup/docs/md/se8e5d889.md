---
kind: method
id: M:Autodesk.Revit.DB.Structure.PointLoad.IsPointInsideHostBoundaries(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ)
source: html/994add06-c832-952e-38b0-1f9d30e51047.htm
---
# Autodesk.Revit.DB.Structure.PointLoad.IsPointInsideHostBoundaries Method

Indicates if the point is inside panel's boundaries or if the point is on the member's curve..

## Syntax (C#)
```csharp
public static bool IsPointInsideHostBoundaries(
	Document pDoc,
	ElementId hostId,
	XYZ point
)
```

## Parameters
- **pDoc** (`Autodesk.Revit.DB.Document`) - The document containing both the host and the load.
- **hostId** (`Autodesk.Revit.DB.ElementId`) - The id of the analytical element that is about to host a point load.
- **point** (`Autodesk.Revit.DB.XYZ`) - The position of point load, measured in decimal feet.

## Returns
True if a point load can be placed on the input host id

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

