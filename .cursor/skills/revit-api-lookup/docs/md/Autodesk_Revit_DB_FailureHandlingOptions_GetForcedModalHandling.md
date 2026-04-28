---
kind: method
id: M:Autodesk.Revit.DB.FailureHandlingOptions.GetForcedModalHandling
source: html/e626a974-17fb-3919-ceda-8470a62489f8.htm
---
# Autodesk.Revit.DB.FailureHandlingOptions.GetForcedModalHandling Method

Obtains the flag indicating if the error handling dialog shown at the end of the failing transaction should be modal.

## Syntax (C#)
```csharp
public bool GetForcedModalHandling()
```

## Returns
True if the options force Revit to use a modal error dialog, false if it allows use of a non-blocking dialog for warnings resulting from this transaction.

