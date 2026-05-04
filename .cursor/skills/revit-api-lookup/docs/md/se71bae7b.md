---
kind: method
id: M:Autodesk.Revit.DB.Transaction.Commit(Autodesk.Revit.DB.FailureHandlingOptions)
zh: 事务
source: html/9e9983d1-bd0d-b476-2dc4-021c56eb2bd7.htm
---
# Autodesk.Revit.DB.Transaction.Commit Method

**中文**: 事务

Commits all changes made to the model during the transaction.

## Syntax (C#)
```csharp
public TransactionStatus Commit(
	FailureHandlingOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.FailureHandlingOptions`) - A set of options 
 to be used for handling eventual failures during this call.
 The options are only used temporarily during the commitment process. After
 the transaction is finished, the options will be reset to their default values.

## Returns
If finished successfully, this method returns TransactionStatus.Committed
 Note it is possible the RolledBack status is returned instead as an outcome
 of failure handling. If TransactionStatus.Pending is returned it means that
 failure handling has not been finalized yet and Revit awaits user's actions.
 Until committing is fully finalized, no changes to the document can be made
 (including starting of new transactions). Be aware that the returned status does not have to be necessarily the same like
 the status returned by GetStatus () () () even when the method is called
 immediately after committing the transaction. Such difference may happen due to actions
 made by a transaction finalizer, if there was one set.
 (See FailureHandlingOptions for more details.)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The current status of the transaction is not 'Started'.
 Transaction must be started before calling Commit or Rollback.
 -or-
 The transaction's document is currently in failure mode.
 No transaction operations are permitted until failure handling is finished.

