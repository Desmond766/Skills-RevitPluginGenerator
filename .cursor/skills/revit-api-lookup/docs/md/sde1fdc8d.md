---
kind: method
id: M:Autodesk.Revit.DB.ViewCropRegionShapeManager.IsCropRegionShapeValid(Autodesk.Revit.DB.CurveLoop)
source: html/e9d91a49-9d33-f1d5-a197-e1bf33a17265.htm
---
# Autodesk.Revit.DB.ViewCropRegionShapeManager.IsCropRegionShapeValid Method

Verifies that boundary represents one closed curve loop without self-intersections,
 consisting of non-zero length straight lines in a plane parallel to the view plane.

## Syntax (C#)
```csharp
public bool IsCropRegionShapeValid(
	CurveLoop boundary
)
```

## Parameters
- **boundary** (`Autodesk.Revit.DB.CurveLoop`) - The crop boundary.

## Returns
True if the passed crop boundary represents one closed curve loop without self-intersections,
 consisting of non-zero length straight lines in a plane parallel to the view plane.

## Remarks
Curves in boundary use model coordinates.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

