---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.PostWarning(Autodesk.Revit.DB.FailureMessage)
source: html/03cf479f-e57d-4fd5-79e6-557b274a7489.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.PostWarning Method

Reports a problem detected during execution of a rule.

## Syntax (C#)
```csharp
public void PostWarning(
	FailureMessage message
)
```

## Parameters
- **message** (`Autodesk.Revit.DB.FailureMessage`) - Warning describing the problem detected by a rule.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The message must have severity "warning".
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Performance advisor is not executing rules.

