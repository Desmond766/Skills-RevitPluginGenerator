---
kind: method
id: M:Autodesk.Revit.DB.Transaction.GetStatus
zh: 事务
source: html/fdf98941-eee4-d8af-e3f7-5b6c7ccc3c74.htm
---
# Autodesk.Revit.DB.Transaction.GetStatus Method

**中文**: 事务

Returns the current status of the transaction.

## Syntax (C#)
```csharp
public TransactionStatus GetStatus()
```

## Returns
The current status of the transaction.

## Remarks
If the status was set to TransactionStatus.Pending as the result of calling
 Commit or RollBack, the status will be changed later to either 'Committed'
 or 'RolledBack' after failure handling is finished. That status change will
 be made asynchronously.

