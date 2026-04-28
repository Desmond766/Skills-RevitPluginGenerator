---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.CreateMaterialTakeoff(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/f9d4a1d9-a8fb-5d21-e719-c7ea11c53897.htm
---
# Autodesk.Revit.DB.ViewSchedule.CreateMaterialTakeoff Method

**中文**: 明细表

Creates a material takeoff.

## Syntax (C#)
```csharp
public static ViewSchedule CreateMaterialTakeoff(
	Document document,
	ElementId categoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The ID of the category whose elements will be included in the schedule,
 or InvalidElementId for a multi-category schedule.

## Returns
The newly created schedule.

## Remarks
A material takeoff is a schedule that displays information about
 the materials that make up elements in the model. Unlike regular
 schedules where each row (before grouping) represents a single
 element, each row in a material takeoff represents a single
 <element, material> pair.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 categoryId is not a valid category for a material takeoff.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

