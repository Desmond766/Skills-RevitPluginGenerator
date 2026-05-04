---
kind: method
id: M:Autodesk.Revit.DB.SubTransaction.RollBack
source: html/3de65ee0-50f1-c601-62f9-c77479b08418.htm
---
# Autodesk.Revit.DB.SubTransaction.RollBack Method

Discards all changes made to the model during the sub-transaction.

## Syntax (C#)
```csharp
public TransactionStatus RollBack()
```

## Returns
If finished successfully, this method returns TransactionStatus.RolledBack.

## Remarks
The parent transaction (or a parent sub-transaction, if any)
 can still be committed, but the changes rolled back by this
 method will not be part of the committed transaction. RollBack can be called only when all inner sub-transaction, if any, are finished,
 i.e. they were either committed or rolled back. If there is still a sub-transaction open,
 an attempt to roll this outer sub-transaction back will cause an exception.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - A sub-transaction can only be active inside an open Transaction.
 -or-
 The sub-transaction's current status is not TransactionStatus.Started,
 therefore it may not be committed or rolled back.

