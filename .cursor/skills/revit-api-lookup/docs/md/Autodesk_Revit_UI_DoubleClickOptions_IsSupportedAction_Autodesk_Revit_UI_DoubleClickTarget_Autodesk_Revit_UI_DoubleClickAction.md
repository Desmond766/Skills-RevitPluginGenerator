---
kind: method
id: M:Autodesk.Revit.UI.DoubleClickOptions.IsSupportedAction(Autodesk.Revit.UI.DoubleClickTarget,Autodesk.Revit.UI.DoubleClickAction)
source: html/201515d4-8066-5d02-33ab-9b0b3578ec56.htm
---
# Autodesk.Revit.UI.DoubleClickOptions.IsSupportedAction Method

Checks whether the specified double-click target supports the specified action.

## Syntax (C#)
```csharp
public bool IsSupportedAction(
	DoubleClickTarget target,
	DoubleClickAction action
)
```

## Parameters
- **target** (`Autodesk.Revit.UI.DoubleClickTarget`) - The double-click target to check.
- **action** (`Autodesk.Revit.UI.DoubleClickAction`) - The desired double-click action.

## Returns
True if the target supports the specified action, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

