---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.OpenAndActivateDocument(Autodesk.Revit.DB.ModelPath,Autodesk.Revit.DB.OpenOptions,System.Boolean,Autodesk.Revit.DB.IOpenFromCloudCallback)
source: html/4df0298b-b35e-c110-8643-527641980560.htm
---
# Autodesk.Revit.UI.UIApplication.OpenAndActivateDocument Method

Opens and activates a Revit document, include both local document or cloud document.

## Syntax (C#)
```csharp
public UIDocument OpenAndActivateDocument(
	ModelPath modelPath,
	OpenOptions openOptions,
	bool detachAndPrompt,
	IOpenFromCloudCallback openFromCloudCallback
)
```

## Parameters
- **modelPath** (`Autodesk.Revit.DB.ModelPath`) - A path to a Revit file to be opened.
 The file can be either a Revit project, template, or family document.
- **openOptions** (`Autodesk.Revit.DB.OpenOptions`) - Options for opening the file.
- **detachAndPrompt** (`System.Boolean`) - True means if openOptions specifies DoNotDetach,
 then for workshared models detach from central and query the user whether to preserve or discard worksets.
 make no sense when opening a cloud document.
- **openFromCloudCallback** (`Autodesk.Revit.DB.IOpenFromCloudCallback`) - Callback function that allow caller to handle cases when conflicts happen during opening a cloud document.
 Make no sense when opening a non-cloud document.

## Returns
The opened document.

## Remarks
This method, if successful, changes the active document.
 It is not allowed to have an open transaction in the active document when calling this method.
 Consequently, this method can only be used in manual transaction mode, not in automatic mode.
 Additionally, this method may not be called from inside an event handler.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - If DetachFromCentralOption is not DoNotDetach when opening a cloud document.
 If the active document is currently modifiable. If an API event handler is currently being executed.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - If Nothing nullptr a null reference ( Nothing in Visual Basic) is passed as 'modelPath'.
 -or-
 If Nothing nullptr a null reference ( Nothing in Visual Basic) is passed as 'openOptions'.
 -or-
 A non-optional argument was null
- **Autodesk.Revit.Exceptions.CannotOpenBothCentralAndLocalException** - Cannot open the local model and the central model in the same Revit session. You can close one to open the other in the same Revit session.
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Thrown when file is not found at the give path.
- **Autodesk.Revit.Exceptions.CentralModelException** - Revit encountered serious errors while trying to open the central model. An internal error happened on the central model, please contact the server administrator.
- **Autodesk.Revit.Exceptions.CorruptModelException** - There are too many corrupt elements to open this model.
- **Autodesk.Revit.Exceptions.FileAccessException** - When file cannot be opened in Revit LT because it was last saved in a version of Revit prior to 8.1. when file has an invalid extension. Try changing the file's extension and opening it again.
- **Autodesk.Revit.Exceptions.FileArgumentNotFoundException** - The file specified by 'modelPath' cannot be found or the given 'modelPath' is not a Revit file (a project, template, or family document).
- **Autodesk.Revit.Exceptions.InsufficientResourcesException** - This computer does not have enough memory, disk space, or other necessary resource to open the model.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The cloud model is not saved in current release of Revit.
 -or-
 The model is not allowed to access.
 -or-
 The document can not be opened. Open is temporarily disabled. Revit cannot save the transmitted model as a new central because it is already opened.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Opening was canceled by the user or by an API event callback.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - If there is any server internal error.
- **Autodesk.Revit.Exceptions.RevitServerUnauthenticatedUserException** - User is not signed in with Autodesk id when trying to open a cloud model.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - User is not authorized to access the cloud model.
- **Autodesk.Revit.Exceptions.WrongUserException** - The local file is not owned by the current user, who therefore is not allowed to modify it.

