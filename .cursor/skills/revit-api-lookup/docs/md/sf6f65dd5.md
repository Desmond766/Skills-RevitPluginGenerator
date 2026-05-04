---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.MovePoints(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},Autodesk.Revit.DB.XYZ)
source: html/189b0ff1-9666-b875-eeb9-dbd12dc5013f.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.MovePoints Method

Moves a collection of points in a topography surface by a designated vector.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 with the introduction of the new Toposolid elements.  It is recommended that TopographySurface elements should be converted to Toposolid elements to enable better editing options.")]
public void MovePoints(
	IList<XYZ> movedPoints,
	XYZ moveVector
)
```

## Parameters
- **movedPoints** (`System.Collections.Generic.IList < XYZ >`) - The points to be moved.
- **moveVector** (`Autodesk.Revit.DB.XYZ`) - The vector which describes the distance and direction for the move.
 Note that the Z value represents a change in elevation, pass Z=0 to move the point without changing the elevation.

## Remarks
The points which don't exist in the current TopographySurface will be ignored.
 This function ignores input points that do not exist, unless all of the input points do not exist, which will result in an exception.
 This applies to a TopographySurface element (not a SiteSubRegion or a topography surface associated with a BuildingPad), which shoule be in an active TopographyEditScope.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There are no points in the input points set.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This element is not a TopographySurface.
 -or-
 The points of this topography surface are not editable.
 -or-
 The TopographySurface element is not in an active TopographyEditScope.
 Modification cannot be made on this TopographySurface.
 -or-
 None of the input points exists in the current TopographySurface.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing this TopographySurface is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing this TopographySurface is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing this TopographySurface has no open transaction.

