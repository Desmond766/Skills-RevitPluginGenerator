---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForRevisionSchedule(Autodesk.Revit.DB.Document)
zh: 明细表
source: html/505d8d34-633f-45c8-50df-334d2c15f167.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForRevisionSchedule Method

**中文**: 明细表

Gets the default view name that will be used when creating a revision schedule.

## Syntax (C#)
```csharp
public static string GetDefaultNameForRevisionSchedule(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The titleblock family document to which the new schedule will be added.

## Returns
The default view name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a titleblock family.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

