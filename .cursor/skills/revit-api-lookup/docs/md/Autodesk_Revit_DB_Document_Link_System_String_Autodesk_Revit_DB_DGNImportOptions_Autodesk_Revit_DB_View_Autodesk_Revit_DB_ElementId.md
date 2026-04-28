---
kind: method
id: M:Autodesk.Revit.DB.Document.Link(System.String,Autodesk.Revit.DB.DGNImportOptions,Autodesk.Revit.DB.View,Autodesk.Revit.DB.ElementId@)
zh: 链接模型、链接
source: html/a5c932ef-4e3b-bf83-c7df-e9cc827eeaeb.htm
---
# Autodesk.Revit.DB.Document.Link Method

**中文**: 链接模型、链接

Links a DGN file into the project document.

## Syntax (C#)
```csharp
public bool Link(
	string file,
	DGNImportOptions options,
	View pDBView,
	out ElementId elementId
)
```

## Parameters
- **file** (`System.String`) - Full path of the file to link. File must exist and must be a valid DGN file.
- **options** (`Autodesk.Revit.DB.DGNImportOptions`) - Various import options applicable to the DGN format. If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.
- **pDBView** (`Autodesk.Revit.DB.View`) - View used to aid placement of the linked file. If the options specify ThisViewOnly, this argument is required and the linked file
 will only be visible in the specified view. If the options specify center-to-center placement, this argument is required and the linked
 file will be placed in the center of the specified view. Otherwise, this view is used to obtain a base level to associate with the linked
 file. If not specified, an existing view will be chosen instead and may open a view or associate the linked file to an arbitrary level.
- **elementId** (`Autodesk.Revit.DB.ElementId %`) - The id of linked instance after a successful link.

## Returns
True if successful, otherwise False.

## Remarks
Link isn't supported for family documents. Please use import instead.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Not a valid file for DGN import (.dgn files are valid).
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
 -or-
 Empty DGN model view name characters.
 -or-
 Visible layer only option must be set to false for DGN import.
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
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The DGN Import/Link module is not available in the installed Revit.

