---
kind: method
id: M:Autodesk.Revit.DB.ITransactionFinalizer.OnCommitted(Autodesk.Revit.DB.Document,System.String)
source: html/6ab3e635-5912-5aa2-09e0-1eb3c0dc54bc.htm
---
# Autodesk.Revit.DB.ITransactionFinalizer.OnCommitted Method

This method is called at the end of committing a transaction

## Syntax (C#)
```csharp
void OnCommitted(
	Document document,
	string strTransactionName
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document associated with the transaction
- **strTransactionName** (`System.String`) - The transaction's name

