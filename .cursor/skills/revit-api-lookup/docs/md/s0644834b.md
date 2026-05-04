---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.IsCurveLoopConvexWithOpenings(Autodesk.Revit.DB.CurveLoop,Autodesk.Revit.DB.Wall,Autodesk.Revit.DB.IFC.IFCRange,System.Boolean@)
source: html/02698a4b-0fc2-a3cc-2506-70b8f8c2467f.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.IsCurveLoopConvexWithOpenings Method

Checks if the region bounded by the input curve loop can be represented as the subtraction of 0 or more convex polygons from a base convex polygon.

## Syntax (C#)
```csharp
public static bool IsCurveLoopConvexWithOpenings(
	CurveLoop inputCurveLoop,
	Wall wall,
	IFCRange range,
	out bool loopIsDegenerate
)
```

## Parameters
- **inputCurveLoop** (`Autodesk.Revit.DB.CurveLoop`) - The input curve loop. It is intended that this curve loop have been obtained from the elevation profile of a wall.
- **wall** (`Autodesk.Revit.DB.Wall`) - The wall from which the curve loop was obtained.
- **range** (`Autodesk.Revit.DB.IFC.IFCRange`) - The range extents of the wall.
- **loopIsDegenerate** (`System.Boolean %`) - If the function returns false but this returns true, the loop could be obtained but was degenerate. Thus there is no extrusion
 that can be produced.

## Returns
True if the region can be represented by a boolean combination of polygons, false otherwise.

## Remarks
This function is intended to be used to determine if the geometry of a wall with an elevation profile can be successfully represented
 as a vertical extrusion with one or more openings removed.
 If this function is to return true, the subtracting polygons must each have at least one edge coincident with the base convex polygon.
 Before the check is performed, this input curve will be trimmed by the range extents of the wall, if any.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

