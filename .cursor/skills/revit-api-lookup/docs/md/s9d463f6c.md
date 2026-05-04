---
kind: method
id: M:Autodesk.Revit.DB.Document.EnableCloudWorksharing
zh: 文档、文件
source: html/4146e816-565e-85d8-ce94-93ec505a0924.htm
---
# Autodesk.Revit.DB.Document.EnableCloudWorksharing Method

**中文**: 文档、文件

Enables cloud worksharing for a cloud model

## Syntax (C#)
```csharp
public void EnableCloudWorksharing()
```

## Remarks
This operation will convert an existing cloud model to a workshared cloud model.
 This method cannot be used if current model is not a cloud model.
 This method cannot be used if the current user doesn't have the workshared cloud model entitlement.

## Exceptions
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the cloud model was denied due to lack of access privileges.
 -or-
 Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - The central model is locked by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - The model in cloud is missing.
 -or-
 The model in cloud is incompatible.
 -or-
 The model in cloud is corrupt or not an RVT file.
 -or-
 The model in cloud was rolled back.
 -or-
 An internal error happened on the model in cloud , please contact the administrator.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - Cannot access the local cache.
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
 The cloud model does not allow cloud worksharing to be enabled.
 -or-
 Operation is not permitted when there is any open sub-transaction, transaction, or transaction group.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - Could be for any of the reasons related to network.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - Could be for any of the reasons that conversion fails with RevitServerInternalException.
- **Autodesk.Revit.Exceptions.RevitServerUnauthenticatedUserException** - User is not signed in with Autodesk id.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - You do not have workshared cloud model entitlement to access this resource in cloud
 -or-
 User is not authorized to access the specified cloud project.

