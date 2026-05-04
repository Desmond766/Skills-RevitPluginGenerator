---
kind: method
id: M:Autodesk.Revit.DB.TemporaryViewModes.IsValidState(Autodesk.Revit.DB.PreviewFamilyVisibilityMode)
source: html/58a050cd-be15-c5f6-fb03-8bd16462faee.htm
---
# Autodesk.Revit.DB.TemporaryViewModes.IsValidState Method

Tests whether the given state is valid for the associated view and the context the view is currently in.

## Syntax (C#)
```csharp
public bool IsValidState(
	PreviewFamilyVisibilityMode state
)
```

## Parameters
- **state** (`Autodesk.Revit.DB.PreviewFamilyVisibilityMode`) - A state of the PreviewFamilyVisibilityMode

## Returns
Returns True if the state is applicable for the view; False otherwise.

## Remarks
As long as the PreviewFamilyVisibility mode is available and enabled in the associated view,
 the Off and On states are always valid. However, the Uncut state is only
 valid in plan views and reflected ceilings.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

