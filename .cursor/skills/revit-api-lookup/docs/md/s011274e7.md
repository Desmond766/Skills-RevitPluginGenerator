---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CableTrayConduitBase.IsValidEndPoints(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/362d4421-4b5d-2caf-c8a2-68a281f3e718.htm
---
# Autodesk.Revit.DB.Electrical.CableTrayConduitBase.IsValidEndPoints Method

Identifies if two end points are valid.

## Syntax (C#)
```csharp
public static bool IsValidEndPoints(
	XYZ startPoint,
	XYZ endPoint
)
```

## Parameters
- **startPoint** (`Autodesk.Revit.DB.XYZ`) - The start point of the location line.
- **endPoint** (`Autodesk.Revit.DB.XYZ`) - The end point of the location line.

## Returns
True if the two end points are valid, false otherwise.

## Remarks
The two points should not be too close.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

