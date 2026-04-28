---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.IsTransactionBeingCommitted
source: html/b8a411f9-da82-955f-11c2-85df810a6da2.htm
---
# Autodesk.Revit.DB.FailuresAccessor.IsTransactionBeingCommitted Method

Checks if the transaction for which failures are processed is being committed or rolled back.

## Syntax (C#)
```csharp
public bool IsTransactionBeingCommitted()
```

## Returns
True if current transaction is being committed, false if the transaction is being rolled back.

## Remarks
A transaction is considered as "being committed" if a caller has requested the transaction to be committed and
 no previous failure processing operation requested the transaction to be rolled back.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

