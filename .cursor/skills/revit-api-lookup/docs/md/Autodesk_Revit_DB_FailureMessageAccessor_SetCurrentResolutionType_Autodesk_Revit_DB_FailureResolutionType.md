---
kind: method
id: M:Autodesk.Revit.DB.FailureMessageAccessor.SetCurrentResolutionType(Autodesk.Revit.DB.FailureResolutionType)
source: html/079ec918-e752-32e4-e776-79aaa0f33fad.htm
---
# Autodesk.Revit.DB.FailureMessageAccessor.SetCurrentResolutionType Method

Sets the type of a resolution to be used to resolve the failure.

## Syntax (C#)
```csharp
public void SetCurrentResolutionType(
	FailureResolutionType resolutionType
)
```

## Parameters
- **resolutionType** (`Autodesk.Revit.DB.FailureResolutionType`) - The type of failure resolution to be used to resolve the failure.

## Remarks
When FailuresAccessor is used to resolve failures, it will execute resolutions based on current resolution type.
 If no current resolution type is set, the default resolution type will be used.
 Setting is performed on the FailureMessageAccessor object itself, so if there are several accessors issued
 for the same FailureMessage, setting of the resolution type performed on one of them does not impact the others.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This FailureMessageAccessor has no resolution of resolutionType.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This FailureMessageAccessor has not been properly initialized.
 -or-
 This FailureMessageAccessor does not have any resolutions.

