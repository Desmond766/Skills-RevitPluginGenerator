---
kind: method
id: M:Autodesk.Revit.DB.Architecture.SiteSubRegion.SetBoundary(System.Collections.Generic.IList{Autodesk.Revit.DB.CurveLoop})
source: html/9917625e-bbad-b783-5b36-9f1865fd4b14.htm
---
# Autodesk.Revit.DB.Architecture.SiteSubRegion.SetBoundary Method

Set the given curve loops as the boundary of an existing SiteSubRegion.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 with the introduction of the new Toposolid elements.  It is recommended that TopographySurface elements should be converted to Toposolid elements to enable better editing options.")]
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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the Sketch for the boundary of the current Subregion.
 -or-
 Cannot find an appropriate host topography surface for the SubRegion.
 -or-
 The given curve loops intersect with curve loops of existing SiteSubRegions hosted on the same TopographySurface.
 -or-
 The boundary of SubRegion is entirely inside or overlaps at least one existing BuildingPad hosted on the same TopographySurface. This behavior is not allowed.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing this SiteSubRegion is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing this SiteSubRegion is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing this SiteSubRegion has no open transaction.

