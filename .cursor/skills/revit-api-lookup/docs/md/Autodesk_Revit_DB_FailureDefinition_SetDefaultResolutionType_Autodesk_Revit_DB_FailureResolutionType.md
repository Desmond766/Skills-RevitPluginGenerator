---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinition.SetDefaultResolutionType(Autodesk.Revit.DB.FailureResolutionType)
source: html/470f5ae7-5c39-f4e6-ad45-f56b0c78f306.htm
---
# Autodesk.Revit.DB.FailureDefinition.SetDefaultResolutionType Method

Sets the default resolution type for the failure.

## Syntax (C#)
```csharp
public FailureDefinition SetDefaultResolutionType(
	FailureResolutionType type
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.FailureResolutionType`) - The type of resolution to be used as default.

## Returns
The FailureDefinition.

## Remarks
If failure has multiple resolutions, one of them is designated as designated as the default resolution. The default resolution
 is used by Revit failure processing mechanism to resolve failures automatically when applicable.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Resolution of the type is not applicable to the failure.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - FailureDefinition does not have any resolutions.

