---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.ScaleToBoxFor3D(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ,System.Double)
source: html/63da560e-ad71-8421-8a65-c2ba846a289c.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.ScaleToBoxFor3D Method

Move and resize a spiral or multiplanar instance to fit within a specified box.
 The arguments are interpreted as an arbitrary rectangle in 3D with
 vertices: origin, origin+xVec, origin+xVec+yVec, origin+yVec. One end of the
 rebar shape is inscribed in this rectangle following the procedure described
 for the ScaleToBox method. The other end is placed in the parallel plane at
 distance (center-to-center) given by the height argument, in the
 direction of (xVec x yVec).
 Note that spiral shapes interpret the input arguments using a different convention
 than multiplanar shapes. For spiral shapes, the spiral start will be placed in
 the rectangle defined by origin, xVec, yVec, and the end of the spiral will be
 placed in the parallel plane. For multiplanar shapes, the rebar is placed with
 its primary shape definition located in the parallel plane defined by the height
 argument, and its connector segments extending in the direction opposite (xVec x yVec).
 This method replaces ScaleToBoxForSpiral() from prior releases.

## Syntax (C#)
```csharp
public void ScaleToBoxFor3D(
	XYZ origin,
	XYZ xVec,
	XYZ yVec,
	double height
)
```

## Parameters
- **origin** (`Autodesk.Revit.DB.XYZ`) - One corner of the rectangle.
- **xVec** (`Autodesk.Revit.DB.XYZ`) - Vector representing the first edge of the rectangle. The length
 must be positive.
- **yVec** (`Autodesk.Revit.DB.XYZ`) - Vector representing the second edge of the rectangle. Must
 be perpendicular to xVec.
- **height** (`System.Double`) - New value for the Height or MultiplanarDepth property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - xVec has zero length.
 -or-
 yVec has zero length.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor is not an instance of a spiral or multiplanar shape.
 -or-
 This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.
 -or-
 The operation has failed for geometric reasons, such as the box being too small
 given the bar diameter.

