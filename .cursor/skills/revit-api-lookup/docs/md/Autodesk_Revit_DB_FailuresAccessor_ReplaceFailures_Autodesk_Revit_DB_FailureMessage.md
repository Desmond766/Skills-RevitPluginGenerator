---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.ReplaceFailures(Autodesk.Revit.DB.FailureMessage)
source: html/b3377b4f-ea8b-4369-be9c-baaedf183b08.htm
---
# Autodesk.Revit.DB.FailuresAccessor.ReplaceFailures Method

Deletes all failure messages currently posted in a document and replaces them with one "generic" failure.

## Syntax (C#)
```csharp
public void ReplaceFailures(
	FailureMessage failure
)
```

## Parameters
- **failure** (`Autodesk.Revit.DB.FailureMessage`) - FailureMessage that should replace all currently posted messages. It must have severity DocumentCorruption.

## Remarks
If analysis done by Failures Processing code concludes that in a given context delivering
 of the posted failures to the user makes no sense, this method can be used to discard all posted failures
 and substitute one "generic" one, that will be delivered to the user and then transaction
 forced to be aborted.
 After the call, (pre)processing of failures should return ProceedWithRollback.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Severity of failure must be FailureSeverity::DocumentCorruption.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

