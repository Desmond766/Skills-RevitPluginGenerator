---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetDefaultParameterNameForKeySchedule(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
zh: 明细表
source: html/70f24220-ca7b-6202-5167-1f8ca618b20b.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetDefaultParameterNameForKeySchedule Method

**中文**: 明细表

Gets the default parameter name that will be used when creating a key schedule.

## Syntax (C#)
```csharp
public static string GetDefaultParameterNameForKeySchedule(
	Document document,
	ElementId categoryId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The ID of the category of elements that the schedule's keys will be associated with.

## Returns
The default parameter name.

## Remarks
See ViewSchedule.KeyScheduleParameterName for details.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 categoryId is not a valid category for a key schedule.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

