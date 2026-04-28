---
kind: method
id: M:Autodesk.Revit.DB.Document.SaveAs(System.String)
zh: 文档、文件
source: html/25c44d4a-b220-5898-b28c-a2cf6a8a8673.htm
---
# Autodesk.Revit.DB.Document.SaveAs Method

**中文**: 文档、文件

Saves the document to a given file path.

## Syntax (C#)
```csharp
public void SaveAs(
	string filepath
)
```

## Parameters
- **filepath** (`System.String`) - File name and path to be saved as. Either a relative or absolute path can be provided.

## Remarks
The document's title in Revit's title bar
 will be updated automatically to reflect the file's new name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - filepath is an empty string.
 -or-
 The filepath is not a valid file path.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.CentralModelException** - Central model is missing.
 -or-
 Central model is incompatible.
 -or-
 The central model was saved in a different version of Revit.
 -or-
 Revit encountered errors while saving to the new central model. Resave again as a new central model.
 -or-
 Incompatible servers for external services.
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
 There is an existing file at filepath.
 -or-
 Saving is not allowed in the current application mode.
 -or-
 The document just had worksharing enabled or was opened detached,
 so SaveAsOptions must be passed in SaveAs
 with WorksharingSaveAsOptions.SaveAsCentral set to true.
 -or-
 Operation is not permitted when there is any open sub-transaction, transaction, or transaction group.
 -or-
 Saving failed.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Saving was canceled by the user or by an API event callback.
- **Autodesk.Revit.Exceptions.OutdatedDirectlyOpenedCentralException** - Other users have modified the central model while you had it opened. Resave your document as a local file and then synchronize with central again.

