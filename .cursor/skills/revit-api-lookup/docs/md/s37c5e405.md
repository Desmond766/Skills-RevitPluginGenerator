---
kind: method
id: M:Autodesk.Revit.DB.TemporaryViewModes.IsModeAvailable(Autodesk.Revit.DB.TemporaryViewMode)
source: html/c5f8afb6-23aa-1c3f-c637-8cf2e3d09239.htm
---
# Autodesk.Revit.DB.TemporaryViewModes.IsModeAvailable Method

Tests whether a temporary view mode is currently available in the associated view.

## Syntax (C#)
```csharp
public bool IsModeAvailable(
	TemporaryViewMode mode
)
```

## Parameters
- **mode** (`Autodesk.Revit.DB.TemporaryViewMode`) - The mode to evaluate

## Returns
True of the temporary mode is currently available in the associated view.

## Remarks
Not every mode is available in all views at all times.
 Some of the modes are only available in certain views,
 or only at certain time/context. Modes that are not available
 will not be visible on the view's tool bar in the UI. Even modes that are available do not have to be currently
 enabled in the current context. Before using a mode its
 applicability should be tested by calling
 IsModeEnabled(TemporaryViewMode) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

