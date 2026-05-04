---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.GetFailureMessages(Autodesk.Revit.DB.FailureSeverity)
source: html/1a24ee05-1057-4638-0b15-1a0f0ef0c21d.htm
---
# Autodesk.Revit.DB.FailuresAccessor.GetFailureMessages Method

Provides access to the individual failure messages if a given severity currently posted in the document.

## Syntax (C#)
```csharp
public IList<FailureMessageAccessor> GetFailureMessages(
	FailureSeverity severity
)
```

## Parameters
- **severity** (`Autodesk.Revit.DB.FailureSeverity`) - The failure severity for which failure messages are requested.
 If the requested severity is None, an empty collection is returned.

## Returns
Accessors to the individual failure messages of a given severity posted in the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

