---
kind: method
id: M:Autodesk.Revit.DB.Document.ExportImage(Autodesk.Revit.DB.ImageExportOptions)
zh: 文档、文件
source: html/b98a3e71-39fa-bf7a-cb3d-591d8b1fcd93.htm
---
# Autodesk.Revit.DB.Document.ExportImage Method

**中文**: 文档、文件

Exports a view or set of views into an image file.

## Syntax (C#)
```csharp
public void ExportImage(
	ImageExportOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.ImageExportOptions`) - The options which govern the image export.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The current view cannot be exported as an image
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileAccessException** - The path indicated could not be accessed.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - The path indicated could not be found.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Exporting is not allowed in the current application mode.
 -or-
 Failed to export image due to an error with the inputs.
 -or-
 Failed to export image due to an issue where the DirectX Device was lost.
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The Graphics module is not available in the installed Revit.

