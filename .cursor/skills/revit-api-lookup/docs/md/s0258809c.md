---
kind: method
id: M:Autodesk.Revit.DB.View.GetFilterVisibility(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/15cd78f5-4c67-135e-eff7-f28622b636c5.htm
---
# Autodesk.Revit.DB.View.GetFilterVisibility Method

**中文**: 视图

Gets the visibility of the elements associated with a filter.

## Syntax (C#)
```csharp
public bool GetFilterVisibility(
	ElementId filterElementId
)
```

## Parameters
- **filterElementId** (`Autodesk.Revit.DB.ElementId`) - The ElementId of the filter.

## Returns
True if the elements associated with the filter are visible in the view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Filter is not applied to the view.
 -or-
 ElementId is not associated with a FilterElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

