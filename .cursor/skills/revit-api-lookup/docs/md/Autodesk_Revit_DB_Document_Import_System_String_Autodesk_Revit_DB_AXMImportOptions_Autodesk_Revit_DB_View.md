---
kind: method
id: M:Autodesk.Revit.DB.Document.Import(System.String,Autodesk.Revit.DB.AXMImportOptions,Autodesk.Revit.DB.View)
zh: 导入
source: html/14f9266e-e989-3654-e32a-b4e412846698.htm
---
# Autodesk.Revit.DB.Document.Import Method

**中文**: 导入

Imports an AXM file into the document.

## Syntax (C#)
```csharp
public ElementId Import(
	string file,
	AXMImportOptions options,
	View pDBView
)
```

## Parameters
- **file** (`System.String`) - Full path of the file to import. File must exist and must be a valid AXM file.
- **options** (`Autodesk.Revit.DB.AXMImportOptions`) - Various import options applicable to the AXM format. If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.
 Import FormIt support Preserve color mode, center-to-center and origin-to-origin placement, other options are not supported.
 Import FormIt does not support orient to view and this view only option.
- **pDBView** (`Autodesk.Revit.DB.View`) - View used to aid placement of the imported file. If the options specify center-to-center placement, this argument is required and the imported
 file will be placed in the center of the specified view. Otherwise, this view is used to obtain a base level to associate with the imported
 file. If not specified, an existing view will be chosen instead and may open a view or associate the imported file to an arbitrary level.

## Returns
Returns the element Id of the imported instance.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Not a valid file for AXM import (.axm files are valid).
 -or-
 The provided view is not valid for the options provided.
 -or-
 Visible layer only option is not false or layers are specified in SetLayerSelection.
 -or-
 Import levels is only supported in project document or conceptual mass document for AXM import.
 -or-
 Not all AXM import option settings are valid. For more details, please refer to AXMImportOptions.
 -or-
 The scale is not valid as a CustomScale for use during import.
 -or-
 NullOrEmpty
 -or-
 The view is not printable.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The given file does not exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Import is temporarily disabled.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The AXM Import/Link module is not available in the installed Revit.

