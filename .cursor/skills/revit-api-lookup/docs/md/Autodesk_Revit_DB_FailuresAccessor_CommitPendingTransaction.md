---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.CommitPendingTransaction
source: html/e747579a-a5cc-623e-3091-c398ef4f1bc3.htm
---
# Autodesk.Revit.DB.FailuresAccessor.CommitPendingTransaction Method

Finishes pending failures processing by committing the pending transaction.

## Syntax (C#)
```csharp
public TransactionStatus CommitPendingTransaction()
```

## Returns
Result of attempt to commit the pending transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).
 -or-
 The processing of the failures is not in the pending state.
 -or-
 There is no pending transaction or transaction is not allowed to be committed.

