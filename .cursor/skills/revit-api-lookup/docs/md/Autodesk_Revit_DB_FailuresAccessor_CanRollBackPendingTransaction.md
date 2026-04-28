---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.CanRollBackPendingTransaction
source: html/f84e1f4a-141c-8441-f920-cb697a555002.htm
---
# Autodesk.Revit.DB.FailuresAccessor.CanRollBackPendingTransaction Method

Checks if pending failure processing can be finished by rolling back a pending transaction.

## Syntax (C#)
```csharp
public bool CanRollBackPendingTransaction()
```

## Returns
True if there is a pending transaction and this transaction is allowed to be rolled back

## Remarks
Check makes sense only if the failure processing is pending.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

