---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForKeySchedule(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/5134fdd5-5b72-c7c8-a62a-334734dd829f.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForKeySchedule Method

**中文**: 明细表

Gets the default view name that will be used when creating a key schedule.

## Syntax (C#)
```csharp
public static string GetDefaultNameForKeySchedule(
	Document document,
	ElementId categoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The ID of the category of elements that the schedule's keys will be associated with.

## Returns
The default view name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 categoryId is not a valid category for a key schedule.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

