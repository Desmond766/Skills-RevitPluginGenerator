---
kind: method
id: M:Autodesk.Revit.DB.Document.Export(System.String,System.String,Autodesk.Revit.DB.OBJExportOptions)
zh: 导出、输出
source: html/203a88aa-d6e1-d96d-7ee0-f67356aae796.htm
---
# Autodesk.Revit.DB.Document.Export Method

**中文**: 导出、输出

Exports a view specified in the export options to the OBJ format.

## Syntax (C#)
```csharp
public bool Export(
	string folder,
	string name,
	OBJExportOptions options
)
```

## Parameters
- **folder** (`System.String`) - Output folder into which the file will be exported. The folder must exist.
- **name** (`System.String`) - Indicates the name of the OBJ file to export. If it doesn't end with ".obj", this extension will be added automatically.
 The name cannot contain any of the following characters: \/:*?"<>|. Empty name is not acceptable.
- **options** (`Autodesk.Revit.DB.OBJExportOptions`) - Various options applicable to the OBJ format.

## Returns
True if successful, otherwise False.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - NullOrEmpty
 -or-
 Contains invalid characters.
 -or-
 The provided options do not specify a printable 3D view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - This method may not be called during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Export is temporarily disabled.
 -or-
 Exporting is not allowed in the current application mode.
- **Autodesk.Revit.Exceptions.InvalidPathArgumentException** - The folder does not exist.
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The ShapeExporter functionality is not available in the installed Revit, or the Material Library is missing.

