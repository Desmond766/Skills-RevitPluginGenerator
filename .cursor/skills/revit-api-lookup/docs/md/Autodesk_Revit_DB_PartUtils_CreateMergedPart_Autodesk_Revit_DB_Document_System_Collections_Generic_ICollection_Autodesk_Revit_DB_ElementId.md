---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.CreateMergedPart(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/062db0b2-fe9b-49a5-52e7-caa5297a05d1.htm
---
# Autodesk.Revit.DB.PartUtils.CreateMergedPart Method

Create a single merged part which represents the Parts
 specified by partsToMerge.

## Syntax (C#)
```csharp
public static PartMaker CreateMergedPart(
	Document document,
	ICollection<ElementId> partIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **partIds** (`System.Collections.Generic.ICollection < ElementId >`) - The elements that the merged part will be created from.

## Returns
The newly created PartMaker. Nothing nullptr a null reference ( Nothing in Visual Basic) if no parts are merged.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more element ids was not suitable for merging with the others.
 Specified elements should all be Parts, report the same material,
 creation and demolition phases, and have contiguous geometry.
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

