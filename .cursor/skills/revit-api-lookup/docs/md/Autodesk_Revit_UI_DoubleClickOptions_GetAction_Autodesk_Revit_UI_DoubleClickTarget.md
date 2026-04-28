---
kind: method
id: M:Autodesk.Revit.UI.DoubleClickOptions.GetAction(Autodesk.Revit.UI.DoubleClickTarget)
source: html/ae6b3b31-bb5e-1e0f-ce43-067f2c96e342.htm
---
# Autodesk.Revit.UI.DoubleClickOptions.GetAction Method

Returns the active user's desired action for a particular double-click target.

## Syntax (C#)
```csharp
public DoubleClickAction GetAction(
	DoubleClickTarget target
)
```

## Parameters
- **target** (`Autodesk.Revit.UI.DoubleClickTarget`) - The target to check.

## Returns
The user's desired action for the specified target.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

