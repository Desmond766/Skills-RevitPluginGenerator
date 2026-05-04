---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinition.IsResolutionApplicable(Autodesk.Revit.DB.FailureResolutionType)
source: html/cc88de5e-724f-e28c-f053-1e29ffa0afd0.htm
---
# Autodesk.Revit.DB.FailureDefinition.IsResolutionApplicable Method

Checks if the given resolution type is applicable to the failure.

## Syntax (C#)
```csharp
public bool IsResolutionApplicable(
	FailureResolutionType type
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.FailureResolutionType`) - The resolution type to check.

## Returns
True if the given resolution type is applicable to the failure, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

