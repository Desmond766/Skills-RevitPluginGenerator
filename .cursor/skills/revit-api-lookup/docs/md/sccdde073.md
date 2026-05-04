---
kind: method
id: M:Autodesk.Revit.DB.TransactWithCentralOptions.SetLockCallback(Autodesk.Revit.DB.ICentralLockedCallback)
source: html/0abe0739-691f-f229-6d5f-bea73b20a698.htm
---
# Autodesk.Revit.DB.TransactWithCentralOptions.SetLockCallback Method

Sets or resets a callback object that would allow an external application to change Revit's default behavior of endlessly waiting and repeatedly trying to lock a central model.

## Syntax (C#)
```csharp
public void SetLockCallback(
	ICentralLockedCallback lockCallback
)
```

## Parameters
- **lockCallback** (`Autodesk.Revit.DB.ICentralLockedCallback`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

