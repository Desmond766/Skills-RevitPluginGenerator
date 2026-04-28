---
kind: method
id: M:Autodesk.Revit.DB.Electrical.ElectricalLoadAreaData.CreateElectricalLoadAreas(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/1fa518f5-80e2-cae3-a075-ff06625edc32.htm
---
# Autodesk.Revit.DB.Electrical.ElectricalLoadAreaData.CreateElectricalLoadAreas Method

Creates electrical load areas on all the empty plan circuits of the given level.

## Syntax (C#)
```csharp
public static ISet<ElementId> CreateElectricalLoadAreas(
	Document doc,
	ElementId levelId,
	ElementId phaseId
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document where the created electrical load areas are.
- **levelId** (`Autodesk.Revit.DB.ElementId`) - The base level on which the created electrical load areas exist.
- **phaseId** (`Autodesk.Revit.DB.ElementId`) - The associated phase in which the created electrical load areas exist.

## Returns
The created electrical load areas.

## Remarks
Use the HasCircuitsWithoutElectricalLoadAreas to check whether there are empty plan circuits in which there are no electrical load areas, if there are empty plan circuits, this API will create electrical load areas on each of them, otherwise, it will create nothing.
 In most cases, the electrical load areas will be created, updated and deleted automatically, but in some cases, there are some empty plan circuits and need to create electrical load areas on each of them.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - doc is not a project document.
 -or-
 The ElementId levelId is not a Level.
 -or-
 The id does not represent a valid phase.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

