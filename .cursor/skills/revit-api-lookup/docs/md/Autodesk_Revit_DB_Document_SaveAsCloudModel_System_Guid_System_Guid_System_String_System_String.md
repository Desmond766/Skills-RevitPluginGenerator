---
kind: method
id: M:Autodesk.Revit.DB.Document.SaveAsCloudModel(System.Guid,System.Guid,System.String,System.String)
zh: 文档、文件
source: html/2fd26edf-b1f8-905b-e5d7-b56eaa2a2eeb.htm
---
# Autodesk.Revit.DB.Document.SaveAsCloudModel Method

**中文**: 文档、文件

Saves current non-workshared or workshared model as a cloud model or workshared cloud model in BIM 360 Docs or Autodesk Docs.

## Syntax (C#)
```csharp
public void SaveAsCloudModel(
	Guid accountId,
	Guid projectId,
	string folderId,
	string modelName
)
```

## Parameters
- **accountId** (`System.Guid`) - The BIM 360 Docs or Autodesk Docs account Id.
 You can use one of the following methods to get this Id:
 If you get the hub Id with Forge Data Management API, remove the prefix "b." of the Id string and convert the rest to a Guid. If you get the account Id with Forge BIM 360 Docs or Autodesk Docs API, just convert the Id string to a Guid.
- **projectId** (`System.Guid`) - The BIM 360 Docs or Autodesk Docs project Id.
 You can use one of the following methods to get this Id:
 If you get the project Id with Forge Data Management API, remove the prefix "b." of the Id string and convert the rest to a Guid. If you get the project Id with Forge BIM 360 Docs or Autodesk Docs API, just convert the Id string to a Guid.
- **folderId** (`System.String`) - Folder identity in BIM 360 Docs or Autodesk Docs to save the model.
 You can use one of the following methods to get this Id:
 The folder Id string from Forge Data Management API. The folder Id string from Forge BIM 360 Docs or Autodesk Docs API.
- **modelName** (`System.String`) - Model name in BIM 360 Docs or Autodesk Docs to save the model.

## Remarks
Assumes that user is currently signed in BIM 360 Docs or Autodesk Docs and has access to Autodesk cloud services.
 This operation will create a model on cloud and then create a local cache of the cloud model.
 This method cannot be used when current document is already in cloud. You can use one of the following methods to save a local model as a workshared cloud model in BIM 360 Docs or Autodesk Docs.
 If the local model is a workshared model, then it will be a workshared cloud model after you use this method successfully. If the local model is a non-workshared model, you can enable the workset with EnableWorksharing(String, String) and then save as a workshared cloud model. If the local model is a non-workshared model, and you have already saved it as a non-workshared cloud model in BIM 360 Docs or Autodesk Docs, you can still enable the workset with
 EnableCloudWorksharing () () () to convert it to a workshared cloud model. You cannot save a local workshared model as a non-workshared cloud model in BIM 360 Docs or Autodesk Docs.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - folderId is an empty string.
 -or-
 modelName is an empty string.
 -or-
 The input file name "modelName" does not represent a valid file name.
 -or-
 Thrown when the input BIM 360 Docs or Autodesk Docs account Id or project Id is invalid or unmatched.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - SaveAs may not be called during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Saving is not allowed in the current application mode.
 -or-
 This Document is not a project document.
 -or-
 This Document is in an edit mode.
 -or-
 This Document is not a primary document, it is a linked document.
 -or-
 SaveAs is temporarily disabled.
 -or-
 This Document is a cloud model, cannot be saved as a cloud model.
 -or-
 There is a transaction phase left open (such as a transaction, sub-transaction of transaction group) at the time of invoking this method.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - Could be for any of the reasons related to network.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - Could be for any of the reasons that saveAs fails with RevitServerInternalException.
- **Autodesk.Revit.Exceptions.RevitServerModelAlreadyExistsException** - Failed due to there is a model with the same name already exists at the specified location.
- **Autodesk.Revit.Exceptions.RevitServerModelNameBreaksConventionException** - Failed due to the model name is breaking project naming convention.
- **Autodesk.Revit.Exceptions.RevitServerUnauthenticatedUserException** - User is not signed in with Autodesk id.
- **Autodesk.Revit.Exceptions.RevitServerUnauthorizedException** - You don't have the entitlement to perform the operation to this this Document.
 -or-
 User is not authorized to access the specified cloud project.

