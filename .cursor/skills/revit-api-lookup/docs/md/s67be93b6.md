---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.CreateFromIFC(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalResourceReference,System.String,System.Boolean,Autodesk.Revit.DB.RevitLinkOptions)
source: html/d31add6f-c574-2303-630c-95801988941d.htm
---
# Autodesk.Revit.DB.RevitLinkType.CreateFromIFC Method

Creates a new Revit link type from an existing Revit file created via import by reference
 of an asscoiated IFC file.

## Syntax (C#)
```csharp
public static LinkLoadResult CreateFromIFC(
	Document document,
	ExternalResourceReference resourceReference,
	string revitLinkedFilePath,
	bool recreateLink,
	RevitLinkOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document in which to create the Revit link.
- **resourceReference** (`Autodesk.Revit.DB.ExternalResourceReference`) - An external resource reference describing the source of the IFC file used in creation.
- **revitLinkedFilePath** (`System.String`) - The path of the existing Revit file that contains elements created via an import by reference operation.
 This must be a full path.
- **recreateLink** (`System.Boolean`) - If true, the existing Revit file created via an import by reference operation
 will be updated based on the information in the IFC file. If false, the existing Revit file will be used as-is.
- **options** (`Autodesk.Revit.DB.RevitLinkOptions`) - An options class for loading Revit links.

## Returns
An object containing the results of creating and loading
 the Revit link type. It contains the ElementId of the new link.

## Remarks
This function is one of a series of steps necessary for linking an IFC file.
 To understand how it is used in context, please download the IFC open source code,
 and look in the Revit.IFC.Import project at Importer.ImportIFC(ImporterIFC importer),
 under the IFCImportAction.Link branch. 
This function regenerates the input document.
While the options argument allows specification of a path type, the
 input path argument must be a full path. Relative vs. absolute determines
 how Revit will store the path, but it needs a complete path to find
 the linked document initially.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
 -or-
 document already contains a linked model at path revitLinkedFilePath.
 -or-
 The server referenced by the ExternalResourceReference does not exist or
 does not implement IExternalResourceServer.
 -or-
 The server referenced by the ExternalResourceReference cannot support IFC links.
 -or-
 The ExternalResourceReference (resourceReference) is not in a format
 that is supported by its server.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileAccessException** - The model cannot be accessed due to lack of access privileges.
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - There is not a valid Revit file at revitLinkedFilePath's location
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The file is not allowed to access.
 -or-
 Revit cannot customize worksets for this model.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

