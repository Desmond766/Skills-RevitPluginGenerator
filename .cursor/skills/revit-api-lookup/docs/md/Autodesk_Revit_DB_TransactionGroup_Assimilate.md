---
kind: method
id: M:Autodesk.Revit.DB.TransactionGroup.Assimilate
source: html/158471e4-5554-16ed-f9bf-f7499b86309c.htm
---
# Autodesk.Revit.DB.TransactionGroup.Assimilate Method

Assimilates all inner transactions by merging them into a single undo item.

## Syntax (C#)
```csharp
public TransactionStatus Assimilate()
```

## Returns
If finished successfully, this method returns TransactionStatus.Committed.

## Remarks
After a successful assimilation the transaction group is committed. All transactions committed inside this group will be merged into one
 single transaction. The resulting undo item will bear this group's name. Assimilate can be called only when all inner transaction groups and transactions
 are finished, i.e. after they were either committed or rolled back.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Transaction group has not been started (its status is not 'Started')..
 -or-
 The transaction's document is currently in failure mode.
 Transaction groups cannot be closed until failure handling is finished.
 You may use a transaction finalizer to close a group after the failure handling ends.

