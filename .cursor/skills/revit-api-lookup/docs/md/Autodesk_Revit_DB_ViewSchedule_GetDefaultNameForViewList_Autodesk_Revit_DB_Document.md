---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForViewList(Autodesk.Revit.DB.Document)
zh: 明细表
source: html/5239321b-a11c-8800-efcb-a88244d486d3.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForViewList Method

**中文**: 明细表

Gets the default view name that will be used when creating a view list.

## Syntax (C#)
```csharp
public static string GetDefaultNameForViewList(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document to which the new schedule will be added.

## Returns
The default view name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

