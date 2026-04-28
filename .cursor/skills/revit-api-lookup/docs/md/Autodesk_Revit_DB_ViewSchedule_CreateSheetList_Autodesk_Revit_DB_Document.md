---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.CreateSheetList(Autodesk.Revit.DB.Document)
zh: 明细表
source: html/76fa4e7d-9201-b601-9924-0462e00cd883.htm
---
# Autodesk.Revit.DB.ViewSchedule.CreateSheetList Method

**中文**: 明细表

Creates a sheet list.

## Syntax (C#)
```csharp
public static ViewSchedule CreateSheetList(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.

## Returns
The newly created schedule.

## Remarks
A sheet list is a schedule of sheets in the project.
 It is a schedule of the Sheets category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

