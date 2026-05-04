---
kind: method
id: M:Autodesk.Revit.DB.ImportInstance.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,Autodesk.Revit.DB.ExternalResourceReference,Autodesk.Revit.DB.STLImportOptions,Autodesk.Revit.DB.LinkLoadResult@)
zh: 创建、新建、生成、建立、新增
source: html/f80fa638-1c8d-a296-c3bd-a605e426c96e.htm
---
# Autodesk.Revit.DB.ImportInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of STL link type from an external resource reference
 and loads the linked file.

## Syntax (C#)
```csharp
public static ImportInstance Create(
	Document document,
	View DBView,
	ExternalResourceReference resourceReference,
	STLImportOptions options,
	out LinkLoadResult linkLoadResult
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the STL link.
- **DBView** (`Autodesk.Revit.DB.View`) - The view into which the STL link will be created.
- **resourceReference** (`Autodesk.Revit.DB.ExternalResourceReference`) - The external resource reference describing the source of the STL link.
- **options** (`Autodesk.Revit.DB.STLImportOptions`) - Various import options applicable to the STL format.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.
- **linkLoadResult** (`Autodesk.Revit.DB.LinkLoadResult %`) - An object containing the results of creating and loading
 the STL link. It contains the ElementId of the new created STL link type.

## Returns
The new instance of STL link type created.

## Remarks
This function creates a new STL link type as well as a new instance of this STL link type.
 The new instance of STL link type is returned by this function and the element id of the new STL link type
 is contained in the LinkLoadResult. If the given external resource reference of the STL link is already used by an existing STL link type,
 a new instance of this existing STL link type is created and returned. The element id of the existing
 STL link type is contained in the LinkLoadResult. This function regenerates the input document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 document is in an edit mode.
 -or-
 Import is temporarily disabled.
 -or-
 The view is not printable.
 -or-
 ThisViewOnly cannot be true when importing a DWG|DGN drawing into a 3D view.
 -or-
 One or more strings describing layer selection is invalid or empty.
 -or-
 The scale is not valid as a CustomScale for use during import.
 -or-
 The server referenced by the ExternalResourceReference does not exist or
 does not implement IExternalResourceServer.
 -or-
 The server referenced by the ExternalResourceReference cannot support CAD links.
 -or-
 The ExternalResourceReference (resourceReference) is not in a format
 that is supported by its server.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The STL Import/Link module is not available in the installed Revit.

