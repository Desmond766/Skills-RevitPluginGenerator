---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.GetTransformedCenterlineCurves(System.Boolean,System.Boolean,System.Boolean,System.Int32)
source: html/f6064020-988b-b5b4-08ae-0db25f0a0868.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.GetTransformedCenterlineCurves Method

A chain of curves representing the centerline of the rebar.

## Syntax (C#)
```csharp
public IList<Curve> GetTransformedCenterlineCurves(
	bool adjustForSelfIntersection,
	bool suppressHooks,
	bool suppressBendRadius,
	int barPositionIndex
)
```

## Parameters
- **adjustForSelfIntersection** (`System.Boolean`) - If the curves overlap, as in a planar stirrup, this parameter controls
 whether they should be adjusted to avoid intersection (as in fine views),
 or kept in a single plane for simplicity (as in coarse views).
- **suppressHooks** (`System.Boolean`) - Identifies if the chain will include hooks curves.
- **suppressBendRadius** (`System.Boolean`) - Identifies if the connected chain will include unfilleted curves.
- **barPositionIndex** (`System.Int32`) - The bar index.

## Returns
The centerline curves or empty array if the curves cannot be computed because
 the parameters values are inconsistent
 with the constraints of the RebarShape definition.

## Remarks
This method will return the centerline curves for bar at barPositionIndex even if this bar isn't included.
 The curves are in the final position. The BarPositionTransform (representing the relative position of any individual bar in the set - a translation along the distribution path)
 and MovedBarTransform (representing the movement of the bar relative to its default position along the distribution path) will be applied to the returned curves.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].

