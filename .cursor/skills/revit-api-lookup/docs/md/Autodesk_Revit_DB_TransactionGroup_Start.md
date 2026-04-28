---
kind: method
id: M:Autodesk.Revit.DB.TransactionGroup.Start
source: html/fff3e88e-358c-e6d0-d539-61517f53140c.htm
---
# Autodesk.Revit.DB.TransactionGroup.Start Method

Starts the transaction group

## Syntax (C#)
```csharp
public TransactionStatus Start()
```

## Returns
If started successfully, this method returns TransactionStatus.Started.

## Remarks
A transaction group can be started only when there is no transaction started currently.
 It can be started inside another transaction group. When groups are nested inside each other
 it is required that inner transaction groups are finished (i.e. rolled back, committed,
 or assimilated) before outer groups are.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot modify the document for either a read-only external command is being executed, or changes to the document are temporarily disabled.
 -or-
 Transaction group cannot be started during an active transaction.
 -or-
 The Transaction group has already been started.

