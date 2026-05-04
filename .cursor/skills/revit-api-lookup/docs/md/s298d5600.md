---
kind: method
id: M:Autodesk.Revit.DB.Document.Export(System.String,System.String,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.DWGExportOptions)
zh: 导出、输出
source: html/44ee91ff-c9f3-7df5-b8c0-81c17ac75dc7.htm
---
# Autodesk.Revit.DB.Document.Export Method

**中文**: 导出、输出

Exports a selection of views in DWG format.

## Syntax (C#)
```csharp
public bool Export(
	string folder,
	string name,
	ICollection<ElementId> views,
	DWGExportOptions options
)
```

## Parameters
- **folder** (`System.String`) - Output folder, into which file(s) will be exported. The folder must exist.
- **name** (`System.String`) - Either the name of a single file or a prefix for a set of files.
 If empty, automatic naming will be used.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) , throw ArgumentException.
- **views** (`System.Collections.Generic.ICollection < ElementId >`) - Selection of views to be exported. The set must contain at least one valid view.
- **options** (`Autodesk.Revit.DB.DWGExportOptions`) - Various options applicable to the DWG format.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.

## Returns
True if successful, otherwise False.

## Remarks
All the views must be printable for the Export to succeed.
 It can be assured by checking the CanBePrinted property of each view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - NullOrEmpty
 -or-
 Contains invalid characters.
 -or-
 non empty list of views must be provided.
 -or-
 some of the views are not printable (exportable).
 -or-
 The modifiers set in layer info must be valid.
 -or-
 Thrown when the options in DWGExportOptions is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.DirectoryNotFoundException** - Thrown when the directory does not exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Export is temporarily disabled.
 -or-
 Exporting is not allowed in the current application mode.
- **Autodesk.Revit.Exceptions.InvalidPathArgumentException** - The folder does not exist.
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The DWG module is not available in the installed Revit.
 -or-
 The Graphics module is not available in the installed Revit.

