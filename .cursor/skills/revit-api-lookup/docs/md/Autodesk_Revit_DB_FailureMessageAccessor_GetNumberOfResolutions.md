---
kind: method
id: M:Autodesk.Revit.DB.FailureMessageAccessor.GetNumberOfResolutions
source: html/9a71ec91-78de-6cd4-f99d-7960eba77652.htm
---
# Autodesk.Revit.DB.FailureMessageAccessor.GetNumberOfResolutions Method

Retrieves number of resolutions that can be used to resolve failure.

## Syntax (C#)
```csharp
public int GetNumberOfResolutions()
```

## Returns
Number of resolutions that can be used to resolve failure

## Remarks
If number of resolutions is zero, the failure cannot be resolved. If severity of the failure is Warning,
 it can be deleted. Otherwise, the only option is to cancel current operation and roll back the transaction

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessageAccessor has not been properly initialized.

