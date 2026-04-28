---
kind: method
id: M:Autodesk.Revit.DB.Document.SaveAs(Autodesk.Revit.DB.ModelPath,Autodesk.Revit.DB.SaveAsOptions)
zh: 文档、文件
source: html/db245ec6-e07a-b989-077a-a2947e308345.htm
---
# Autodesk.Revit.DB.Document.SaveAs Method

**中文**: 文档、文件

Saves the document to a given path.

## Syntax (C#)
```csharp
public void SaveAs(
	ModelPath path,
	SaveAsOptions options
)
```

## Parameters
- **path** (`Autodesk.Revit.DB.ModelPath`) - Name and path to be saved as. For a file path, either a relative or absolute path can be provided.
- **options** (`Autodesk.Revit.DB.SaveAsOptions`) - Options to govern the SaveAs operation.

## Remarks
This method may not be called unless all transactions, sub-transactions, and transaction groups
 that were opened by the API code were closed.
 That also implies that this method cannot be called during dynamic updates.
 Event handlers are not allowed to save document that are currently in modifiable state. If options.rename is true, then the document's title in Revit's title bar
 will be updated automatically to reflect the file's new name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The path is empty.
 -or-
 The specified filepath is invalid.
 -or-
 options.PreviewViewId is not valid for generation of a preview.
 -or-
 The document is not workshared,
 so no WorksharingSaveAsOptions are allowed to be set for SaveAs.
 -or-
 The document just had worksharing enabled or was opened detached,
 so WorksharingSaveAsOptions.SaveAsCentral must be set to true for SaveAs.
 -or-
 Revit cannot clear the transmitted flag. This is not a transmitted document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralModelAccessDeniedException** - Access to the central model was denied. A possible reason is because the model was under maintenance.
- **Autodesk.Revit.Exceptions.CentralModelContentionException** - The central model is being accessed by another client.
- **Autodesk.Revit.Exceptions.CentralModelException** - The central model is overwritten by other user.
 -or-
 The central model is missing.
 -or-
 The central model is incompatible.
 -or-
 Your data or permissions saving is aborted by another user.
 -or-
 The central model was saved in a different version of Revit.
 -or-
 Revit encountered errors while saving to the new central model. Resave again as a new central model.
 -or-
 Incompatible servers for external services.
 -or-
 Overwrite old-version model is not supported for server-based.
 -or-
 An internal error happened on the central model, please contact the server administrator.
 -or-
 Username does not match the one used to create the local file.
 -or-
 Revit could not save all of the worksets that have been changed. Try again.
- **Autodesk.Revit.Exceptions.FileAccessException** - The file at the given path location could not be accessed or saved.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - The given file, path or network location could not be found during save.
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - SaveAs may not be called during dynamic update.
- **Autodesk.Revit.Exceptions.InsufficientResourcesException** - This computer does not have enough memory, disk space, or other necessary resource to save the model.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Document is not a primary document, it is a linked document.
 -or-
 SaveAs is temporarily disabled.
 -or-
 options.overwriteExistingFile is 'false' but there is an existing file at path.
 -or-
 options.overwriteExistingFile is 'true' but the target file at path is read only.
 -or-
 There is already a central at path; Revit Server does not allow overwrite.
 -or-
 Revit Server only supports RVT model.
 -or-
 Saving is not allowed in the current application mode.
 -or-
 Operation is not permitted when there is any open sub-transaction, transaction, or transaction group.
 -or-
 Saving failed.
 -or-
 The file path is invalid.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Saving was canceled by the user or by an API event callback.
- **Autodesk.Revit.Exceptions.OutdatedDirectlyOpenedCentralException** - Other users have modified the central model while you had it opened. Resave your document as a local file and then synchronize with central again.
- **Autodesk.Revit.Exceptions.RevitServerCommunicationException** - The server-based central model could not be accessed
 because of a network communication error.
- **Autodesk.Revit.Exceptions.RevitServerInternalException** - The disk space is running low on server, please contact the server administrator.
 -or-
 An internal error happened on the server, please contact the server administrator.

