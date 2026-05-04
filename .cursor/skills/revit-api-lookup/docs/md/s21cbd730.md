---
kind: method
id: M:Autodesk.Revit.DB.FailureHandlingOptions.SetDelayedMiniWarnings(System.Boolean)
source: html/33d67b2b-fed4-e37f-1d77-ee79fb34315b.htm
---
# Autodesk.Revit.DB.FailureHandlingOptions.SetDelayedMiniWarnings Method

Sets a flag indicating if Revit should delay the display of the mini-warning dialog (if one is to be shown as a result of warnings in the current transaction)
 until the end of the next transaction.

## Syntax (C#)
```csharp
public FailureHandlingOptions SetDelayedMiniWarnings(
	bool bFlag
)
```

## Parameters
- **bFlag** (`System.Boolean`) - True to delay the display of the mini-warning dialog until the end of the next transation, false to display them as this transaction is completed.

## Returns
This FailureHandlingOptions object.

## Remarks
This controls warnings suitable for the mini-warnings dialog only. If the modal flag is set to true
 with SetForcedModalHandling(Boolean) then this flag will be ignored.

