---
kind: method
id: M:Autodesk.Revit.DB.Transaction.Commit
zh: 事务
source: html/32714010-7138-f64f-8fde-a310354448e3.htm
---
# Autodesk.Revit.DB.Transaction.Commit Method

**中文**: 事务

Commits all changes made to the model during the transaction.

## Syntax (C#)
```csharp
public TransactionStatus Commit()
```

## Returns
If finished successfully, this method returns TransactionStatus.Committed.
 Note it is possible the RolledBack status is returned instead as an outcome
 of failure handling. If TransactionStatus::Pending is returned it means that
 failure handling has not been finalized yet and Revit awaits a user actions.
 Until committing is fully finalized, no changes to the document can be made
 (including starting of new transactions). The returned status does not have to be necessarily the same as
 the status returned by GetStatus () () () even when the method is called
 immediately after committing the transaction. Such a difference may happen due to actions
 made by a transaction finalizer, if there was one set.
 (See FailureHandlingOptions for more details.)

## Remarks
By committing a transaction, all changes made to the model during the transaction
 are accepted. A new undo item will appear in the Undo menu in Revit, which allows
 the user to undo the changes. The undo item will have this transaction's name.
 Commit may only be called for a transaction that has been started.
 (Use the GetStatus () () () method to check the current state.)
 Be aware that committing may fail or can be delayed (as a result of failure handling.)
 Callers should always check the returned status to test whether a transaction was
 committed successfully. Only after a transaction is successfully committed (or rolled
 back as a result of handling transaction failures), it may be started again.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The current status of the transaction is not 'Started'.
 Transaction must be started before calling Commit or Rollback.
 -or-
 The transaction's document is currently in failure mode.
 No transaction operations are permitted until failure handling is finished.

