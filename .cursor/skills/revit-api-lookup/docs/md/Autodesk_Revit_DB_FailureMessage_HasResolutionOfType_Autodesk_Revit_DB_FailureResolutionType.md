---
kind: method
id: M:Autodesk.Revit.DB.FailureMessage.HasResolutionOfType(Autodesk.Revit.DB.FailureResolutionType)
source: html/c92a23ac-71ac-3383-f458-489b557f085e.htm
---
# Autodesk.Revit.DB.FailureMessage.HasResolutionOfType Method

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
True if the failure has a type of resolutions, else false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

