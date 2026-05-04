---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForKeynoteLegend(Autodesk.Revit.DB.Document)
zh: 明细表
source: html/0348b112-49f8-e9c7-02de-e728ee4d665d.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForKeynoteLegend Method

**中文**: 明细表

Gets the default view name that will be used when creating a keynote legend.

## Syntax (C#)
```csharp
public static string GetDefaultNameForKeynoteLegend(
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

