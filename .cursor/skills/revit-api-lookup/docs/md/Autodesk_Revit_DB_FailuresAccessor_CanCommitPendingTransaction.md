---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.CanCommitPendingTransaction
source: html/ad0c9f51-c915-08dc-c2a1-544055c74254.htm
---
# Autodesk.Revit.DB.FailuresAccessor.CanCommitPendingTransaction Method

Checks if pending failure processing can be finished by committing a pending transaction.

## Syntax (C#)
```csharp
public bool CanCommitPendingTransaction()
```

## Returns
True if there is a pending transaction and this transaction is allowed to be committed.

## Remarks
Check makes sense only if the failure processing is pending.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

