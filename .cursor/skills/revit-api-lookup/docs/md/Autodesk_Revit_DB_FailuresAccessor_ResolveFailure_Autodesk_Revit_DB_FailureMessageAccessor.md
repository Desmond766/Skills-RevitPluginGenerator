---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.ResolveFailure(Autodesk.Revit.DB.FailureMessageAccessor)
source: html/ee6c044d-28f4-9cec-c83c-883b604c8a7b.htm
---
# Autodesk.Revit.DB.FailuresAccessor.ResolveFailure Method

Resolves one failure using the failure resolution type last set for it.

## Syntax (C#)
```csharp
public void ResolveFailure(
	FailureMessageAccessor failure
)
```

## Parameters
- **failure** (`Autodesk.Revit.DB.FailureMessageAccessor`) - The accessor to the failure to be resolved.

## Remarks
If failure resolution type was not set, the default failure resolution type will be used.
 After execution of the failure resolution the failure will not be removed from the document automatically. To
 prevent the failure from being delivered to the user, failures (pre)processor should return ProceedWithCommit.
 It will cause failures to be regenerated and failure resolution process to be restarted.
 If attempt to resolve failure was not successful, and the same failure is present on repetitive calls
 of the failures (pre)processor, the preprocessor code should take care to attempt
 a different resolution the next time the failure appears, to avoid an infinite loop.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - failure has not been properly initialized.
 -or-
 failure does not have any resolutions.
 -or-
 Default resolution of failure is not permitted or not applicable.
 -or-
 The failure was already attempted to resolve twice with that resolution type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).
 -or-
 Resolution of failures is not permitted in the current state of the document.

