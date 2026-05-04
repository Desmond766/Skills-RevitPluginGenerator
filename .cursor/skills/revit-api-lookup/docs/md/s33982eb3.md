---
kind: method
id: M:Autodesk.Revit.DB.TransactionGroup.Commit
source: html/11878443-43f2-63fb-a95d-baa1eeab776d.htm
---
# Autodesk.Revit.DB.TransactionGroup.Commit Method

Commits the transaction group.

## Syntax (C#)
```csharp
public TransactionStatus Commit()
```

## Returns
If finished successfully, this method returns TransactionStatus.Committed.

## Remarks
Committing a group does not change the model.
 It only confirms the commitment of all inner groups and transactions. Commit can be called only when all inner transaction groups and transactions are finished,
 i.e. after they were either committed or rolled back. If there is still a transaction or an inner
 transaction group open, an attempt to commit this outer group will cause an exception.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Transaction group has not been started (its status is not 'Started')..
 -or-
 The transaction's document is currently in failure mode.
 Transaction groups cannot be closed until failure handling is finished.
 You may use a transaction finalizer to close a group after the failure handling ends.

