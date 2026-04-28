---
kind: method
id: M:Autodesk.Revit.DB.Transaction.SetName(System.String)
zh: 事务
source: html/c0283e7f-d261-6016-724c-31ae5cde96a7.htm
---
# Autodesk.Revit.DB.Transaction.SetName Method

**中文**: 事务

Sets the transaction's name.

## Syntax (C#)
```csharp
public void SetName(
	string name
)
```

## Parameters
- **name** (`System.String`) - A name for the transaction.

## Remarks
A transaction needs a name before it can be started, i.e. before one
 of the 'Start' method is invoked for this transaction object.
 The name will later appear in the Undo menu in Revit after a transaction
 is successfully committed.
 Another ways of setting the name is either during construction
 or during the Start(String) method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The name argument is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

