---
kind: method
id: M:Autodesk.Revit.DB.ImportInstance.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,System.String,Autodesk.Revit.DB.DWGImportOptions,Autodesk.Revit.DB.LinkLoadResult@)
zh: 创建、新建、生成、建立、新增
source: html/e0fa547e-65ad-7c72-30c0-2592d181811e.htm
---
# Autodesk.Revit.DB.ImportInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of DWG or DXF link type from a file path and loads the linked file.

## Syntax (C#)
```csharp
public static ImportInstance Create(
	Document document,
	View DBView,
	string path,
	DWGImportOptions options,
	out LinkLoadResult linkLoadResult
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the DWG or DXF link.
- **DBView** (`Autodesk.Revit.DB.View`) - The view into which the DWG or DXF link will be created.
- **path** (`System.String`) - The full path of the DWG or DXF file to link. The path must exist and must be a valid DWG or DXF file.
- **options** (`Autodesk.Revit.DB.DWGImportOptions`) - Various import options applicable to the DWG format.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.
- **linkLoadResult** (`Autodesk.Revit.DB.LinkLoadResult %`) - An object containing the results of creating and loading
 the DWG or DXF link. It contains the ElementId of the new created DWG or DXF link type.

## Returns
The new instance of DWG or DXF link type.

## Remarks
This function creates a new DWG or DXF link type as well as a new instance of this link type.
 The new instance of DWG or DXF link type is returned by this function and the element id of the new DWG
 or DXF link type is contained in the LinkLoadResult. If the given full path of the DWG or DXF file to link is already used by an existing DWG or DXF link type,
 a new instance of this existing DWG or DXF link type will be created and returned. The element id of the existing
 DWG or DXF link type is contained in the LinkLoadResult. This function regenerates the input document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 document is in an edit mode.
 -or-
 Import is temporarily disabled.
 -or-
 The view is not printable.
 -or-
 NullOrEmpty
 -or-
 Not a valid file for DWG import (.dwg and .dxf files are valid).
 -or-
 ThisViewOnly cannot be true when importing a DWG|DGN drawing into a 3D view.
 -or-
 One or more strings describing layer selection is invalid or empty.
 -or-
 The line weights are not valid; either it contains an invalid number of line weights, or a line weight outside the valid range.
 -or-
 The scale is not valid as a CustomScale for use during import.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The given path does not exist.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Place by shared, and the host model and the link do not share the same coordinate system.
 Or place by shared, and the shared coordinates of the host model do not match the GIS coordinate system of the link.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The DWG Import/Link module is not available in the installed Revit.

