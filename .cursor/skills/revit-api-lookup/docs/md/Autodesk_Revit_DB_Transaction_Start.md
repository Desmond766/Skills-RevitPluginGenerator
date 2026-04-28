---
kind: method
id: M:Autodesk.Revit.DB.Transaction.Start
zh: 事务
source: html/1146fa87-127d-c432-0f51-79a5eb102031.htm
---
# Autodesk.Revit.DB.Transaction.Start Method

**中文**: 事务

Starts the transaction.

## Syntax (C#)
```csharp
public TransactionStatus Start()
```

## Returns
If finished successfully, this method returns TransactionStatus.Started.
 Note that unless starting is successful, changes cannot be made to the document.

## Remarks
A transaction may be started only after it was instantiated or after it
 was previously committed or rolled back. In order to start a transaction,
 it must have a name assigned. If the name was not specified when the
 transaction object was instantiated, it has to be set by calling
 the SetName(String) method. Be aware that every time a transaction starts,
 Failure Handling Options 
 will be reset to their default values. If a specific failure handling
 is required, programmers need to use SetFailureHandlingOptions(FailureHandlingOptions) 
 before the transaction is committed or rolled back.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot modify the document for either a read-only external command is being executed, or changes to the document are temporarily disabled.
 -or-
 The transaction's document is currently in failure mode.
 No transaction operations are permitted until failure handling is finished.
 -or-
 The transaction started already and has not been completed yet.
 -or-
 Starting a new transaction is not permitted. It could be because
 another transaction already started and has not been completed yet,
 or the document is in a state in which it cannot start a new transaction
 (e.g. during failure handling or a read-only mode, which could be either permanent or temporary).
 -or-
 The transaction does not have a valid name assigned yet.

