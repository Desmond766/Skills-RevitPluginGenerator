---
kind: method
id: M:Autodesk.Revit.DB.ICentralLockedCallback.ShouldWaitForLockAvailability
source: html/47b521ec-406b-7049-25f1-7b593d02ddb7.htm
---
# Autodesk.Revit.DB.ICentralLockedCallback.ShouldWaitForLockAvailability Method

Returns whether Revit should wait and try again to acquire the lock on central.

## Syntax (C#)
```csharp
bool ShouldWaitForLockAvailability()
```

## Returns
True means wait and try again later. False means immediately give up.

