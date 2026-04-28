---
kind: method
id: M:Autodesk.Revit.DB.PointClouds.PointCloudFilter.TestCell(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/79c9d272-1a5d-32f2-33b6-fce3e21dc562.htm
---
# Autodesk.Revit.DB.PointClouds.PointCloudFilter.TestCell Method

Checks whether a given cell, i.e. a box aligned with the XYZ axes, is inside, outside
 or on the border of the volume of interest.

## Syntax (C#)
```csharp
public int TestCell(
	XYZ min,
	XYZ max
)
```

## Parameters
- **min** (`Autodesk.Revit.DB.XYZ`) - The lower corner of the cell.
- **max** (`Autodesk.Revit.DB.XYZ`) - The upper corner of the cell.

## Returns
-1 -- The cell is entirely rejected. 0 -- The cell partially belongs to the volume of interest. Use PrepareForCell() and TestPoint() to
 evaluate individual points. 1 -- The cell is fully accepted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

