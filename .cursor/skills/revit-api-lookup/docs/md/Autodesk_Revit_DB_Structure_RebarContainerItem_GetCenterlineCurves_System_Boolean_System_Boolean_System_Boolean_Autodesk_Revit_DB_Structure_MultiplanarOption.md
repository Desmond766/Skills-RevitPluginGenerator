---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.GetCenterlineCurves(System.Boolean,System.Boolean,System.Boolean,Autodesk.Revit.DB.Structure.MultiplanarOption)
source: html/e82968e2-d333-95be-1d24-c45cdac94520.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.GetCenterlineCurves Method

A chain of curves representing the centerline of the rebar.

## Syntax (C#)
```csharp
public IList<Curve> GetCenterlineCurves(
	bool adjustForSelfIntersection,
	bool suppressHooks,
	bool suppressBendRadius,
	MultiplanarOption multiplanarOption
)
```

## Parameters
- **adjustForSelfIntersection** (`System.Boolean`) - If the curves overlap, as in a planar stirrup, this parameter controls
 whether they should be adjusted to avoid intersection (as in fine views),
 or kept in a single plane for simplicity (as in coarse views).
- **suppressHooks** (`System.Boolean`) - Identifies if the chain will include hooks curves.
- **suppressBendRadius** (`System.Boolean`) - Identifies if the connected chain will include unfilleted curves.
- **multiplanarOption** (`Autodesk.Revit.DB.Structure.MultiplanarOption`) - If the Rebar is a multi-planar shape, this parameter controls whether to generate only
 the curves in the primary plane (IncludeOnlyPlanarCurves), or to generate all curves,
 (IncludeAllMultiplanarCurves) including the out-of-plane connector segments as well as
 multi-planar copies of the primary plane curves.
 This argument is ignored for planar shapes.

## Returns
The centerline curves or empty array if the curves cannot be computed because
 the parameters values are inconsistent
 with the constraints of the RebarShape definition.

## Remarks
If the Rebar is a set, meaning GetLayoutRule() does not return Single,
 this method returns the first rebar in the set, even if the
 first bar is suppressed by IncludeFirstBar being false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

