---
kind: method
id: M:Autodesk.Revit.DB.View.SetIsFilterEnabled(Autodesk.Revit.DB.ElementId,System.Boolean)
zh: 视图
source: html/b1e1e063-d90d-7e2a-57e6-de7947dd0a9a.htm
---
# Autodesk.Revit.DB.View.SetIsFilterEnabled Method

**中文**: 视图

Sets the filter enabled flag.

## Syntax (C#)
```csharp
public void SetIsFilterEnabled(
	ElementId filterElementId,
	bool enable
)
```

## Parameters
- **filterElementId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the filter.
- **enable** (`System.Boolean`) - True if the specified filter should be enabled in this view, false otherwise.

## Remarks
Several filters can be applied to a view in a sertain order. This enable/disable flag
 allows one to quickly turn on/off the action of a particular filter in this view (without
 removing the filter from the set of applied filters and loosing the corresponding overrides).
 By default, all the filters applied to a view are enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Filter is not applied to the view.
 -or-
 ElementId is not associated with a FilterElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

