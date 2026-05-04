---
kind: method
id: M:Autodesk.Revit.DB.Document.ReloadLatest(Autodesk.Revit.DB.ReloadLatestOptions)
zh: 文档、文件
source: html/f60968b0-faa6-92f9-5e73-a201fe87a1ad.htm
---
# Autodesk.Revit.DB.Document.ReloadLatest Method

**中文**: 文档、文件

Fetches changes from central (due to one or more synchronizations with central)
 and merges them into the current session.

## Syntax (C#)
```csharp
public void ReloadLatest(
	ReloadLatestOptions reloadOptions
)
```

## Parameters
- **reloadOptions** (`Autodesk.Revit.DB.ReloadLatestOptions`) - Various options to control behavior of reloadLatest.

## Remarks
After this call finishes, use hasAllChangesFromCentral to confirm that there were no
 Synchronizations with Central performed during execution of ReloadLatest.

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
 The central model is overritten by other user.
 -or-
 An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - Cannot access the local file.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Document is not a primary document, it is a linked document.
 -or-
 This Document is not a local model: it is not workshared or is central.
 -or-
 This Document is read-only: It cannot be modified.
 -or-
 This Document has an open editing transaction and is accepting changes.
 -or-
 This Document is not a project document.
 -or-
 This Document is in an edit mode.
 -or-
 This Document is a local file that is not owned by the current user, who therefore is not allowed to modify it.
 -or-
 Operation is not permitted when there is any open sub-transaction, transaction, or transaction group.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Reload Latest was canceled by the user or by an API event callback.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - An internal error happened on the server, please contact the server administrator.
- **Autodesk.Revit.Exceptions.RevitServerUnauthenticatedUserException** - User is not signed in with Autodesk id.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - User is not authorized to access the specified A360 project.

