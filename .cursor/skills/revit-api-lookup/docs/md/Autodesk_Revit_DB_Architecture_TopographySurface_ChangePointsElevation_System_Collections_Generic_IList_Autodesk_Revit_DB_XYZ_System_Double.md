---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.ChangePointsElevation(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Double)
source: html/099b30df-e4c9-fe81-6a32-6a55b57994a6.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.ChangePointsElevation Method

Changes the elevation value for points

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 with the introduction of the new Toposolid elements.  It is recommended that TopographySurface elements should be converted to Toposolid elements to enable better editing options.")]
public void ChangePointsElevation(
	IList<XYZ> points,
	double elevationValue
)
```

## Parameters
- **points** (`System.Collections.Generic.IList < XYZ >`) - The points to be modified.
- **elevationValue** (`System.Double`) - The new elevation value.

## Remarks
If none of the points in the collection doesn's exist, an exception will be thrown.
 This function ignores input points that do not exist, unless all of the input points do not exist, which will result in an exception.
 This applies to a TopographySurface element (not a SiteSubRegion or a topography surface associated with a BuildingPad), which shoule be in an active TopographyEditScope.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There are no points in the input points set.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for elevationValue must be no more than 30000 feet in absolute value.
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

