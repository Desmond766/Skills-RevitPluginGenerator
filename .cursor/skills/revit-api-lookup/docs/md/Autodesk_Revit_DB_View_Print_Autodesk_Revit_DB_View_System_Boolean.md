---
kind: method
id: M:Autodesk.Revit.DB.View.Print(Autodesk.Revit.DB.View,System.Boolean)
zh: 视图
source: html/8531f6cf-5b94-198a-f8ab-0dd488ac4504.htm
---
# Autodesk.Revit.DB.View.Print Method

**中文**: 视图

Print this view with the given view template, and either the view's document's print setting or the print setting of the current active document.

## Syntax (C#)
```csharp
public void Print(
	View viewTemplate,
	bool useCurrentPrintSettings
)
```

## Parameters
- **viewTemplate** (`Autodesk.Revit.DB.View`) - The view template which apply to the view.
- **useCurrentPrintSettings** (`System.Boolean`) - If true, print the view with the print setting of the current active document;
otherwise with the view's document's print setting.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the view cannot be printed.

