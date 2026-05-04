---
kind: method
id: M:Autodesk.Revit.DB.WorksharingUtils.CheckoutWorksets(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.WorksetId},Autodesk.Revit.DB.TransactWithCentralOptions)
source: html/39b55560-c85b-bebc-e825-b76b5ba313a7.htm
---
# Autodesk.Revit.DB.WorksharingUtils.CheckoutWorksets Method

Obtains ownership for the current user of as many specified worksets as possible.

## Syntax (C#)
```csharp
public static ISet<WorksetId> CheckoutWorksets(
	Document document,
	ISet<WorksetId> worksetsToCheckout,
	TransactWithCentralOptions options
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the worksets.
- **worksetsToCheckout** (`System.Collections.Generic.ISet < WorksetId >`) - The ids of the worksets to attempt to check out.
- **options** (`Autodesk.Revit.DB.TransactWithCentralOptions`) - Options to customize access to the central model.
 Nothing nullptr a null reference ( Nothing in Visual Basic) is allowed and means no customization.

## Returns
The ids of all specified worksets that are now owned,
 including all that were owned prior to the function call.

## Remarks
For best performance, check out all worksets in one big call, rather than many small calls.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - document is not a workshared document.
 -or-
 document is not a primary document, it is a linked document.
 -or-
 document is read-only: It cannot be modified.
 -or-
 document has an open editing transaction and is accepting changes.
 -or-
 There are one or more ids with no corresponding workset.
 -or-
 Saving is not allowed in the current application mode.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralFileCommunicationException** - The file-based central model could not be reached,
 e.g. the network is down or the file server is down.
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the central model was denied due to lack of access privileges.
 -or-
 Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - The central model are locked by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - The central model is overwritten by other user.
 -or-
 The central model is missing.
 -or-
 An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.CentralModelVersionArchivedException** - Last central version merged into the local model has been archived in the central model.
 This exception could only be thrown from cloud models.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Operation is not permitted when there is any open sub-transaction, transaction, or transaction group.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - An internal error happened on the server, please contact the server administrator.

