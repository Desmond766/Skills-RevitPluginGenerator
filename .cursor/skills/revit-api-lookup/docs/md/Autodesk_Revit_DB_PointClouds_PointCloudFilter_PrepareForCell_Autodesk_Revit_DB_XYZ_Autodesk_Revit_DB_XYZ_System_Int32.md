---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudFilter.PrepareForCell(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,System.Int32)
source: html/82cc661d-89e7-d53e-b5a5-05d2aab397b1.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudFilter.PrepareForCell Method

Informs the filter that a series of points within a given cell is about to be checked.

## Syntax (C#)
```csharp
public void PrepareForCell(
	XYZ min,
	XYZ max,
	int numTests
)
```

## Parameters
- **min** (`Autodesk.Revit.DB.XYZ`) - The lower corner of the cell.
- **max** (`Autodesk.Revit.DB.XYZ`) - The upper corner of the cell.
- **numTests** (`System.Int32`) - The engine's estimate of the number of TestPoint() calls it is going to make for this cell.

## Remarks
This is a performance hook that the filter can use to minimize computational work per TestPoint() call
 within a given cell.
 The engine should guarantee that all points passed to TestPoint() calls
 will fall inside the (min, max) box specified here. This promise must be in effect until
 the next PrepareForCell() call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

