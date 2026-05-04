---
kind: method
id: M:Autodesk.Revit.DB.WorksetTable.DeleteWorkset(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.WorksetId,Autodesk.Revit.DB.DeleteWorksetSettings)
source: html/45c1d58c-f523-26ae-acc6-7ddc3c321d4a.htm
---
# Autodesk.Revit.DB.WorksetTable.DeleteWorkset Method

Delete the specific workset.

## Syntax (C#)
```csharp
public static void DeleteWorkset(
	Document document,
	WorksetId worksetId,
	DeleteWorksetSettings deleteWorksetSettings
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the worksets.
- **worksetId** (`Autodesk.Revit.DB.WorksetId`) - The id of the workset to delete.
- **deleteWorksetSettings** (`Autodesk.Revit.DB.DeleteWorksetSettings`) - The settings to delete a workset.

## Remarks
Please checkout the workset before executing this method.
 The method may fail in some situations that mentioned in CanDeleteWorkset(Document, WorksetId, DeleteWorksetSettings) .
 Another failure case is the Transaction failure due to "Deleting all open views in a project is not allowed."

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a workshared document.
 -or-
 document is not a primary document, it is a linked document.
 -or-
 document is read-only: It cannot be modified.
 -or-
 There is no workset in the document with this id.
 -or-
 Workset cannot be deleted.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.
- **Autodesk.Revit.Exceptions.RegenerationFailedException** - The document regeneration fails during the DeleteWorkset operation.

