---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.CreateViaOffset(Autodesk.Revit.DB.CurveLoop,System.Collections.Generic.IList{System.Double},Autodesk.Revit.DB.XYZ)
source: html/3097f423-9b0e-5496-bae2-3a82b6875414.htm
---
# Autodesk.Revit.DB.CurveLoop.CreateViaOffset Method

Creates a new curve loop that is an offset of the existing curve loop.

## Syntax (C#)
```csharp
public static CurveLoop CreateViaOffset(
	CurveLoop original,
	IList<double> offsetDists,
	XYZ normal
)
```

## Parameters
- **original** (`Autodesk.Revit.DB.CurveLoop`) - The original curve loop.
- **offsetDists** (`System.Collections.Generic.IList < Double >`) - The signed offset distances for each curve. The size of this array must match the size of the curve loop.
 Curve at position i will be offset with offsetDists[i].
- **normal** (`Autodesk.Revit.DB.XYZ`) - The normal of the offset plane.

## Returns
The offset curve loop.

## Remarks
For each curve i in the curve loop, the offset curve is theoretically defined by translating every point of the original curve by the
 vector offsetDist[i] * (curveTan x normal) where curveTan is the curve's unit tangent vector at the given point. The curves are then
 trimmed to create a continuous curve loop. For a planar curve loop, this amounts to pushing each point "to the right" of the curve
 loop by the signed offset distance offsetDist, within the plane of the curve loop. The "right" side of the curve loop at a given
 point on the curve loop is defined with reference to normal being thought of as the upward direction and curveTan being thought of
 as the forward direction, as if you are walking along the curve loop. It follows that if offsetDist[i] is positive, points will be
 offset to the right of the curve loop, whereas if offsetDist[i] is negative, points will be offset to the left of the curve loop.
 If the curve loop contains curves such as elliptical segments or splines, it is possible the offset creation will fail if
 Revit will not be able to trim contiguous curves to meet one another. If the offset is successful, offsets of those curve types
 will be created as HermiteSplines.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the curve loop could not be offset.

