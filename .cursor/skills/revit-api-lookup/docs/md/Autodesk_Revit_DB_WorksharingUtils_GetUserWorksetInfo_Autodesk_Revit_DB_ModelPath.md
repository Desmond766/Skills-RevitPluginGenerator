---
kind: method
id: M:Autodesk.Revit.DB.WorksharingUtils.GetUserWorksetInfo(Autodesk.Revit.DB.ModelPath)
source: html/15ec1e3e-61d5-b6a1-3604-8b866a988270.htm
---
# Autodesk.Revit.DB.WorksharingUtils.GetUserWorksetInfo Method

Gets information about user worksets in a workshared model file, without fully opening the file.

## Syntax (C#)
```csharp
public static IList<WorksetPreview> GetUserWorksetInfo(
	ModelPath path
)
```

## Parameters
- **path** (`Autodesk.Revit.DB.ModelPath`) - The path to the workshared model.

## Returns
Information about all the user worksets in the model.
 The list is sorted by workset id.

## Remarks
This method provides a preview of the user worksets available in a file, allowing an
 application to look up the necessary workset ids and information to properly fill out a WorksetConfiguration
 structure before opening or linking to this model.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the central model was denied due to lack of access privileges.
 -or-
 Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - The central model are locked by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - The central model is missing.
 -or-
 The central model is corrupt or not an RVT file.
 -or-
 The model is not workshared.
 -or-
 The central model is overwritten by other user.
 -or-
 An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.FileAccessException** - The model could not be accessed due to lack of access privileges.
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The Revit model specified by path doesn't exist.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - The model could not be found at the specified path.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This functionality is not available in Revit LT.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - An internal error happened on the server, please contact the server administrator.

