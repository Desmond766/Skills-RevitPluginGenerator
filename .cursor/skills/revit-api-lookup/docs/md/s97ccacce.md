---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.IsPending
source: html/7d67bf43-a961-de7f-fa6e-17d8eb4d2a63.htm
---
# Autodesk.Revit.DB.FailuresAccessor.IsPending Method

Checks if the failure processing is pending.

## Syntax (C#)
```csharp
public bool IsPending()
```

## Returns
True if the failures processing is in the pending state.

## Remarks
The failure processing is pending after failures processor has returned WaitForUserInput
 and until pending state is finished by either committing or rolling back of the pending transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

