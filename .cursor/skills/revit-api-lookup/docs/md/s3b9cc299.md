---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.CreateNoteBlock(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/dd90c14c-1cf4-2e8d-035e-35bda60a91d8.htm
---
# Autodesk.Revit.DB.ViewSchedule.CreateNoteBlock Method

**中文**: 明细表

Creates a note block.

## Syntax (C#)
```csharp
public static ViewSchedule CreateNoteBlock(
	Document document,
	ElementId familyId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.
- **familyId** (`Autodesk.Revit.DB.ElementId`) - The ID of the family whose elements will be included in the schedule.

## Returns
The newly created schedule.

## Remarks
A note block is a schedule of the Generic Annotations category
 that shows elements of a single family rather than all elements
 in the category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 familyId is not a valid family for a note block.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

