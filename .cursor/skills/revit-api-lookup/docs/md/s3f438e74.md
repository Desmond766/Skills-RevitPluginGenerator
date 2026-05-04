---
kind: method
id: M:Autodesk.Revit.DB.GeometryCreationUtilities.CreateSweptGeometry(Autodesk.Revit.DB.CurveLoop,System.Int32,System.Double,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/0b9e6079-8c3b-2071-4311-c8c0b0e45ee9.htm
---
# Autodesk.Revit.DB.GeometryCreationUtilities.CreateSweptGeometry Method

Creates a solid by sweeping one or more closed coplanar curve loops along a path.

## Syntax (C#)
```csharp
public static Solid CreateSweptGeometry(
	CurveLoop sweepPath,
	int pathAttachmentCrvIdx,
	double pathAttachmentParam,
	IList<CurveLoop> profileLoops
)
```

## Parameters
- **sweepPath** (`Autodesk.Revit.DB.CurveLoop`) - The sweep path, consisting of a set of contiguous curves. The path may be open or closed,
 but should not otherwise have any self-intersections. The path may be planar or non-planar.
- **pathAttachmentCrvIdx** (`System.Int32`) - The index of the curve in the sweep path where the profile loops are situated.
 Indexing starts at 0. Together with pathAttachmentParam, this specifies the profile's attachment point.
- **pathAttachmentParam** (`System.Double`) - Parameter of the path curve specified by pathAttachmentCrvIdx.
 The profile curves must lie in the plane orthogonal to the path at this attachment point.
- **profileLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The curve loops defining the planar domain to be swept along the path.
 No conditions are imposed on the orientations of the loops:
 this function will use copies of the input loops that have been oriented as necessary to conform to Revit's orientation conventions.
 Restrictions:
 The loops must lie in the plane orthogonal to the path at the attachment point as defined above. The curve loop(s) must be closed and should define a single planar domain (one outer loop and, optionally, one or more inner loops) The curve loops must be without intersections, self-intersections, or degeneracies. No loop may contain just one closed curve - split such loops into two or more curves beforehand.

## Returns
The requested solid.

## Remarks
The profile loops must lie in a plane orthogonal to the sweep path at some attachment point along the path.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input argument sweepPath should at least contain one curve.
 -or-
 The input argument pathAttachmentCrvIdx is not valid.
 The given attachment point doesn't lie in the plane of the Curve Loop.
 -or-
 The profile CurveLoops do not satisfy the input requirements.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the swept solid.

