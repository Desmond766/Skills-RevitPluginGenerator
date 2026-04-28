---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.GetTransactionName
source: html/b7ace76a-4b1e-d175-e04c-b20bf57b38ea.htm
---
# Autodesk.Revit.DB.FailuresAccessor.GetTransactionName Method

Retrieves the name of the transaction for which failures are being processed.

## Syntax (C#)
```csharp
public string GetTransactionName()
```

## Returns
The name of the transaction for which failures are being processed.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

