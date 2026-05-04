---
kind: method
id: M:Autodesk.Revit.DB.Document.HasAllChangesFromCentral
zh: 文档、文件
source: html/67bb59c4-77cf-7cb4-d289-489ba85e09b2.htm
---
# Autodesk.Revit.DB.Document.HasAllChangesFromCentral Method

**中文**: 文档、文件

Returns whether the model in the current session is up to date with central.

## Syntax (C#)
```csharp
public bool HasAllChangesFromCentral()
```

## Returns
True means up to date; false means out of date.
 If central is locked but Revit can determine that
 the model in the current session is out of date
 without opening central, this method will return false
 instead of throwing CentralModelContentionException.

## Exceptions
- **Autodesk.Revit.Exceptions.CentralFileCommunicationException** - The file-based central model could not be reached, because e.g. the network is down or the file server is down.
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the central model was denied due to lack of access privileges.
 -or-
 Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - The central model is locked by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - Username does not match the one used to create the local file.
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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Document is not a workshared document.
 -or-
 This Document is a local file that is not owned by the current user, who therefore is not allowed to modify it.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - An internal error happened on the server, please contact the server administrator.
- **Autodesk.Revit.Exceptions.RevitServerUnauthenticatedUserException** - User is not signed in with Autodesk id.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - User is not authorized to access the specified A360 project.

