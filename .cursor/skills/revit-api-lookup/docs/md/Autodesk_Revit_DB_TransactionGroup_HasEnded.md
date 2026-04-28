---
kind: method
id: M:Autodesk.Revit.DB.TransactionGroup.HasEnded
source: html/e559d859-b429-f052-16ce-541e4ddb0227.htm
---
# Autodesk.Revit.DB.TransactionGroup.HasEnded Method

Determines whether the transaction group has ended already.

## Syntax (C#)
```csharp
public bool HasEnded()
```

## Returns
True if the transaction group has already been committed or rolled back, False otherwise.

## Remarks
A transaction is ended by completing either the Commit 
 or RollBack or Assimilate method.
 Another way of testing whether a transaction group has ended is by testing
 its current status returned from (see GetStatus () () () ). It must be either
 'TransactionStatus.Committed' or 'TransactionStatus.RolledBack'

