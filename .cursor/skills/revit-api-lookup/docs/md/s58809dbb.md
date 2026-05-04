---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForSchedule(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/fb59c48e-a7ab-1c99-60bb-3cda123691bb.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForSchedule Method

**中文**: 明细表

Gets the default view name that will be used when creating a regular schedule.

## Syntax (C#)
```csharp
public static string GetDefaultNameForSchedule(
	Document document,
	ElementId categoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The ID of the category whose elements will be included in the schedule, or InvalidElementId for a multi-category schedule.

## Returns
The default view name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 categoryId is not a valid category for a regular schedule.
 -or-
 The Areas category was specified but an area scheme ID was not provided.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

