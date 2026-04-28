---
kind: method
id: M:Autodesk.Revit.DB.View.IsElementVisibleInTemporaryViewMode(Autodesk.Revit.DB.TemporaryViewMode,Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/19485349-5825-21da-f75e-6e9b07546b61.htm
---
# Autodesk.Revit.DB.View.IsElementVisibleInTemporaryViewMode Method

**中文**: 视图

Identifies if the input element is visible for the temporary view mode for this view.

## Syntax (C#)
```csharp
public bool IsElementVisibleInTemporaryViewMode(
	TemporaryViewMode mode,
	ElementId id
)
```

## Parameters
- **mode** (`Autodesk.Revit.DB.TemporaryViewMode`) - The temporary view mode. Only TemporaryHideIsolate and AnalyticalModel modes are supported
 by this option. Other modes will result in an exception.
- **id** (`Autodesk.Revit.DB.ElementId`) - The element id.

## Returns
True if the element is visible, false if the element is hidden in the view mode.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This view mode is not supported for checking element visibility.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

