---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.CreateKeySchedule(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/98a8f20f-c442-3e2e-02fb-e09dabee0fbe.htm
---
# Autodesk.Revit.DB.ViewSchedule.CreateKeySchedule Method

**中文**: 明细表

Create a key schedule.

## Syntax (C#)
```csharp
public static ViewSchedule CreateKeySchedule(
	Document document,
	ElementId categoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The ID of the category of elements that the schedule's keys will be associated with.

## Returns
The newly created schedule.

## Remarks
A key schedule displays abstract "key" elements that can be used to
 populate parameters of ordinary model elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 categoryId is not a valid category for a key schedule.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

