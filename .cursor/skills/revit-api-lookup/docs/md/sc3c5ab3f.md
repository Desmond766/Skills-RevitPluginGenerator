---
kind: method
id: M:Autodesk.Revit.DB.FailureHandlingOptions.SetClearAfterRollback(System.Boolean)
source: html/bebe6efd-b05f-7a0b-4cc3-609ec35be42c.htm
---
# Autodesk.Revit.DB.FailureHandlingOptions.SetClearAfterRollback Method

Sets a flag indicating that Revit should clear all posted failures silently when the failing transaction is being rolled back intentionally. If
 not set, the failures may still be displayed to the user during rollback.

## Syntax (C#)
```csharp
public FailureHandlingOptions SetClearAfterRollback(
	bool bFlag
)
```

## Parameters
- **bFlag** (`System.Boolean`) - True to clear posted failures silently if the transaction is being rolled back, false to keep these failures in place (they may be displayed to the user).

## Returns
This FailureHandlingOptions object.

