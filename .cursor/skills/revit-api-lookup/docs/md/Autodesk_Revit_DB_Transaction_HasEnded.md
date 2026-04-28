---
kind: method
id: M:Autodesk.Revit.DB.Transaction.HasEnded
zh: 事务
source: html/0287f338-0d0c-aff2-c75b-0aefe452969d.htm
---
# Autodesk.Revit.DB.Transaction.HasEnded Method

**中文**: 事务

Determines whether the transaction has ended already.

## Syntax (C#)
```csharp
public bool HasEnded()
```

## Returns
True if the transaction has already been committed or rolled back, False otherwise.

## Remarks
A transaction is ended by completing either the 'Commit' or 'RollBack' method.
 Another way of testing whether a transaction has ended is by testing
 the current status (see GetStatus () () () ). It must be either
 'TransactionStatus.Committed' or 'TransactionStatus.RolledBack'

