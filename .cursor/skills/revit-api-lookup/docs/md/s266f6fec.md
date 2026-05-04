---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.ResolveFailures(System.Collections.Generic.IList{Autodesk.Revit.DB.FailureMessageAccessor})
source: html/1a14a55b-ae8c-4cca-de65-51e2a1d24c9c.htm
---
# Autodesk.Revit.DB.FailuresAccessor.ResolveFailures Method

Resolves one or more failures using last set failure resolution type for each of the failures.
 If failure resolution type was not set for some of failures, default failure resolution type will be used.

## Syntax (C#)
```csharp
public void ResolveFailures(
	IList<FailureMessageAccessor> failures
)
```

## Parameters
- **failures** (`System.Collections.Generic.IList < FailureMessageAccessor >`) - The accessors to the failures to be resolved.

## Remarks
After execution of the failure resolutions the failures will not be removed from the document automatically. To
 prevent failure from being delivered to the user, failures (pre)processor should return ProceedWithCommit.
 It will cause failures to be regenerated and failure resolution process to be restarted.
 If attempt to resolve failure was not successful, and the same failure is present on repetitive calls
 of the failures (pre)processor, the preprocessor code should take care to attempt
 a different resolution the next time the failure appears, to avoid an infinite loop.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Default resolution of one of the failures is not permitted or not applicable.
 -or-
 One of the failures was already attempted to resolve twice with that resolution type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).
 -or-
 Resolution of failures is not permitted in the current state of the document.

