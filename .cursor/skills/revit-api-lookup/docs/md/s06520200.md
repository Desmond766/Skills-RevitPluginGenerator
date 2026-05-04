---
kind: method
id: M:Autodesk.Revit.DB.Document.SynchronizeWithCentral(Autodesk.Revit.DB.TransactWithCentralOptions,Autodesk.Revit.DB.SynchronizeWithCentralOptions)
zh: 文档、文件
source: html/7de73a7b-68f0-87f2-f6a9-97d824024877.htm
---
# Autodesk.Revit.DB.Document.SynchronizeWithCentral Method

**中文**: 文档、文件

Performs reload latest until the model in the current session is up to date and then saves changes back to central.
 A save to central is performed even if no changes were made.

## Syntax (C#)
```csharp
public void SynchronizeWithCentral(
	TransactWithCentralOptions transactOptions,
	SynchronizeWithCentralOptions syncOptions
)
```

## Parameters
- **transactOptions** (`Autodesk.Revit.DB.TransactWithCentralOptions`) - Options to customize behavior accessing the central model.
- **syncOptions** (`Autodesk.Revit.DB.SynchronizeWithCentralOptions`) - Options to customize behavior of SynchronizeWithCentral.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralFileCommunicationException** - The file-based central model could not be reached, because e.g. the network is down or the file server is down.
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the central model was denied due to lack of access privileges.
 -or-
 Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - The central model is locked by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - Username does not match the one used to create the local file.
 -or-
 Revit could not save all of the worksets that have been changed. Try again.
 -or-
 Some of the elements you changed in this model are now editable by someone else, or you checked out worksets that were at risk
 or relinquished in the central model but not this file. You cannot synchronize with the central model until the other user
 relinquishes these elements without making changes.
 -or-
 The central model has been replaced by a local model.
 -or-
 Local incompatible because it was closed without saving after synchronizing with central.
 -or-
 The central model is missing.
 -or-
 The central model is incompatible.
 -or-
 The central model is corrupt or not an RVT file.
 -or-
 The central model was rolled back.
 -or-
 The central model's elements have been relinquished
 -or-
 Your data or permissions saving is aborted by another user.
 -or-
 The central model is overritten by other user.
 -or-
 An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - Cannot access the local file.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Document is not a primary document, it is a linked document.
 -or-
 This Document is read-only: It cannot be modified.
 -or-
 This Document has an open editing transaction and is accepting changes.
 -or-
 This Document is not a project document.
 -or-
 This Document is in an edit mode.
 -or-
 Saving is not allowed in the current application mode.
 -or-
 This Document does not have a central location: Worksharing needs to be enabled and central model saved.
 -or-
 This Document is a local file that is not owned by the current user, who therefore is not allowed to modify it.
 -or-
 The local file is read-only.
 It can not be saved before or after synchronizing with central.
 -or-
 This Document is not a workshared document.
 -or-
 Saving local before first reload latest and after saving changes to central
 in Synchronize with Central is mandatory for server-based local models.
 -or-
 Operation is not permitted when there is any open sub-transaction, transaction, or transaction group.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Synchronize With Central was canceled by the user or by an API event callback.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be reached
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - The disk space is running low on server, please contact the server administrator.
 -or-
 An internal error happened on the server, please contact the server administrator.
- **Autodesk.Revit.Exceptions.RevitServerUnauthenticatedUserException** - User is not signed in with Autodesk id.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - User is not authorized to access the specified A360 project.

