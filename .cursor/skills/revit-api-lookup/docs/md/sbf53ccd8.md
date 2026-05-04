---
kind: method
id: M:Autodesk.Revit.DB.ElevationMarker.CreateReferenceElevation(Autodesk.Revit.DB.Document,System.Int32,Autodesk.Revit.DB.ElementId)
source: html/38ef8e37-3f09-9e01-5e34-031fb7490ffc.htm
---
# Autodesk.Revit.DB.ElevationMarker.CreateReferenceElevation Method

Creates a reference elevation on the ElevationMarker at the desired index.

## Syntax (C#)
```csharp
public void CreateReferenceElevation(
	Document document,
	int index,
	ElementId viewIdToReference
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new reference elevation will be added.
- **index** (`System.Int32`) - The index on the ElevationMarker where the reference elevation will be placed.
- **viewIdToReference** (`Autodesk.Revit.DB.ElementId`) - The view which will be referenced.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId viewIdToReference does not correspond to a View.
 -or-
 This view cannot be referenced by elevations.
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

