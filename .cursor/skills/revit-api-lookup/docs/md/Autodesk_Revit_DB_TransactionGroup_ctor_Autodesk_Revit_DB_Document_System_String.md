---
kind: method
id: M:Autodesk.Revit.DB.TransactionGroup.#ctor(Autodesk.Revit.DB.Document,System.String)
source: html/bc63bb0d-fc22-9419-cec9-ea8c92b368b6.htm
---
# Autodesk.Revit.DB.TransactionGroup.#ctor Method

It constructs a transaction group object

## Syntax (C#)
```csharp
public TransactionGroup(
	Document document,
	string transGroupName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document for which this transaction group is being used.
- **transGroupName** (`System.String`) - Name of the group.
 The name will be used only for a group that is assimilated at the end.

## Remarks
The group does not start until its Start method is called.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

