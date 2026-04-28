---
kind: method
id: M:Autodesk.Revit.DB.WorksharingUtils.RelinquishOwnership(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.RelinquishOptions,Autodesk.Revit.DB.TransactWithCentralOptions)
source: html/09f4e163-cb8f-de87-d641-3ba667adf4e0.htm
---
# Autodesk.Revit.DB.WorksharingUtils.RelinquishOwnership Method

Relinquishes ownership by the current user of as many specified elements and worksets as possible,
 and grants element ownership requested by other users on a first-come, first-served basis.

## Syntax (C#)
```csharp
public static RelinquishedItems RelinquishOwnership(
	Document document,
	RelinquishOptions generalCategories,
	TransactWithCentralOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the elements and worksets.
- **generalCategories** (`Autodesk.Revit.DB.RelinquishOptions`) - General categories of items to relinquish. See RelinquishOptions for details.
- **options** (`Autodesk.Revit.DB.TransactWithCentralOptions`) - Options to customize access to the central model.
 Nothing nullptr a null reference ( Nothing in Visual Basic) is allowed and means no customization.

## Returns
The elements and worksets that were relinquished.

## Remarks
Elements and worksets owned by other users are ignored. Only unmodified elements already in central will be relinquished by this method.
 Newly added and modified elements cannot be relinquished
 until they have been synchronized with central. For best performance, relinquish items in one big call, rather than many small calls.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a workshared document.
 -or-
 document is not a primary document, it is a linked document.
 -or-
 document is read-only: It cannot be modified.
 -or-
 document has an open editing transaction and is accepting changes.
 -or-
 Saving is not allowed in the current application mode.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralFileCommunicationException** - The file-based central model could not be reached,
 e.g. the network is down or the file server is down.
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the central model was denied due to lack of access privileges.
 -or-
 Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - The central model is locked by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - The central model is overwritten by other user.
 -or-
 The central model is missing.
 -or-
 An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Operation is not permitted when there is any open sub-transaction, transaction, or transaction group.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - An internal error happened on the server, please contact the server administrator.

