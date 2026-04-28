---
kind: method
id: M:Autodesk.Revit.DB.Document.Export(System.String,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.PDFExportOptions)
zh: 导出、输出
source: html/93d66d57-c20e-a103-39a1-77bc2ea05183.htm
---
# Autodesk.Revit.DB.Document.Export Method

**中文**: 导出、输出

Exports a selection of views in PDF format.

## Syntax (C#)
```csharp
public bool Export(
	string folder,
	IList<ElementId> viewIds,
	PDFExportOptions options
)
```

## Parameters
- **folder** (`System.String`) - Output folder, into which file(s) will be exported. The folder must exist.
- **viewIds** (`System.Collections.Generic.IList < ElementId >`) - Selection of ordered views to be exported.
 The list must contain at least one valid view.
- **options** (`Autodesk.Revit.DB.PDFExportOptions`) - Various options applicable to the PDF format.

## Returns
True if all specified views are exported successfully,
 False if exporting of any view fails, even if some views might have been exported successfully.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - non empty list of views must be provided.
 -or-
 NullOrEmpty
 -or-
 There are duplicate views in viewIds
 -or-
 some of the views are not printable (exportable).
 -or-
 Thrown when one or more input arguments are invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileAccessException** - Thrown when the target PDF file is inaccessible, e.g. already opened.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Export is temporarily disabled.
 -or-
 Exporting is not allowed in the current application mode.
- **Autodesk.Revit.Exceptions.InvalidPathArgumentException** - The folder does not exist.

