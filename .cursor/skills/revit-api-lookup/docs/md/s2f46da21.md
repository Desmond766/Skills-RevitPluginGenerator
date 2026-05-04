---
kind: method
id: M:Autodesk.Revit.DB.SubTransaction.Commit
source: html/65a0359a-ef13-e7aa-7d5c-7470fe177848.htm
---
# Autodesk.Revit.DB.SubTransaction.Commit Method

Commits all changes made to the model made during the sub-transaction.

## Syntax (C#)
```csharp
public TransactionStatus Commit()
```

## Returns
If finished successfully, this method returns TransactionStatus.Committed

## Remarks
The changes are not permanently committed to the document yet. They will be
 committed only when the active transaction is committed. If the transaction
 is rolled back instead, the changes committed during this sub-transaction will be discarded. Commit can be called only when all inner sub-transactions, if any, are already finished,
 i.e. they were either committed or rolled back. If there is still a sub-transaction open,
 an attempt to commit this outer sub-transaction will cause an exception.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - A sub-transaction can only be active inside an open Transaction.
 -or-
 The sub-transaction's current status is not TransactionStatus.Started,
 therefore it may not be committed or rolled back.

