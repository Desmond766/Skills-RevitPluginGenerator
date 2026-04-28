---
kind: method
id: M:Autodesk.Revit.DB.View.GetIsFilterEnabled(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/0643b3a4-2f3e-e7ca-9070-a3f2c67b22e9.htm
---
# Autodesk.Revit.DB.View.GetIsFilterEnabled Method

**中文**: 视图

Identifies if the filter is enabled in this view.

## Syntax (C#)
```csharp
public bool GetIsFilterEnabled(
	ElementId filterElementId
)
```

## Parameters
- **filterElementId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the filter.

## Returns
True if the specified filter is enabled in this view, false otherwise.

## Remarks
Several filters can be applied to a view in a certain order. This enable/disable flag
 allows one to quickly turn on/off the action of a particular filter in this view (without
 removing the filter from the set of applied filters and losing the corresponding overrides).
 By default, all the filters applied to a view are enabled.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Filter is not applied to the view.
 -or-
 ElementId is not associated with a FilterElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

