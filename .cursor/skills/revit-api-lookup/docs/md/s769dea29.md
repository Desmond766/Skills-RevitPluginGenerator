---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinitionAccessor.SetDefaultResolutionType(Autodesk.Revit.DB.FailureResolutionType)
source: html/96ccbd45-3644-8fad-b739-d2be0c3e2641.htm
---
# Autodesk.Revit.DB.FailureDefinitionAccessor.SetDefaultResolutionType Method

Sets the default resolution type for the failure.

## Syntax (C#)
```csharp
public void SetDefaultResolutionType(
	FailureResolutionType type
)
```

## Parameters
- **type** (`Autodesk.Revit.DB.FailureResolutionType`) - The type of resolution to be used as default.

## Remarks
If failure has multiple resolutions, one of them is designated as designated as the default resolution. The default resolution
 is used by Revit failure processing mechanism to resolve failures automatically when applicable.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Resolution of the type is not applicable to the failure.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The FailureDefinitionAccessor has not been properly initialized.
 -or-
 FailureDefinition does not have any resolutions.

