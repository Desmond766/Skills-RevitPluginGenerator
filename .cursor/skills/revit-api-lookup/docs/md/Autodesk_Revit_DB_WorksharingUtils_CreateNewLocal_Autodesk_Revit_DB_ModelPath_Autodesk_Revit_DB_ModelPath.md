---
kind: method
id: M:Autodesk.Revit.DB.WorksharingUtils.CreateNewLocal(Autodesk.Revit.DB.ModelPath,Autodesk.Revit.DB.ModelPath)
source: html/90102c11-d982-77f5-d08c-e68b1a882281.htm
---
# Autodesk.Revit.DB.WorksharingUtils.CreateNewLocal Method

Takes a path to a central model and copies the model into a new local file for the current user.

## Syntax (C#)
```csharp
public static void CreateNewLocal(
	ModelPath sourcePath,
	ModelPath targetPath
)
```

## Parameters
- **sourcePath** (`Autodesk.Revit.DB.ModelPath`) - The path to the central model.
- **targetPath** (`Autodesk.Revit.DB.ModelPath`) - The path to put the new local file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given path sourcePath is a cloud path which is not supported in this method.
 -or-
 The model is not workshared.
 -or-
 The central model has not fully enabled worksharing.
 It must be opened and resaved to finish enabling worksharing.
 -or-
 The model is a local file.
 -or-
 The central model is not saved in the current Revit version.
 -or-
 The model is transmitted.
 -or-
-or-
 The specified filepath is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the central model was denied due to lack of access privileges.
 -or-
 Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - The central model is locked by another user.
 -or-
 The central model is being accessed by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - The central model is missing.
 -or-
 An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.FileArgumentAlreadyExistsException** - The file or folder already exists and cannot be overwritten.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This functionality is not available in Revit LT.
 -or-
 File already exists!
 -or-
 Revit Server does not support local models.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - An internal error happened on the server, please contact the server administrator.

