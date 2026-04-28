---
kind: method
id: M:Autodesk.Revit.DB.FailureMessageAccessor.HasResolutionOfType(Autodesk.Revit.DB.FailureResolutionType)
source: html/16a4653e-b496-c0b6-022c-543c15f689ef.htm
---
# Autodesk.Revit.DB.FailureMessageAccessor.HasResolutionOfType Method

Checks if failure has a resolution of a given type.

## Syntax (C#)
```csharp
public bool HasResolutionOfType(
	FailureResolutionType type
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.FailureResolutionType`) - The type of resolution.

## Returns
True if failure has a resolution of a given type, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessageAccessor has not been properly initialized.

