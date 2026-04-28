---
kind: method
id: M:Autodesk.Revit.DB.AssemblyViewUtils.CreateSingleCategorySchedule(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/32780a72-3d3a-10d2-fece-c7016a21b79b.htm
---
# Autodesk.Revit.DB.AssemblyViewUtils.CreateSingleCategorySchedule Method

Creates a new single-category schedule assembly view for the assembly instance.

## Syntax (C#)
```csharp
public static ViewSchedule CreateSingleCategorySchedule(
	Document document,
	ElementId assemblyInstanceId,
	ElementId scheduleCategoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the view will be added.
- **assemblyInstanceId** (`Autodesk.Revit.DB.ElementId`) - Id of the assembly instance that owns the new view.
- **scheduleCategoryId** (`Autodesk.Revit.DB.ElementId`) - Id of the category for which the schedule will be created.
 Use ViewSchedule.IsValidCategoryForSchedule() to check if a category can be scheduled.

## Returns
A new single-category schedule assembly view.

## Remarks
The new single-category schedule will be preloaded with fields "Family and Type" and "Count".
 The schedule will be empty if there are no elements of the specified category in the assembly instance.
 The document must be regenerated before using the schedule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - assemblyInstanceId is not an AssemblyInstance.
 -or-
 scheduleCategoryId is not a valid category for a regular schedule.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

