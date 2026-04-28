---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinition.GetResolutionCaption(Autodesk.Revit.DB.FailureResolutionType)
source: html/f1d8c4e5-f1d8-4a68-6f95-612e405fe95a.htm
---
# Autodesk.Revit.DB.FailureDefinition.GetResolutionCaption Method

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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - FailureDefinition does not have any resolutions.

