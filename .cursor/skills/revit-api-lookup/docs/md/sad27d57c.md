---
kind: method
id: M:Autodesk.Revit.DB.View.AddFilter(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/eb21e133-38b0-5be7-8e81-5af8df37bb8c.htm
---
# Autodesk.Revit.DB.View.AddFilter Method

**中文**: 视图

Adds a filter to the view.

## Syntax (C#)
```csharp
public void AddFilter(
	ElementId filterElementId
)
```

## Parameters
- **filterElementId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the filter.

## Remarks
The filter will be added with default overrides, which means that there will be no change in the view's display.
 The filter is appended as the last filter in the order of filters applied to this view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - ElementId is not associated with a FilterElement.
 -or-
 Filter is already applied to the view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

