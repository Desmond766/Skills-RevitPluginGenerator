---
kind: method
id: M:Autodesk.Revit.DB.Document.SaveToProjectAsImage(Autodesk.Revit.DB.ImageExportOptions)
zh: 文档、文件
source: html/0bc4b117-ffd3-616f-d378-bfcbb1fdae2f.htm
---
# Autodesk.Revit.DB.Document.SaveToProjectAsImage Method

**中文**: 文档、文件

Creates an image view from the currently active view.

## Syntax (C#)
```csharp
public ElementId SaveToProjectAsImage(
	ImageExportOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.ImageExportOptions`) - The options which govern the image creation.

## Returns
Id of the newly created view if the operation succeeded, invalid element id otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - options object is invalid: the ExportRange is invalid, must be CurrentView or VisibleRegionOfCurrentView, or the ViewName is invalid, must be non-empty, unique and should not contain prohibited characters.
 -or-
 The current view cannot be exported as an image
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

