---
kind: method
id: M:Autodesk.Revit.DB.TransactionGroup.#ctor(Autodesk.Revit.DB.Document)
source: html/74cff3fa-9380-2c30-9fa9-b0e839a2c8e4.htm
---
# Autodesk.Revit.DB.TransactionGroup.#ctor Method

Constructs a transaction group object.

## Syntax (C#)
```csharp
public TransactionGroup(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for which this transaction group is being used.

## Remarks
The group does not start until its Start method is called.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

