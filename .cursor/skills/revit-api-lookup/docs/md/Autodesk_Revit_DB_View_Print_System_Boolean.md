---
kind: method
id: M:Autodesk.Revit.DB.View.Print(System.Boolean)
zh: 视图
source: html/dddea576-5516-5c33-5cd4-a580fe59d1ea.htm
---
# Autodesk.Revit.DB.View.Print Method

**中文**: 视图

Print this view with the default view template, and either the view's document's print setting or the print setting of the current active document.

## Syntax (C#)
```csharp
public void Print(
	bool useCurrentPrintSettings
)
```

## Parameters
- **useCurrentPrintSettings** (`System.Boolean`) - If true, print the view with the print setting of the current active document;
otherwise with the view's document's print setting.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the view cannot be printed.

