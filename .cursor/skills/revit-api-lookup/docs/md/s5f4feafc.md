---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinitionAccessor.GetResolutionCaption(Autodesk.Revit.DB.FailureResolutionType)
source: html/2f446ef4-c568-8081-a33c-2bc0e6291484.htm
---
# Autodesk.Revit.DB.FailureDefinitionAccessor.GetResolutionCaption Method

Retrieves the caption for a specific resolution type.

## Syntax (C#)
```csharp
public string GetResolutionCaption(
	FailureResolutionType type
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.FailureResolutionType`) - The resolution type.

## Returns
The caption of the resolution.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Resolution of the type is not applicable to the failure.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FailureDefinitionAccessor has not been properly initialized.
 -or-
 FailureDefinition does not have any resolutions.

