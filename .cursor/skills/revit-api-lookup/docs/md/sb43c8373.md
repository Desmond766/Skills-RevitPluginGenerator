---
kind: method
id: M:Autodesk.Revit.DB.View.SupportsWorksharingDisplayMode(Autodesk.Revit.DB.WorksharingDisplayMode)
zh: 视图
source: html/08014919-2575-ad5e-291a-9c4da6c664c8.htm
---
# Autodesk.Revit.DB.View.SupportsWorksharingDisplayMode Method

**中文**: 视图

Checks whether this view supports the given worksharing display mode.

## Syntax (C#)
```csharp
public bool SupportsWorksharingDisplayMode(
	WorksharingDisplayMode mode
)
```

## Parameters
- **mode** (`Autodesk.Revit.DB.WorksharingDisplayMode`) - The mode of interest.

## Returns
Returns True if this view is a graphical view in a workshared document or if the desired mode is Off.
 Returns False if this view is a non-graphical view (such as a schedule or the project browser)
 or if this view is not in a workshared document.

## Remarks
For convenience, the "Off" mode is always supported.
 Other display modes are supported by graphical views in workshared documents.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

