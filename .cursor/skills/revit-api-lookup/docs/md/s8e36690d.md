---
kind: method
id: M:Autodesk.Revit.DB.FailureHandlingOptions.GetDelayedMiniWarnings
source: html/eaf8ff93-66ec-1e39-f067-1a12de150106.htm
---
# Autodesk.Revit.DB.FailureHandlingOptions.GetDelayedMiniWarnings Method

Obtains the flag indicating if showing of mini-warning dialog should be delayed until the end of next transaction.

## Syntax (C#)
```csharp
public bool GetDelayedMiniWarnings()
```

## Returns
True to delay the display of the mini-warning dialog until the end of the next transation, false to display them as this transaction is completed.

