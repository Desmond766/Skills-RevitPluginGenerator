---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.CreateSchedule(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/1ecd67b8-3b02-df2e-9b85-f8254aebf570.htm
---
# Autodesk.Revit.DB.ViewSchedule.CreateSchedule Method

**中文**: 明细表

Creates a regular schedule.

## Syntax (C#)
```csharp
public static ViewSchedule CreateSchedule(
	Document document,
	ElementId categoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The ID of the category whose elements will be included in the schedule, or InvalidElementId for a multi-category schedule.

## Returns
The newly created schedule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 categoryId is not a valid category for a regular schedule.
 -or-
 The Areas category was specified but an area scheme ID was not provided.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

