---
kind: method
id: M:Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForSheetList(Autodesk.Revit.DB.Document)
zh: 明细表
source: html/523987e1-4fcc-5a11-9cf8-2c2bbcaa62a0.htm
---
# Autodesk.Revit.DB.ViewSchedule.GetDefaultNameForSheetList Method

**中文**: 明细表

Gets the default view name that will be used when creating a sheet list.

## Syntax (C#)
```csharp
public static string GetDefaultNameForSheetList(
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

