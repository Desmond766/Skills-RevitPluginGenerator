---
kind: method
id: M:Autodesk.Revit.DB.FailuresAccessor.IsFailureResolutionPermitted(Autodesk.Revit.DB.FailureMessageAccessor)
source: html/50296b62-531f-c650-1c16-81d4a891603d.htm
---
# Autodesk.Revit.DB.FailuresAccessor.IsFailureResolutionPermitted Method

Checks if default resolution of the failure is permitted.

## Syntax (C#)
```csharp
public bool IsFailureResolutionPermitted(
	FailureMessageAccessor failure
)
```

## Parameters
- **failure** (`Autodesk.Revit.DB.FailureMessageAccessor`) - The accessor to the failure to be resolved.

## Returns
True if default resolution of the failure is permitted

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - failure has not been properly initialized.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailuresAccessor is inactive (is used outside of failures processing).

