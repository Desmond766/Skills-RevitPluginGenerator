---
kind: method
id: M:Autodesk.Revit.DB.Document.Print(Autodesk.Revit.DB.ViewSet,Autodesk.Revit.DB.View)
zh: 文档、文件
source: html/3db1fadb-0349-f0cd-c3cc-c9aa90454880.htm
---
# Autodesk.Revit.DB.Document.Print Method

**中文**: 文档、文件

Prints a set of views with a specified view template and default print settings.

## Syntax (C#)
```csharp
public void Print(
	ViewSet views,
	View viewTemplate
)
```

## Parameters
- **views** (`Autodesk.Revit.DB.ViewSet`) - The set of views which need to be printed.
- **viewTemplate** (`Autodesk.Revit.DB.View`) - The view template which apply to the set of views.

## Remarks
If one view in the set can not be printed successfully then an exception will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when printing is not allowed in the current application mode.
Or when at least one view from the view set is not a printable view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the view set to be printed is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the view set contains a Nothing nullptr a null reference ( Nothing in Visual Basic) element.
- **Autodesk.Revit.Exceptions.ApplicationException** - Thrown when at least one view from the view set could not be printed.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Thrown when print is cancelled by event handler.

