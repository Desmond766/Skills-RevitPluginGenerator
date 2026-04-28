---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.CreateRevisionSchedule(Autodesk.Revit.DB.Document)
zh: 明细表
source: html/628f466d-8233-bc7f-13b0-68fc15f47b97.htm
---
# Autodesk.Revit.DB.ViewSchedule.CreateRevisionSchedule Method

**中文**: 明细表

Creates a revision schedule.

## Syntax (C#)
```csharp
public static ViewSchedule CreateRevisionSchedule(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The titleblock family document to which the new schedule will be added.

## Returns
The newly created schedule.

## Remarks
Revision schedules are added to titleblock families and become
 visible as part of titleblocks on sheets.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a titleblock family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

