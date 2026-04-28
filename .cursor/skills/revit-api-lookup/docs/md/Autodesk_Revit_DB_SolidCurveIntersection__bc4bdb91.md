---
kind: type
id: T:Autodesk.Revit.DB.SolidCurveIntersection
source: html/888716e3-376f-c4db-abe3-4e826c799656.htm
---
# Autodesk.Revit.DB.SolidCurveIntersection

This class represents the results of a calculation of intersection between a solid volume and a curve.

## Syntax (C#)
```csharp
public class SolidCurveIntersection : IEnumerable<Curve>, 
	IDisposable
```

## Remarks
The results contain a collection of curves and a collection of curve extents (which are the parameters of intersection
 from the original input curve). Depending on the SolidCurveIntersectionMode option passed when
 executing the calculation, the curve segments and curve extents represent either the extents of the curve
 which exist inside the solid, or the extents of the curve which exist outside the solid.
 If the curve is entirely inside the solid, and the option is CurveSegmentsOutside, or if the curve
 is entirely outside the solid, and the option is CurveSegmentsInside, this results object will be empty.
 Note that curves aligned with the bounding faces of the solid are considered to be inside by this utility.

