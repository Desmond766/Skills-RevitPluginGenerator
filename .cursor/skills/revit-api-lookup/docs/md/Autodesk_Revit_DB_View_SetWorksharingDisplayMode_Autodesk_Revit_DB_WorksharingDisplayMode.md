---
kind: method
id: M:Autodesk.Revit.DB.View.SetWorksharingDisplayMode(Autodesk.Revit.DB.WorksharingDisplayMode)
zh: 视图
source: html/08a88bf1-45a8-1790-dda5-2ca69a3f9046.htm
---
# Autodesk.Revit.DB.View.SetWorksharingDisplayMode Method

**中文**: 视图

Sets the worksharing display mode for this view.

## Syntax (C#)
```csharp
public void SetWorksharingDisplayMode(
	WorksharingDisplayMode displayMode
)
```

## Parameters
- **displayMode** (`Autodesk.Revit.DB.WorksharingDisplayMode`) - The desired display mode. "Off" will turn off all worksharing display modes.

## Remarks
Turning on a worksharing display mode will disable other temporary view modes such as
 reveal hidden elements and temporary hide/isolate.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This View does not support the requested worksharing display mode.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

