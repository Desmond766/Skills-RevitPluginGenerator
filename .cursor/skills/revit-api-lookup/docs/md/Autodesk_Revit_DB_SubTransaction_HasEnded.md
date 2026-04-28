---
kind: method
id: M:Autodesk.Revit.DB.SubTransaction.HasEnded
source: html/26649bc6-e455-e25d-3b03-929413f44e02.htm
---
# Autodesk.Revit.DB.SubTransaction.HasEnded Method

Determines whether the sub-transaction has ended already.

## Syntax (C#)
```csharp
public bool HasEnded()
```

## Returns
True if the sub-transaction has already been committed or rolled back, False otherwise.

## Remarks
A sub-transaction is ended by completing either the Commit 
 or RollBack method.
 Another way of testing whether a sub-transaction has ended is by testing
 its current status returned from (see GetStatus () () () ). It must be either
 'TransactionStatus.Committed' or 'TransactionStatus.RolledBack'

