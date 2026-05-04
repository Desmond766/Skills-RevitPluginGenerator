---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.CreateParts(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/64df9046-53f3-16d9-f6aa-957a3b3d73b5.htm
---
# Autodesk.Revit.DB.PartUtils.CreateParts Method

Creates a new set of parts out of the original elements.

## Syntax (C#)
```csharp
public static void CreateParts(
	Document document,
	ICollection<ElementId> elementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the elements.
- **elementIds** (`System.Collections.Generic.ICollection < ElementId >`) - The elements that parts will be created from.

## Remarks
Parts will be added to the model after regeneration.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more element ids was not permitted for creating parts.
 Elements should be of a valid category and the ids should be valid and should not already be divided into parts.
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

