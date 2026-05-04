---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForSchedule(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/0d50a2aa-67b3-6a22-c832-8aa5a8360409.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForSchedule Method

**中文**: 明细表

Gets the default view name that will be used when creating a schedule.

## Syntax (C#)
```csharp
public static string GetDefaultNameForSchedule(
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
The default view name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 categoryId is not a valid category for a regular schedule.
 -or-
 In a non-area schedule, areaSchemeId is not InvalidElementId.
 -or-
 In an area schedule, areaSchemeId is not the ID of an area scheme.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

