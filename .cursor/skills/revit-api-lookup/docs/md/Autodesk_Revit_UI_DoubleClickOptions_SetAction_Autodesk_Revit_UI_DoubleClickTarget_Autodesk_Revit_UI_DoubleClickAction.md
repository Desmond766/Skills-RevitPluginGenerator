---
kind: method
id: M:Autodesk.Revit.UI.DoubleClickOptions.SetAction(Autodesk.Revit.UI.DoubleClickTarget,Autodesk.Revit.UI.DoubleClickAction)
source: html/38c11a01-5b36-388c-7769-4d1d7a75d18d.htm
---
# Autodesk.Revit.UI.DoubleClickOptions.SetAction Method

Changes the double-click action associated with a specified target.

## Syntax (C#)
```csharp
public void SetAction(
	DoubleClickTarget target,
	DoubleClickAction action
)
```

## Parameters
- **target** (`Autodesk.Revit.UI.DoubleClickTarget`) - The double-click target whose action will be changed.
- **action** (`Autodesk.Revit.UI.DoubleClickAction`) - The action to assign to the target.

## Remarks
This change will be stored in the user's profile and will affect future sessions of Revit in
 addition to the current session.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The specified action is not valid for the target element.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

