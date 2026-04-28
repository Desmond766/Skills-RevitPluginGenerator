---
kind: method
id: M:Autodesk.Revit.DB.PartUtils.CreateParts(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.LinkElementId})
source: html/fcadf274-66b3-21df-aaba-00ea79c70dcb.htm
---
# Autodesk.Revit.DB.PartUtils.CreateParts Method

Creates a new set of parts out of the original elements.

## Syntax (C#)
```csharp
public static void CreateParts(
	Document document,
	ICollection<LinkElementId> hostOrLinkElementIds
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the elements.
- **hostOrLinkElementIds** (`System.Collections.Generic.ICollection < LinkElementId >`) - The elements that parts will be created from.

## Remarks
Parts will be added to the model after regeneration.
 To get the ids of the parts created by this method use PartUtils.GetAssociatedParts() with the contents of hostOrLinkElementIds.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more element ids was not permitted for creating parts.
 HostOrLinkElements should be of a valid category and the ids should be valid and should not already be divided into parts.
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

