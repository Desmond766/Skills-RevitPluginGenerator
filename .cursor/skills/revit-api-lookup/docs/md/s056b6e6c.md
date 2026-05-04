---
kind: method
id: M:Autodesk.Revit.DB.TransactionGroup.HasStarted
source: html/730a43e9-026e-2989-dc58-cef21cd81798.htm
---
# Autodesk.Revit.DB.TransactionGroup.HasStarted Method

Determines whether the transaction has been started yet.

## Syntax (C#)
```csharp
public bool HasStarted()
```

## Returns
True if the transaction group has already started, False otherwise.

## Remarks
A transaction group is considered being started after the Start 
 method was called and until the transaction group is either completely committed
 or rolled back. A transaction group can only be Started when HasStarted returns false.

