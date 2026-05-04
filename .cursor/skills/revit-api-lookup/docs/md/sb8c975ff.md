---
kind: method
id: M:Autodesk.Revit.DB.GeometryCreationUtilities.CreateRevolvedGeometry(Autodesk.Revit.DB.Frame,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},System.Double,System.Double,Autodesk.Revit.DB.SolidOptions)
source: html/c101e492-a39c-7051-246e-9b2e6e1b91f9.htm
---
# Autodesk.Revit.DB.GeometryCreationUtilities.CreateRevolvedGeometry Method

Creates a solid of revolution by revolving a set of closed curve loops around an axis by a specified angle.

## Syntax (C#)
```csharp
public static Solid CreateRevolvedGeometry(
	Frame coordinateFrame,
	IList<CurveLoop> profileLoops,
	double startAngle,
	double endAngle,
	SolidOptions solidOptions
)
```

## Parameters
- **coordinateFrame** (`Autodesk.Revit.DB.Frame`) - A right-handed orthonormal frame of vectors. The frame's z-vector is the axis of revolution. The start and end angle inputs refer to this frame.
- **profileLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The profile loops to be revolved. No conditions are imposed on the orientations of the loops.
 This function will use copies of the input loops that have been oriented as necessary to conform to Revit's orientation conventions.
 Restrictions:
 The loops must lie in the xz coordinate plane of the input coordinate frame. The curve loop(s) must be closed and must define a single planar domain (one outer loop and, optionally, one or more inner loops). The curve loops must be without intersections, self-intersections, or degeneracies. The loops must lie on the "right" side of the z axis (where x >= 0). No loop may contain just one closed curve - split such loops into two or more curves beforehand.
- **startAngle** (`System.Double`) - The start angle for the revolution, in radians,
 measured counter-clockwise from the coordinate frame's x-axis as viewed looking down the frame's z-axis.
- **endAngle** (`System.Double`) - The end angle for the revolution, using the same conventions as the start angle.
 The end angle may be less than (but not equal to) the start angle.
 The total angle of revolution, equal to the absolute value of (endAngle â€“ startAngle), must be at most 2*PI.
- **solidOptions** (`Autodesk.Revit.DB.SolidOptions`) - The optional information to control the properties of the Solid.

## Returns
The requested solid. Note that if less than a full revolution is used, planar end faces will be added as part of the solid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input argument coordinateFrame should be a right-handed orthonormal frame of vectors.
 -or-
 The profile CurveLoops do not satisfy the input requirements.
 -or-
 The absolute value of %(endAngle â€“ startAngle)%, must be at most 2*PI.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

