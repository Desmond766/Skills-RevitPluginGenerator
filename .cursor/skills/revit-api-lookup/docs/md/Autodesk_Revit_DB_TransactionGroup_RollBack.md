---
kind: method
id: M:Autodesk.Revit.DB.TransactionGroup.RollBack
source: html/2efcf628-bb40-bf36-a2e4-eaeca4cca461.htm
---
# Autodesk.Revit.DB.TransactionGroup.RollBack Method

Rolls back the transaction group, which effectively undoes all transactions committed inside the group.

## Syntax (C#)
```csharp
public TransactionStatus RollBack()
```

## Returns
If finished successfully, this method returns TransactionStatus.RolledBack.

## Remarks
Note that once a group is rolled back, the undone transactions cannot be redone. RollBack can be called only when all inner transaction groups and transactions are finished,
 i.e. after they were either committed or rolled back.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Transaction group has not been started (its status is not 'Started')..
 -or-
 The transaction's document is currently in failure mode.
 Transaction groups cannot be closed until failure handling is finished.
 You may use a transaction finalizer to close a group after the failure handling ends.

