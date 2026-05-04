---
kind: method
id: M:Autodesk.Revit.DB.Document.SaveCloudModel
zh: 文档、文件
source: html/394bbf2c-5161-49de-773e-c019d558eb9f.htm
---
# Autodesk.Revit.DB.Document.SaveCloudModel Method

**中文**: 文档、文件

Saves cloud model.

## Syntax (C#)
```csharp
public void SaveCloudModel()
```

## Exceptions
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Could be for any of the reasons that related to access to the cloud model.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - The central model is locked by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - Could be for any of the reasons that fails with CentralModelException, for example, a central model with that name
 is already associated to the specified cloud project.
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
 The file is read-only, can not be saved.
 -or-
 This Document is a not cloud model, cannot execute this operation.
 -or-
 This Document is a workshared document.
 -or-
 Operation is not permitted when there is any open sub-transaction, transaction, or transaction group.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Synchronize With Central was canceled by the user or by an API event callback.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - Could be for any of the reasons related to network.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - Could be for any of the reasons that save fails with RevitServerInternalException.
- **Autodesk.Revit.Exceptions.RevitServerUnauthenticatedUserException** - User is not signed in with Autodesk id.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - User is not authorized to access the specified cloud project.

