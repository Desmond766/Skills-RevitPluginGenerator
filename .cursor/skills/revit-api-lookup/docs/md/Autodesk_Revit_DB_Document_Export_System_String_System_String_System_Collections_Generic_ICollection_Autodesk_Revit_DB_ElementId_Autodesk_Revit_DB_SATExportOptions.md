---
kind: method
id: M:Autodesk.Revit.DB.Document.Export(System.String,System.String,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.SATExportOptions)
zh: 导出、输出
source: html/e5cd0800-8544-c2d1-d21a-19ae33e9168c.htm
---
# Autodesk.Revit.DB.Document.Export Method

**中文**: 导出、输出

Exports the current view or a selection of views in SAT format.

## Syntax (C#)
```csharp
public bool Export(
	string folder,
	string name,
	ICollection<ElementId> views,
	SATExportOptions options
)
```

## Parameters
- **folder** (`System.String`) - Output folder, into which file(s) will be exported. The folder must exist.
- **name** (`System.String`) - Either the name of a single file or a prefix for a set of files.
 If empty, automatic naming will be used.
- **views** (`System.Collections.Generic.ICollection < ElementId >`) - Selection of views to be exported. The set must contain at least one valid view.
- **options** (`Autodesk.Revit.DB.SATExportOptions`) - Various options applicable to the SAT format.For now, this option is empty.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.

## Returns
True if successful, otherwise False.

## Remarks
All the views must be 3D views for the Export to succeed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - NullOrEmpty
 -or-
 Contains invalid characters.
 -or-
 non empty list of views must be provided.
 -or-
 At least one provided viewId does not correspond to a printable 3D view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DirectoryNotFoundException** - Thrown when the directory does not exist.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - This method may not be called during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Export is temporarily disabled.
 -or-
 Exporting is not allowed in the current application mode.
- **Autodesk.Revit.Exceptions.InvalidPathArgumentException** - The folder does not exist.
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The ShapeExporter functionality is not available in the installed Revit, or the Material Library is missing.

