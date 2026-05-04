---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.JournalFailures(System.Collections.Generic.IList{Autodesk.Revit.DB.FailureMessageAccessor})
source: html/a8638703-bf49-d2c5-fa4f-477ec919d854.htm
---
# Autodesk.Revit.DB.FailuresAccessor.JournalFailures Method

Allows to record information about failures in the journal.

## Syntax (C#)
```csharp
public void JournalFailures(
	IList<FailureMessageAccessor> failures
)
```

## Parameters
- **failures** (`System.Collections.Generic.IList < FailureMessageAccessor >`) - Accessors to the failures to journal.

## Remarks
Records information about failure messages and elements involved in the failures.
 If this method not invoked, journal does not contain any information about failures
 resolved by (pre)processing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

