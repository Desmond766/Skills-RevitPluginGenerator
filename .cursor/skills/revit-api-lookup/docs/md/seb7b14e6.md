---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.ChangePointElevation(Autodesk.Revit.DB.XYZ,System.Double)
source: html/6433254d-a875-0253-def2-e0573639af3e.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.ChangePointElevation Method

Changes the elevation value for a point.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024 with the introduction of the new Toposolid elements.  It is recommended that TopographySurface elements should be converted to Toposolid elements to enable better editing options.")]
public void ChangePointElevation(
	XYZ point,
	double elevationValue
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point to be modified.
- **elevationValue** (`System.Double`) - The new elevation value.

## Remarks
If the point doesn't exist in the current TopographySurface, an exception will be thrown.
 This applies to a TopographySurface element (not a SiteSubRegion or a topography surface associated with a BuildingPad), which should be in an active TopographyEditScope.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input point does not exist in the current topography surface.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for elevationValue must be no more than 30000 feet in absolute value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This element is not a TopographySurface.
 -or-
 The points of this topography surface are not editable.
 -or-
 The TopographySurface element is not in an active TopographyEditScope.
 Modification cannot be made on this TopographySurface.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document containing this TopographySurface is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document containing this TopographySurface is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document containing this TopographySurface has no open transaction.

