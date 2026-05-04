---
kind: method
id: M:Autodesk.Revit.DB.View.GetOrderedFilters
zh: 视图
source: html/0de769ec-9c15-435e-95dc-6dcf439bbf15.htm
---
# Autodesk.Revit.DB.View.GetOrderedFilters Method

**中文**: 视图

Gets the filters applied to the view in the order they are applied.

## Syntax (C#)
```csharp
public IList<ElementId> GetOrderedFilters()
```

## Returns
The ElementIds of the Filters.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

