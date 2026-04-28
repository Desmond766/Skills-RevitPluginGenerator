---
kind: method
id: M:Autodesk.Revit.DB.View.DisableTemporaryViewMode(Autodesk.Revit.DB.TemporaryViewMode)
zh: 视图
source: html/e87fc993-5dc8-bb39-b7a7-fe91d075489a.htm
---
# Autodesk.Revit.DB.View.DisableTemporaryViewMode Method

**中文**: 视图

Disables the specified temporary view mode.

## Syntax (C#)
```csharp
public void DisableTemporaryViewMode(
	TemporaryViewMode mode
)
```

## Parameters
- **mode** (`Autodesk.Revit.DB.TemporaryViewMode`) - The mode to disable.

## Remarks
Has no effect if the mode is already disabled.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - View cannot use temporary visibility modes.

