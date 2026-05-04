---
kind: method
id: M:Autodesk.Revit.DB.Document.Import(System.String,Autodesk.Revit.DB.SKPImportOptions,Autodesk.Revit.DB.View)
zh: 导入
source: html/c7a6df28-b5af-de54-fb1e-8874296525b9.htm
---
# Autodesk.Revit.DB.Document.Import Method

**中文**: 导入

Imports a SKP file into the document.

## Syntax (C#)
```csharp
public ElementId Import(
	string file,
	SKPImportOptions options,
	View pDBView
)
```

## Parameters
- **file** (`System.String`) - Full path of the file to import. File must exist and must be a valid SKP file.
- **options** (`Autodesk.Revit.DB.SKPImportOptions`) - Various import options applicable to the SKP format. If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.
- **pDBView** (`Autodesk.Revit.DB.View`) - View used to aid placement of the imported file. If the options specify ThisViewOnly, this argument is required and the imported file
 will only be visible in the specified view. If the options specify center-to-center placement, this argument is required and the imported
 file will be placed in the center of the specified view. Otherwise, this view is used to obtain a base level to associate with the imported
 file. If not specified, an existing view will be chosen instead and may open a view or associate the imported file to an arbitrary level.

## Returns
Returns the element Id of the imported instance.

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
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The SKP Import/Link module is not available in the installed Revit.

