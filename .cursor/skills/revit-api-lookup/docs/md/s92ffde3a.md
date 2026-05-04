---
kind: method
id: M:Autodesk.Revit.DB.Transaction.#ctor(Autodesk.Revit.DB.Document)
zh: 事务
source: html/36a9e161-5943-3a7d-b022-a2779185d02c.htm
---
# Autodesk.Revit.DB.Transaction.#ctor Method

**中文**: 事务

Instantiates a transaction object.

## Syntax (C#)
```csharp
public Transaction(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for which this transaction is going to be used.

## Remarks
The transaction does not start by creating a transaction object.
 One of the 'Start' methods will need to be called in order to start
 this transaction. A transaction cannot start unless is has a valid (non-empty) name.
 Because this constructor does not take a name, a name must be assigned later
 before or during the 'Start' method.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Document is a linked file. Transactions can only be used in primary documents (projects or families.)
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

