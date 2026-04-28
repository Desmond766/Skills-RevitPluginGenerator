---
kind: method
id: M:Autodesk.Revit.DB.TemporaryViewModes.IsModeEnabled(Autodesk.Revit.DB.TemporaryViewMode)
source: html/e1b1ad8e-9cee-1969-441d-a8f567874cff.htm
---
# Autodesk.Revit.DB.TemporaryViewModes.IsModeEnabled Method

Tests whether a temporary view mode is currently enabled in the associated view.

## Syntax (C#)
```csharp
public bool IsModeEnabled(
	TemporaryViewMode mode
)
```

## Parameters
- **mode** (`Autodesk.Revit.DB.TemporaryViewMode`) - The mode to evaluate

## Returns
True if the requested mode is available and enabled in the associated view; False otherwise.

## Remarks
Most of temporary modes are enabled in a specific context only.
 A programmer who wants to use a mode needs to first test whether
 it is currently available and enabled, or not.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

