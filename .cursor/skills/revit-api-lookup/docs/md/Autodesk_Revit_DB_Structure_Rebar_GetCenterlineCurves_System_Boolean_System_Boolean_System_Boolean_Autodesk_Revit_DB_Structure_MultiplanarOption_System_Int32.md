---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetCenterlineCurves(System.Boolean,System.Boolean,System.Boolean,Autodesk.Revit.DB.Structure.MultiplanarOption,System.Int32)
zh: 钢筋、配筋
source: html/7be7e413-bfac-bbd3-17b6-ff2008771afa.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetCenterlineCurves Method

**中文**: 钢筋、配筋

A chain of curves representing the centerline of the rebar.

## Syntax (C#)
```csharp
public IList<Curve> GetCenterlineCurves(
	bool adjustForSelfIntersection,
	bool suppressHooks,
	bool suppressBendRadius,
	MultiplanarOption multiplanarOption,
	int barPositionIndex
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
- **barPositionIndex** (`System.Int32`) - An index between 0 and (NumberOfBarPositions-1).
 Use the barPositionIndex to obtain all the curves at a specific index in the distribution.
 You can use GetNumberOfBarPositions() to verify if a specific rebar has more than one bar positions.
 Use GetDistributionType() to probe if the bars in a specific rebar have a varying shape. If so, you can retrieve the centerline curve geometry of that particular bar, by passing the appropriate index.
 When the distribution type of a rebar set is uniform, the form of the bars does not vary from one index to another.

## Returns
The centerline curves or empty array if the curves cannot be computed because
 the parameters values are inconsistent
 with the constraints of the RebarShape definition.

## Remarks
This method will return the centerline curves for bar at barPositionIndex even if this bar isn't included.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

