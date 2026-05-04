---
kind: method
id: M:Autodesk.Revit.DB.SubTransaction.Start
source: html/24a1e46d-2893-231a-cfff-a3f8e411247a.htm
---
# Autodesk.Revit.DB.SubTransaction.Start Method

Starts the sub-transaction.

## Syntax (C#)
```csharp
public TransactionStatus Start()
```

## Returns
If started successfully, this method returns TransactionStatus.Started.

## Remarks
A sub-transaction can only be started in an open transaction,
 and it must be closed (committed or rolled back) while still inside the open transaction. A sub-transaction can be started in another open sub-transaction,
 but then it must be closed before the parent sub-transaction is closed.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot modify the document for either a read-only external command is being executed, or changes to the document are temporarily disabled.
 -or-
 A sub-transaction can only be active inside an open Transaction.
 -or-
 The sub-transaction was already started and has not finished yet.

