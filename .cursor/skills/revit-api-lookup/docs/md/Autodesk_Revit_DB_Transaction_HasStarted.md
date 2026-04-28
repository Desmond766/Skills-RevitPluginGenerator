---
kind: method
id: M:Autodesk.Revit.DB.Transaction.HasStarted
zh: 事务
source: html/425a8103-a11b-4c45-f002-0e7bc602d074.htm
---
# Autodesk.Revit.DB.Transaction.HasStarted Method

**中文**: 事务

Determines whether the transaction has been started yet.

## Syntax (C#)
```csharp
public bool HasStarted()
```

## Returns
True if the transaction has already started, False otherwise.

## Remarks
A transaction is considered being started after a 'Start' method was called
 and until the transaction is either completely committed or rolled back.
 HasStarted may return True even after 'Commit' or 'RollBack' was called
 if the method returned the TransactionStatus.Pending value. A transaction can only be Started when HasStarted returns false.

