---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.SetFailureHandlingOptions(Autodesk.Revit.DB.FailureHandlingOptions)
source: html/365c5204-4374-4ddc-6ccb-9d11d2926897.htm
---
# Autodesk.Revit.DB.FailuresAccessor.SetFailureHandlingOptions Method

Sets failure handling options for the transaction currently being finished.

## Syntax (C#)
```csharp
public void SetFailureHandlingOptions(
	FailureHandlingOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.FailureHandlingOptions`) - The failure handling options to be set for the transaction currently being finished.

## Remarks
If used with returning ProceedWithRollback from (pre)processing, allows to dismiss errors and roll back transaction
 without any further failures processing and silently for the user.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

