---
kind: method
id: M:Autodesk.Revit.DB.View.Print(Autodesk.Revit.DB.View)
zh: 视图
source: html/727d7624-1155-43d6-7e18-b6fa7949e097.htm
---
# Autodesk.Revit.DB.View.Print Method

**中文**: 视图

Print this view with the given view template and using the print setting of the current active document.

## Syntax (C#)
```csharp
public void Print(
	View viewTemplate
)
```

## Parameters
- **viewTemplate** (`Autodesk.Revit.DB.View`) - The view template which apply to the view.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the view cannot be printed.

