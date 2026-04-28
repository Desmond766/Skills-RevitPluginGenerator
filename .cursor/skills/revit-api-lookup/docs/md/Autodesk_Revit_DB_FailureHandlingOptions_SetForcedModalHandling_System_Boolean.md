---
kind: method
id: M:Autodesk.Revit.DB.FailureHandlingOptions.SetForcedModalHandling(System.Boolean)
source: html/ce01ea28-ccb4-0943-33ba-3fe39dc76f8c.htm
---
# Autodesk.Revit.DB.FailureHandlingOptions.SetForcedModalHandling Method

Sets a flag indicating whether Revit will show a modal (blocking) error dialog if the transaction failed to finish.

## Syntax (C#)
```csharp
public FailureHandlingOptions SetForcedModalHandling(
	bool bFlag
)
```

## Parameters
- **bFlag** (`System.Boolean`) - True to force Revit to use a modal error dialog, false to allow a non-blocking dialog for warnings resulting from this transaction.

## Returns
This FailureHandlingOptions object.

