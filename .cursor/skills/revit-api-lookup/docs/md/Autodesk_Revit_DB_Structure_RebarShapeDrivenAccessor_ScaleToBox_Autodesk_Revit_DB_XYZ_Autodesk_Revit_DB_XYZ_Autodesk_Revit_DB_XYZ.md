---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.ScaleToBox(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/7d25297a-46f1-7fe9-e815-a7a9c4672567.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.ScaleToBox Method

Move and resize the bar to fit within a specified box.
 The arguments are interpreted as an arbitrary
 rectangle in 3D with vertices: origin, origin+xVec,
 origin+xVec+yVec, origin+yVec. The algorithm then
 proceeds as follows. First the bar is given the
 default values of the shape parameters from the shape
 definition. Then, if it is possible to do so without
 violating the shape definition, the parameter values
 are scaled so that the width and height of the shape
 (including bar thickness) match the lengths of xVec and yVec.
 If there is no way to do this within the shape definition
 due to overconstraining, a compromise is attempted, such as
 scaling the whole shape until either the width or the
 height is correct. Finally the shape is rotated to
 match the coordinate system of the box. The algorithm
 is the same one used in one-click placement.

## Syntax (C#)
```csharp
public void ScaleToBox(
	XYZ origin,
	XYZ xVec,
	XYZ yVec
)
```

## Parameters
- **origin** (`Autodesk.Revit.DB.XYZ`) - One corner of the rectangle.
- **xVec** (`Autodesk.Revit.DB.XYZ`) - Vector representing the first edge of the rectangle. The length
 must be positive.
- **yVec** (`Autodesk.Revit.DB.XYZ`) - Vector representing the second edge of the rectangle. Must
 be perpendicular to xVec.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - xVec has zero length.
 -or-
 yVec has zero length.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This RebarShapeDrivenAccessor is an instance of a spiral or multiplanar shape.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.
 -or-
 The operation has failed for geometric reasons, such as the box being too small
 given the bar diameter.

