---
kind: method
id: M:Autodesk.Revit.DB.Document.Save
zh: 文档、文件
source: html/8dec13b6-71f4-45d2-74e3-b109153721b5.htm
---
# Autodesk.Revit.DB.Document.Save Method

**中文**: 文档、文件

Saves the document.

## Syntax (C#)
```csharp
public void Save()
```

## Remarks
If the document was created in this current session and has not been saved to a file yet,
 it needs to be first saved using the SaveAs method instead. This method may not be called unless all transactions, sub-transactions, and transaction groups
 that were opened by the API code were closed.
 That also implies that this method cannot be called during dynamic updates.
 Event handlers are not allowed to save document that are currently in modifiable state.

## Exceptions
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
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - Save may not be called during dynamic update.
- **Autodesk.Revit.Exceptions.InsufficientResourcesException** - This computer does not have enough memory, disk space, or other necessary resource to save the model.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This Document is not a primary document, it is a linked document.
 -or-
 Save is temporarily disabled.
 -or-
 Saving is not allowed in the current application mode.
 -or-
 File path must be already set to be able to save the document.It needs to be first saved using the SaveAs method instead.
 -or-
 The file is read-only, can not be saved.
 -or-
 Operation is not permitted when there is any open sub-transaction, transaction, or transaction group.
 -or-
 Saving failed.
- **Autodesk.Revit.Exceptions.OperationCanceledException** - Saving was canceled by the user or by an API event callback.
- **Autodesk.Revit.Exceptions.OutdatedDirectlyOpenedCentralException** - Other users have modified the central model while you had it opened. Resave your document as a local file and then synchronize with central again.

