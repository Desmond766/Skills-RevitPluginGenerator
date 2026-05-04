---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.GetCenterlineCurves(System.Boolean,System.Boolean,System.Boolean)
source: html/ddd3caf7-9e00-4137-805f-33ef21a13f8f.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.GetCenterlineCurves Method

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
If the Rebar is a set, meaning GetLayoutRule() does not return Single,
 this method returns the first rebar in the set, even if the
 first bar is suppressed by IncludeFirstBar being false.

