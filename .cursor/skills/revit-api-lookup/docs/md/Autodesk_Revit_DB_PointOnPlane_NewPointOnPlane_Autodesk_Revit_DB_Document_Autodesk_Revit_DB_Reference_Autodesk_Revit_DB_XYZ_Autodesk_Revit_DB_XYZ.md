---
kind: method
id: M:Autodesk.Revit.DB.PointOnPlane.NewPointOnPlane(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/9426acbb-e021-d7b4-06ec-98a902420273.htm
---
# Autodesk.Revit.DB.PointOnPlane.NewPointOnPlane Method

Construct a PointOnPlane given a reference and a location in space.

## Syntax (C#)
```csharp
public static PointOnPlane NewPointOnPlane(
	Document doc,
	Reference planeReference,
	XYZ position,
	XYZ xvec
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document containing the plane reference.
- **planeReference** (`Autodesk.Revit.DB.Reference`)
- **position** (`Autodesk.Revit.DB.XYZ`) - A 3-dimensional position.
- **xvec** (`Autodesk.Revit.DB.XYZ`) - The direction of the point's
X-coordinate vector in the plane's
coordinates. Optional; default value is the
X-coordinate vector of the plane.

## Returns
A new PointOnPlane object with 2-dimensional Position, XVec, and Offset
properties set to match the given 3-dimensional arguments.

