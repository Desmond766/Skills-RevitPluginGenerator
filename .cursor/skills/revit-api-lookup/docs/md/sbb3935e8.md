---
kind: method
id: M:Autodesk.Revit.DB.Architecture.BuildingPad.SetBoundary(System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/db8aa1c9-d196-6095-f289-5d5785e0e5cc.htm
---
# Autodesk.Revit.DB.Architecture.BuildingPad.SetBoundary Method

Set a given curve loops as the boundary of the current BuildingPad element.

## Syntax (C#)
```csharp
public void SetBoundary(
	IList<CurveLoop> curveLoops
)
```

## Parameters
- **curveLoops** (`System.Collections.Generic.IList < CurveLoop >`) - A collection of curve loops to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input curve loops cannot compose a valid boundary, that means:
 no curve loop is contained in the given collection;
 these curve loops intersect with each other for some of them;
 or each curve loop is not closed individually;
 or each curve loop is not planar;
 or each curve loop is not in a plane parallel to the horizontal(XY) plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the Sketch for the boundary of current BuildingPad.
 -or-
 Cannot find an appropriate hosting topography surface for this BuildingPad.
 -or-
 This topography surface cannot be the host of this BuildingPad.
 -or-
 The given curve loops intersect with curve loops of existing BuildingPads hosted on the same TopographySurface.
 -or-
 There is at least one existing SubRegion which is completely inside or overlap the boundary of current BuildingPad hosted on the same TopographySurface. This behavior is not allowed.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing this BuildingPad is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing this BuildingPad is being loaded, or is in the midst of another
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing this BuildingPad has no open transaction.

