---
kind: method
id: M:Autodesk.Revit.DB.Transaction.Start(System.String)
zh: 事务
source: html/5fb266f4-5eca-049f-6a30-f3ed76687409.htm
---
# Autodesk.Revit.DB.Transaction.Start Method

**中文**: 事务

Starts the transaction with an assigned name.

## Syntax (C#)
```csharp
public TransactionStatus Start(
	string name
)
```

## Parameters
- **name** (`System.String`) - Name of the transaction; If the transaction already has name, this new one will preplace it.
 The name will appear on the Undo menu in Revit if the transaction is successfully committed.

## Returns
If finished successfully, this method returns TransactionStatus.Started.
 Note that unless starting is successful, changes cannot be made to the document.

## Remarks
A transaction may be started only after it was instantiated or after it
 was previously committed or rolled back. Be aware that every time a transaction starts,
 Failure Handling Options 
 will be reset to their default values. If a specific failure handling
 is required, programmers need to use SetFailureHandlingOptions(FailureHandlingOptions) 
 before the transaction is committed or rolled back.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The name argument is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
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

