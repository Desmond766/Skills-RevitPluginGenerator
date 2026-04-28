---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalResourceReference,Autodesk.Revit.DB.RevitLinkOptions)
zh: 创建、新建、生成、建立、新增
source: html/79f5c5cd-1f93-9a7b-e8dc-51ad3ddb4c6a.htm
---
# Autodesk.Revit.DB.RevitLinkType.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new Revit link type from an external resource reference and loads the
 linked document.

## Syntax (C#)
```csharp
public static LinkLoadResult Create(
	Document document,
	ExternalResourceReference resourceReference,
	RevitLinkOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the Revit link.
- **resourceReference** (`Autodesk.Revit.DB.ExternalResourceReference`) - An external resource reference describing the source of the linked Revit document.
- **options** (`Autodesk.Revit.DB.RevitLinkOptions`) - An options class for loading Revit links. The path type information will be ignored.

## Returns
An object containing the results of creating and loading
 the Revit link type. It contains the ElementId of the new link.

## Remarks
This function regenerates the input document. Only the WorksetConfiguration information in the options argument
 will be used. The path type information will be ignored.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 The server referenced by the ExternalResourceReference does not exist or
 does not implement IExternalResourceServer.
 -or-
 The server referenced by the ExternalResourceReference cannot support Revit links.
 -or-
 The ExternalResourceReference (resourceReference) is not in a format
 that is supported by its server.
 -or-
 The link type referred to by the ExternalResourceReference "resourceReference" already exists
 in the document. You cannot create another copy of the link type. You can create
 instances with RevitLinkInstance.Create(), or reload the link using RevitLinkType.Reload().
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Revit cannot customize worksets for this model.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

