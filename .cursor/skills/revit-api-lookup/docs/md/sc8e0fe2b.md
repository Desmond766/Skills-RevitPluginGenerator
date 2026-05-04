---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.CreateKeynoteLegend(Autodesk.Revit.DB.Document)
zh: 明细表
source: html/38bafb86-00b8-2947-7cc1-7198d274fe20.htm
---
# Autodesk.Revit.DB.ViewSchedule.CreateKeynoteLegend Method

**中文**: 明细表

Creates a keynote legend.

## Syntax (C#)
```csharp
public static ViewSchedule CreateKeynoteLegend(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.

## Returns
The newly created schedule.

## Remarks
A keynote legend is a schedule of the Keynote Tags category.

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

