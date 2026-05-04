---
kind: method
id: M:Autodesk.Revit.DB.View.IsInTemporaryViewMode(Autodesk.Revit.DB.TemporaryViewMode)
zh: 视图
source: html/186e5c4f-d64b-3541-be6a-90c3b651ad67.htm
---
# Autodesk.Revit.DB.View.IsInTemporaryViewMode Method

**中文**: 视图

Returns true if the view is in a particular temporary view mode.

## Syntax (C#)
```csharp
public bool IsInTemporaryViewMode(
	TemporaryViewMode mode
)
```

## Parameters
- **mode** (`Autodesk.Revit.DB.TemporaryViewMode`) - The mode.

## Returns
True if this view is in the temporary view mode indicated, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

