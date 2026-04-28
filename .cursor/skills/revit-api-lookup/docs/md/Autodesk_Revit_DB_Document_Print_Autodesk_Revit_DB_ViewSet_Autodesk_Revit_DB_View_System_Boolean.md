---
kind: method
id: M:Autodesk.Revit.DB.Document.Print(Autodesk.Revit.DB.ViewSet,Autodesk.Revit.DB.View,System.Boolean)
zh: 文档、文件
source: html/fb631da2-2261-4683-a957-5b63ac985d62.htm
---
# Autodesk.Revit.DB.Document.Print Method

**中文**: 文档、文件

Prints a set of views with a specified view template and default print settings.

## Syntax (C#)
```csharp
public void Print(
	ViewSet views,
	View viewTemplate,
	bool useCurrentPrintSettings
)
```

## Parameters
- **views** (`Autodesk.Revit.DB.ViewSet`) - The set of views which need to be printed.
- **viewTemplate** (`Autodesk.Revit.DB.View`) - The view template which apply to the set of views.
- **useCurrentPrintSettings** (`System.Boolean`) - If true, print the view with the current print setting,
otherwise with the print setting of the document of the view.

## Remarks
If one view in the set can not be printed successfully then an exception will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when printing is not allowed in the current application mode.
Or when at least one view from the view set is not a printable view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the view set to be printed is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the view set contains a Nothing nullptr a null reference ( Nothing in Visual Basic) element.
- **Autodesk.Revit.Exceptions.ApplicationException** - Thrown when at least one view from the view set could not be printed.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when print is cancelled by event handler.

