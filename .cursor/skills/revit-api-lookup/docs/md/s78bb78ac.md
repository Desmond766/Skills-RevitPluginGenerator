---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.UpdateFromIFC(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalResourceReference,System.String,System.Boolean)
source: html/a3196dab-5524-da34-df34-d01034e98df1.htm
---
# Autodesk.Revit.DB.RevitLinkType.UpdateFromIFC Method

Updates a Revit link type from an IFC file and loads the linked document.

## Syntax (C#)
```csharp
public bool UpdateFromIFC(
	Document document,
	ExternalResourceReference resourceReference,
	string revitLinkedFilePath,
	bool recreateLink
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that contains Revit link.
- **resourceReference** (`Autodesk.Revit.DB.ExternalResourceReference`) - An external resource reference describing the source of the IFC file used in creation.
- **revitLinkedFilePath** (`System.String`) - The path of the Revit file to create to hold the IFC information. This must be a full path.
- **recreateLink** (`System.Boolean`) - If true, the Revit file will be updated based on the information in the IFC file. If false, the existing Revit file will be used.

## Returns
Returns true if the update succeeded, false otherwise.

## Remarks
This function regenerates the input document.
While the options argument allows specification of a path type, the
 input path argument must be a full path. Relative vs. absolute determines
 how Revit will store the path, but it needs a complete path to find
 the linked document initially.
 Note that the IFC file will not be stored directly in the document; it will
 instead by stored in an intermediate Revit document, whose location is given
 by revitLinkedFilePath.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a project document.
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

