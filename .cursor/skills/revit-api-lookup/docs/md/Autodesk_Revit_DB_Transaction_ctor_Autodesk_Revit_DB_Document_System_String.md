---
kind: method
id: M:Autodesk.Revit.DB.Transaction.#ctor(Autodesk.Revit.DB.Document,System.String)
zh: 事务
source: html/8ac32652-a440-7f01-81b8-d6a7f2dc7791.htm
---
# Autodesk.Revit.DB.Transaction.#ctor Method

**中文**: 事务

Instantiates a transaction object

## Syntax (C#)
```csharp
public Transaction(
	Document document,
	string name
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for which this transaction is going to be used.
- **name** (`System.String`) - The name of the transaction. This name will appear in the undo menu
 once the transaction is successfully committed. The name must not be empty.
 The name can be reset later by either calling SetName(String) or
 by using the name argument in the Start(String) method.

## Remarks
The transaction does not start by creating a transaction object.
 One of the 'Start' methods will need to be called in order to start
 this transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The name argument is an empty string.
 -or-
 Document is a linked file. Transactions can only be used in primary documents (projects or families.)
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

