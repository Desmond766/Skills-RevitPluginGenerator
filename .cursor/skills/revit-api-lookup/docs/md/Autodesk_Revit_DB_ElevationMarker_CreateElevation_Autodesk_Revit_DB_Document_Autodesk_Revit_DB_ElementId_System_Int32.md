---
kind: method
id: M:Autodesk.Revit.DB.ElevationMarker.CreateElevation(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,System.Int32)
source: html/ef15bad0-1f09-2a61-b74b-f4967137a47b.htm
---
# Autodesk.Revit.DB.ElevationMarker.CreateElevation Method

Creates a new elevation ViewSection on the ElevationMarker at the desired index.

## Syntax (C#)
```csharp
public ViewSection CreateElevation(
	Document document,
	ElementId viewPlanId,
	int index
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new elevation ViewSection will be added.
- **viewPlanId** (`Autodesk.Revit.DB.ElementId`) - The id of a ViewPlan in which the ElevationMarker is visible. The new elevation ViewSection will derive its extents
 and inherit settings from the ViewPlan.
- **index** (`System.Int32`) - The index on the ElevationMarker where the new elevation ViewSection will be placed.
 The index on the ElevationMarker must be valid and unused.
 View direction is determined by the index.

## Returns
The new elevation ViewSection.

## Remarks
The ViewFamilyType for the new elevation ViewSection is inherited from the ElevationMarker.
 The new elevation ViewSection will receive a unique view name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId viewPlanId does not correspond to a ViewPlan.
 -or-
 index is occupied or out of range.
 -or-
 Elevation view creation is not allowed in this family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Only reference elevations can be hosted on this ElevationMarker.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

