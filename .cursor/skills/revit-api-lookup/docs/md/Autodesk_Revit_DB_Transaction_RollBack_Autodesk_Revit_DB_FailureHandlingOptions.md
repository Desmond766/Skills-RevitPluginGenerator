---
kind: method
id: M:Autodesk.Revit.DB.Transaction.RollBack(Autodesk.Revit.DB.FailureHandlingOptions)
zh: 事务
source: html/d99de9ee-168e-a114-1255-0cea9f317efb.htm
---
# Autodesk.Revit.DB.Transaction.RollBack Method

**中文**: 事务

Rolls back all changes made to the model during the transaction.

## Syntax (C#)
```csharp
public TransactionStatus RollBack(
	FailureHandlingOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.FailureHandlingOptions`) - A set of options 
 to be used for handling eventual failures during this call.
 The options are only used temporarily during this rolling back process. After
 the transaction is finished, the options will be reset to their default values.

## Returns
If finished successfully, this method returns TransactionStatus.RolledBack.
 Be aware that the returned status does not have to be necessarily the same like
 the status returned by GetStatus () () () even when the method is called
 immediately after rolling back the transaction. Such difference may happen due to actions
 made by a transaction finalizer, if there was one set.
 (See FailureHandlingOptions for more details.)

## Remarks
By rolling back a transaction, all changes made to the model are discarded.
 RollBack may only be called for a transaction that has been started.
 (Use the GetStatus () () () method to check the current state.)
 Be aware that rolling back may be delayed (as a result of failure handling.)
 Callers should always check the returned status to test whether a transaction
 was rolled back successfully. Only after rolling back is fully completed,
 the transaction may be started again.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The current status of the transaction is not 'Started'.
 Transaction must be started before calling Commit or Rollback.
 -or-
 The transaction's document is currently in failure mode.
 No transaction operations are permitted until failure handling is finished.

