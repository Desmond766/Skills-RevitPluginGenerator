---
kind: method
id: M:Autodesk.Revit.DB.TransactionGroup.Start(System.String)
source: html/5debe7ea-7131-58d1-c9bb-3286a8d5895d.htm
---
# Autodesk.Revit.DB.TransactionGroup.Start Method

Starts the transaction group with an assigned name.

## Syntax (C#)
```csharp
public TransactionStatus Start(
	string transGroupName
)
```

## Parameters
- **transGroupName** (`System.String`) - Name of the group.
 The name will be used only for a group that is assimilated at the end.

## Returns
If started successfully, this method returns TransactionStatus.Started.

## Remarks
A transaction group can be started only when there is no transaction started currently.
 It can be started inside another transaction group though. With such group nesting
 it is required that inner transaction groups are finished (i.e. rolled back, committed,
 or assimilated) before outer groups are.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Cannot modify the document for either a read-only external command is being executed, or changes to the document are temporarily disabled.
 -or-
 Transaction group cannot be started during an active transaction.
 -or-
 The Transaction group has already been started.

