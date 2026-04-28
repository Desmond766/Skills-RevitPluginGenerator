---
kind: method
id: M:Autodesk.Revit.DB.FailureHandlingOptions.GetClearAfterRollback
source: html/cfa3ef0e-1af9-50b9-ef23-e98418df860b.htm
---
# Autodesk.Revit.DB.FailureHandlingOptions.GetClearAfterRollback Method

Obtains the flag indicating if all posted failures should be removed silently when transaction is being rolled back.

## Syntax (C#)
```csharp
public bool GetClearAfterRollback()
```

## Returns
True to clear posted failures silently if the transaction is being rolled back, false to keep these failures in place (they may be displayed to the user).

