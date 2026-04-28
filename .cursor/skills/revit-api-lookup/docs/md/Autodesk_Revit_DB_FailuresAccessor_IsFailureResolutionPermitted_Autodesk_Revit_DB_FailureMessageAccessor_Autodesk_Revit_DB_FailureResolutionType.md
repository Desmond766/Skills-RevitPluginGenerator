---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.IsFailureResolutionPermitted(Autodesk.Revit.DB.FailureMessageAccessor,Autodesk.Revit.DB.FailureResolutionType)
source: html/72c298ca-57c1-b008-3dcd-21f88eb47ab1.htm
---
# Autodesk.Revit.DB.FailuresAccessor.IsFailureResolutionPermitted Method

Checks if resolution of the failure using given resolution type is permitted.

## Syntax (C#)
```csharp
public bool IsFailureResolutionPermitted(
	FailureMessageAccessor failure,
	FailureResolutionType resolutionType
)
```

## Parameters
- **failure** (`Autodesk.Revit.DB.FailureMessageAccessor`) - Accessor to the failure to be resolved.
- **resolutionType** (`Autodesk.Revit.DB.FailureResolutionType`) - Type of the failure resolution to be used.

## Returns
True if resolution of the failure using given resolution type is permitted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - failure has not been properly initialized.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

