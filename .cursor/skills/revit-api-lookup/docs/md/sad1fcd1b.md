---
kind: method
id: M:Autodesk.Revit.DB.PointOnPlane.IsValidPlaneReference(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Reference)
source: html/34870b48-bc69-93f8-cdb9-e80e015dc237.htm
---
# Autodesk.Revit.DB.PointOnPlane.IsValidPlaneReference Method

Check whether a geometry reference
corresponds to a referenceable plane.

## Syntax (C#)
```csharp
public static bool IsValidPlaneReference(
	Document doc,
	Reference planeReference
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`)
- **planeReference** (`Autodesk.Revit.DB.Reference`)

## Remarks
Valid plane references include: planar faces
of solids; the PlaneReference properties of
 Level and 
 SketchPlane ;
the Reference property of 
 ReferencePlane .

