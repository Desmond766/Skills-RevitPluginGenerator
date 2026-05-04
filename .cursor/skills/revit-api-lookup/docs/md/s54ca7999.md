---
kind: method
id: M:Autodesk.Revit.DB.Document.Print(Autodesk.Revit.DB.ViewSet,System.Boolean)
zh: 文档、文件
source: html/6030120a-4523-3d02-5e38-6ed684c174cb.htm
---
# Autodesk.Revit.DB.Document.Print Method

**中文**: 文档、文件

Prints a set of views with default view template and default print settings.

## Syntax (C#)
```csharp
public void Print(
	ViewSet views,
	bool useCurrentPrintSettings
)
```

## Parameters
- **views** (`Autodesk.Revit.DB.ViewSet`) - The set of views which need to be printed.
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

