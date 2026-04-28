---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.GetCenterlineCurves(System.Boolean,System.Boolean,System.Boolean)
source: html/1feb6854-6d32-e08c-1f90-21ffecb36f1b.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.GetCenterlineCurves Method

A chain of curves representing the centerline of the rebar.

## Syntax (C#)
```csharp
public IList<Curve> GetCenterlineCurves(
	bool adjustForSelfIntersection,
	bool suppressHooks,
	bool suppressBendRadius
)
```

## Parameters
- **adjustForSelfIntersection** (`System.Boolean`) - If the curves overlap, as in a planar stirrup, this parameter controls
 whether they should be adjusted to avoid intersection (as in fine views),
 or kept in a single plane for simplicity (as in coarse views).
- **suppressHooks** (`System.Boolean`) - Identifies if the chain will include hooks curves.
- **suppressBendRadius** (`System.Boolean`) - Identifies if the connected chain will include unfilleted curves.

## Returns
The centerline curves or empty array if the curves cannot be computed because
 the parameters values are inconsistent
 with the constraints of the RebarShape definition.

## Remarks
This method will return the centerline curves for the first bar in set even if this bar isn't included.

