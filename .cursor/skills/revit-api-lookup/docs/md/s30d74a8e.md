---
kind: method
id: M:Autodesk.Revit.DB.RevitLinkType.UpdateFromIFC(Autodesk.Revit.DB.Document,System.String,System.String,System.Boolean)
source: html/c13bd6d6-8292-7fa0-0e78-c81dc1b3ecc3.htm
---
# Autodesk.Revit.DB.RevitLinkType.UpdateFromIFC Method

Updates a Revit link type from an IFC file and loads the linked document.

## Syntax (C#)
```csharp
public bool UpdateFromIFC(
	Document document,
	string ifcFilePath,
	string revitLinkedFilePath,
	bool recreateLink
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that contains Revit link.
- **ifcFilePath** (`System.String`) - The path of the IFC link to load. This must be a full path.
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
 The input path "ifcFilePath" does not represent an IFC file.
 -or-
 The document is a cloud model.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.FileAccessException** - The model cannot be accessed due to lack of access privileges.
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - There is not a valid Revit file at ifcFilePath's location
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

