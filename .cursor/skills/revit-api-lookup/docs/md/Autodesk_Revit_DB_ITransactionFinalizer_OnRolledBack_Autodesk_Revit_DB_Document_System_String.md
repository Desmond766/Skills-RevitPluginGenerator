---
kind: method
id: M:Autodesk.Revit.DB.ITransactionFinalizer.OnRolledBack(Autodesk.Revit.DB.Document,System.String)
source: html/8c12024d-2de2-ad2b-d3e0-14a1d79bbdcb.htm
---
# Autodesk.Revit.DB.ITransactionFinalizer.OnRolledBack Method

This method is called at the end of rolling back a transaction

## Syntax (C#)
```csharp
void OnRolledBack(
	Document document,
	string strTransactionName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document associated with the transaction
- **strTransactionName** (`System.String`) - The transaction's name

