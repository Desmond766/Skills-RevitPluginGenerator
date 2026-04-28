---
kind: method
id: M:Autodesk.Revit.DB.AssemblyViewUtils.CreateSingleCategorySchedule(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId,System.Boolean)
source: html/935a90c4-80e7-7dd7-7f78-592e4f458d5e.htm
---
# Autodesk.Revit.DB.AssemblyViewUtils.CreateSingleCategorySchedule Method

Creates a new single-category schedule assembly view for the assembly instance.

## Syntax (C#)
```csharp
public static ViewSchedule CreateSingleCategorySchedule(
	Document document,
	ElementId assemblyInstanceId,
	ElementId scheduleCategoryId,
	ElementId viewTemplateId,
	bool isAssigned
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the view will be added.
- **assemblyInstanceId** (`Autodesk.Revit.DB.ElementId`) - Id of the assembly instance that owns the new view.
- **scheduleCategoryId** (`Autodesk.Revit.DB.ElementId`) - Id of the category for which the schedule will be created.
 Use ViewSchedule.IsValidCategoryForSchedule() to check if a category can be scheduled.
- **viewTemplateId** (`Autodesk.Revit.DB.ElementId`) - Id of the view template that is used to create the view;
 if invalidElementId, the view will be created with the default settings.
- **isAssigned** (`System.Boolean`) - If true, the template will be assigned, if false, the template will be applied.

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
 -or-
 viewTemplateId is not a correct view template for the schedule view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

