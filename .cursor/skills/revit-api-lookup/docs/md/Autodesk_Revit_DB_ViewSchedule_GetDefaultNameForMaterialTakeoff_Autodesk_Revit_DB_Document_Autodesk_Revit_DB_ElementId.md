---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForMaterialTakeoff(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/9c91593a-2e48-f9af-0ee4-da8c7699b9ba.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForMaterialTakeoff Method

**中文**: 明细表

Gets the default view name that will be used when creating a material takeoff.

## Syntax (C#)
```csharp
public static string GetDefaultNameForMaterialTakeoff(
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
 categoryId is not a valid category for a material takeoff.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

