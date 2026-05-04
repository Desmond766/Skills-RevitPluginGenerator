---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.MovePoint(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.XYZ)
source: html/3068f86b-519e-55b4-f571-26ed441f3836.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.MovePoint Method

Moves a point in a TopographySurface to a new designated location.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 with the introduction of the new Toposolid elements.  It is recommended that TopographySurface elements should be converted to Toposolid elements to enable better editing options.")]
public void MovePoint(
	XYZ movedPoint,
	XYZ targetPoint
)
```

## Parameters
- **movedPoint** (`Autodesk.Revit.DB.XYZ`) - The point to be moved.
- **targetPoint** (`Autodesk.Revit.DB.XYZ`) - The new designated location of this point will move to.

## Remarks
If targetPt exists, the movedPt will be deleted. That means if movedPoint is moved to become a duplicate of an existing
 point, movedPoint will be deleted instead becuase both points cannot exist at the same location.
 This applies to a TopographySurface element (not a SiteSubRegion or a topography surface associated with a BuildingPad), which shoule be in an active TopographyEditScope.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input point does not exist in the current topography surface.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This element is not a TopographySurface.
 -or-
 The points of this topography surface are not editable.
 -or-
 The TopographySurface element is not in an active TopographyEditScope.
 Modification cannot be made on this TopographySurface.
 -or-
 The input point doesn't exist in the current TopographySurface.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing this TopographySurface is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing this TopographySurface is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing this TopographySurface has no open transaction.

