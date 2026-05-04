---
kind: method
id: M:Autodesk.Revit.DB.TemporaryViewModes.DeactivateMode(Autodesk.Revit.DB.TemporaryViewMode)
source: html/a260a05e-3c58-6d09-901d-a99dfb39186b.htm
---
# Autodesk.Revit.DB.TemporaryViewModes.DeactivateMode Method

Deactivates the given temporary mode.

## Syntax (C#)
```csharp
public void DeactivateMode(
	TemporaryViewMode mode
)
```

## Parameters
- **mode** (`Autodesk.Revit.DB.TemporaryViewMode`) - The mode to deactivate

## Remarks
The method has no effect on modes that are already deactivated.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The temporary mode is not available in the associated view.
 The view is either of a type that does not support this mode,
 or is currently in a context that makes the mode presently inapplicable.
 -or-
 The temporary mode is presently not enabled in the associated view.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

