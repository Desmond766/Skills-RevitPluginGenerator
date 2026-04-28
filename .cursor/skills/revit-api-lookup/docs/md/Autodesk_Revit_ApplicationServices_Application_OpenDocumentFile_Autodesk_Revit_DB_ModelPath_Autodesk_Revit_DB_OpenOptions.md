---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.OpenDocumentFile(Autodesk.Revit.DB.ModelPath,Autodesk.Revit.DB.OpenOptions)
source: html/5716f206-98ee-0490-4c6c-f0cdd6644190.htm
---
# Autodesk.Revit.ApplicationServices.Application.OpenDocumentFile Method

Opens a document from disk or cloud.

## Syntax (C#)
```csharp
public Document OpenDocumentFile(
	ModelPath modelPath,
	OpenOptions openOptions
)
```

## Parameters
- **modelPath** (`Autodesk.Revit.DB.ModelPath`) - The file to be opened.
- **openOptions** (`Autodesk.Revit.DB.OpenOptions`) - Options for opening the file.

## Returns
The opened document.

## Remarks
This method opens the document into memory but does not make it visible to the user in any way.
 If the user currently has ownership of elements in this model and there is no local model on this machine,
 Revit will post a warning.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The modelPath to be opened is empty.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CannotOpenBothCentralAndLocalException** - Cannot open the local model and the central model in the same Revit session. You can close one to open the other in the same Revit session.
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - The model on the RevitServer is being accessed by other users.
 -or-
 The central model is locked by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - Revit encountered serious errors while trying to open the central model.
 -or-
 An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.CorruptModelException** - There are too many corrupt elements to open this model.
- **Autodesk.Revit.Exceptions.FileAccessException** - File cannot be opened in Revit LT because it was last saved in a version of Revit prior to 8.1.
 -or-
 File has an invalid extension. Try changing the file's extension and opening it again.
 -or-
 File was saved by an application that was not developed or licensed by Autodesk.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - The modelPath to be opened doesn't exist.
 -or-
 File Not Found
- **Autodesk.Revit.Exceptions.InsufficientResourcesException** - This computer does not have enough memory, disk space, or other necessary resource to open the model.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Open is temporarily disabled.
 -or-
 The cloud model is not saved in current release of Revit.
 -or-
 The model is not allowed to access.
 -or-
 The document can not be opened.
 -or-
 Revit cannot save the transmitted model as a new central because it is already opened.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Opening was canceled by the user or by an API event callback.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - An internal error happened on the server, please contact the server administrator.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - User is not authorized to access the cloud model.
- **Autodesk.Revit.Exceptions.WrongUserException** - The local file is not owned by the current user, who therefore is not allowed to modify it.

