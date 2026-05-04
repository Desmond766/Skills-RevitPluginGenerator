---
kind: method
id: M:Autodesk.Revit.DB.Document.Link(System.String,Autodesk.Revit.DB.SKPImportOptions,Autodesk.Revit.DB.View)
zh: 链接模型、链接
source: html/cc612dab-6830-d114-4213-d52acc5bd377.htm
---
# Autodesk.Revit.DB.Document.Link Method

**中文**: 链接模型、链接

Links a SKP file into the project document.

## Syntax (C#)
```csharp
public ElementId Link(
	string file,
	SKPImportOptions options,
	View pDBView
)
```

## Parameters
- **file** (`System.String`) - Full path of the file to link. File must exist and must be a valid SKP file.
- **options** (`Autodesk.Revit.DB.SKPImportOptions`) - Various import options applicable to the SKP format. If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.
- **pDBView** (`Autodesk.Revit.DB.View`) - View used to aid placement of the linked file. If the options specify ThisViewOnly, this argument is required and the linked file
 will only be visible in the specified view. If the options specify center-to-center placement, this argument is required and the linked
 file will be placed in the center of the specified view. Otherwise, this view is used to obtain a base level to associate with the linked
 file. If not specified, an existing view will be chosen instead and may open a view or associate the linked file to an arbitrary level.

## Returns
Returns the element Id of the linked instance.

## Remarks
Link isn't supported for family documents. Please use import instead.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Not a valid file for SKP import (.skp files are valid).
 -or-
 ThisViewOnly cannot be true when importing a DWG|DGN drawing into a 3D view.
 -or-
 The provided view is not valid for the options provided.
 -or-
 One or more strings describing layer selection is invalid or empty.
 -or-
 The scale is not valid as a CustomScale for use during import.
 -or-
 NullOrEmpty
 -or-
 The view is not printable.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The given file does not exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Import is temporarily disabled.
 -or-
 This Document is not a project document.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The SKP Import/Link module is not available in the installed Revit.

