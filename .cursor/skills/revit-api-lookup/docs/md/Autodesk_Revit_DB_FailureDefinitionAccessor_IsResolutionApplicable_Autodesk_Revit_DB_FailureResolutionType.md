---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinitionAccessor.IsResolutionApplicable(Autodesk.Revit.DB.FailureResolutionType)
source: html/602fa55c-4e41-b89b-89b2-7bab78a75a83.htm
---
# Autodesk.Revit.DB.FailureDefinitionAccessor.IsResolutionApplicable Method

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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FailureDefinitionAccessor has not been properly initialized.

