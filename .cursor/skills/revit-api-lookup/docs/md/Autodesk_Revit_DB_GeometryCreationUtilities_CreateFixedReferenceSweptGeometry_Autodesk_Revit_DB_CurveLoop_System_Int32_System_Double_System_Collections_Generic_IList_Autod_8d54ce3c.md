---
kind: method
id: M:Autodesk.Revit.DB.GeometryCreationUtilities.CreateFixedReferenceSweptGeometry(Autodesk.Revit.DB.CurveLoop,System.Int32,System.Double,System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop},Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.SolidOptions)
source: html/480f1fad-541f-56ab-117d-eca46ed1eb9f.htm
---
# Autodesk.Revit.DB.GeometryCreationUtilities.CreateFixedReferenceSweptGeometry Method

Creates a solid by sweeping one or more closed coplanar curve loops along a path while keeping the
 profile plane oriented so that a line in the plane that is initially perpendicular to a given fixed
 direction remains perpendicular as the profile is swept along the path.

## Syntax (C#)
```csharp
public static Solid CreateFixedReferenceSweptGeometry(
	CurveLoop sweepPath,
	int pathAttachmentCrvIdx,
	double pathAttachmentParam,
	IList<CurveLoop> profileLoops,
	XYZ fixedReferenceDirection,
	SolidOptions solidOptions
)
```

## Parameters
- **sweepPath** (`Autodesk.Revit.DB.CurveLoop`) - The sweep path, consisting of a set of contiguous curves. The path may be open or closed,
 but should not otherwise have any self-intersections. The path may be planar or non-planar.
 With the exception of path curves that lie in a plane parallel to %fixedReferenceDirection%,
 the curve's tangent should be nowhere parallel to %fixedReferenceDirection%. If the sweep path
 has corners, the solid segments that meet at a corner may not meet smoothly.
- **pathAttachmentCrvIdx** (`System.Int32`) - The index of the curve in the sweep path where the profile loops are situated.
 Indexing starts at 0. Together with pathAttachmentParam, this specifies the profile's attachment point.
- **pathAttachmentParam** (`System.Double`) - Parameter of the path curve specified by pathAttachmentCrvIdx.
 The profile curves must lie in the plane orthogonal to the path at this attachment point.
- **profileLoops** (`System.Collections.Generic.IList < CurveLoop >`) - The curve loops defining the planar domain to be swept along the path.
 No conditions are imposed on the orientations of the loops; this function will use copies of the input loops
 that have been oriented as necessary to conform to Revit's orientation conventions.
 Restrictions:
 The loops must lie in the plane orthogonal to the path at the attachment point as defined above. The curve loop(s) must be closed and should define a single planar domain (one outer loop and, optionally, one or more inner loops). The curve loops must be without intersections, self-intersections, or degeneracies. No loop may contain just one closed curve - split such loops into two or more curves beforehand.
- **fixedReferenceDirection** (`Autodesk.Revit.DB.XYZ`) - A unit vector specifying the fixed direction used to control how the profile plane is swept along the path; see the description and remarks above.
 The profile CurveLoops do not satisfy the input requirements.
- **solidOptions** (`Autodesk.Revit.DB.SolidOptions`) - The optional information to control the properties of the Solid.

## Returns
The requested solid.

## Remarks
The profile loops must lie in a plane orthogonal to the sweep path at some attachment point along the path.
 An example where this method is useful is in constructing railings. If the fixed direction is the upward
 vertical, a line in the profile plane that is initially horizontal will remain horizontal as the profile
 is swept along the path. This property can be used to ensure that the top of the railing remains horizontal
 all along the railing.
The STEP ISO 10303-42 and IFC standards define a "Fixed Reference Sweep" similar to this sweep method, though
 there are some minor technical differences:
 The STEP ISO reference describes a specific parameterization of the swept surface, whereas we do not guarantee any particular parameterization (partly because we simplify the surface when possible). Neither reference mentions what should be done if the sweep pathâ€™s tangent is tangent to the reference direction at some point(s) or along the entire directrix. Both references impose unnecessary conditions, and they're inconsistent: STEP says "the swept_curve is required to be a curve lying in the plane z = 0" while IFC says "The SweptArea shall lie in the plane z = 0" (SweptArea is the profile being swept).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input argument sweepPath should at least contain one curve.
 -or-
 The input argument pathAttachmentCrvIdx is not valid.
 -or-
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - fixedReferenceDirection is not length 1.0.

