---
kind: method
id: M:Autodesk.Revit.DB.ImportInstance.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.View,Autodesk.Revit.DB.ExternalResourceReference,Autodesk.Revit.DB.ImportOptions3DM,Autodesk.Revit.DB.LinkLoadResult@)
zh: 创建、新建、生成、建立、新增
source: html/9f865136-661b-fa8f-0075-5dc009c49a72.htm
---
# Autodesk.Revit.DB.ImportInstance.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of 3DM link type from an external resource reference
 and loads the linked file.

## Syntax (C#)
```csharp
public static ImportInstance Create(
	Document document,
	View DBView,
	ExternalResourceReference resourceReference,
	ImportOptions3DM options,
	out LinkLoadResult linkLoadResult
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the 3DM link.
- **DBView** (`Autodesk.Revit.DB.View`) - The view into which the 3DM link will be created.
- **resourceReference** (`Autodesk.Revit.DB.ExternalResourceReference`) - The external resource reference describing the source of the 3DM link.
- **options** (`Autodesk.Revit.DB.ImportOptions3DM`) - Various import options applicable to the 3DM format.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.
- **linkLoadResult** (`Autodesk.Revit.DB.LinkLoadResult %`) - An object containing the results of creating and loading
 the 3DM link. It contains the ElementId of the new created 3DM link type.

## Returns
The new instance of 3DM link type created.

## Remarks
This function creates a new 3DM link type as well as a new instance of this 3DM link type.
 The new instance of 3DM link type is returned by this function and the element id of the new 3DM link type
 is contained in the LinkLoadResult. If the given external resource reference of the 3DM link is already used by an existing 3DM link type,
 a new instance of this existing 3DM link type is created and returned. The element id of the existing
 3DM link type is contained in the LinkLoadResult. This function regenerates the input document.

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
- **Autodesk.Revit.Exceptions.OptionalFunctionalityNotAvailableException** - The 3DM Import/Link module is not available in the installed Revit.

