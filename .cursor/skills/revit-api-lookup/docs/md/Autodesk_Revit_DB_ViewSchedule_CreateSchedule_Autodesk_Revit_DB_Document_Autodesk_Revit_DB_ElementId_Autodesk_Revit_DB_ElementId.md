---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.CreateSchedule(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/647440c1-dafc-61ba-0856-826fa408de9d.htm
---
# Autodesk.Revit.DB.ViewSchedule.CreateSchedule Method

**中文**: 明细表

Creates a regular schedule that can relate to a specific area scheme.

## Syntax (C#)
```csharp
public static ViewSchedule CreateSchedule(
	Document document,
	ElementId categoryId,
	ElementId areaSchemeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The ID of the category whose elements will be included in the schedule, or InvalidElementId for a multi-category schedule.
- **areaSchemeId** (`Autodesk.Revit.DB.ElementId`) - The ID of an area scheme in an area schedule, InvalidElementId otherwise.

## Returns
The newly created schedule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 categoryId is not a valid category for a regular schedule.
 -or-
 In a non-area schedule, areaSchemeId is not InvalidElementId.
 -or-
 In an area schedule, areaSchemeId is not the ID of an area scheme.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

