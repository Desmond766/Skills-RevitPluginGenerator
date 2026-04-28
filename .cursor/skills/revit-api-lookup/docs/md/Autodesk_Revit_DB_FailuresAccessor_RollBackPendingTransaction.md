---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.RollBackPendingTransaction
source: html/6f8caecd-0c82-658c-f209-eb91ea7fb5c6.htm
---
# Autodesk.Revit.DB.FailuresAccessor.RollBackPendingTransaction Method

Finishes pending failures processing by rolling back the pending transaction.

## Syntax (C#)
```csharp
public TransactionStatus RollBackPendingTransaction()
```

## Returns
Result of attempt to roll back the pending transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).
 -or-
 The processing of the failures is not in the pending state.

