---
kind: method
id: M:Autodesk.Revit.DB.View.GetFilters
zh: 视图
source: html/a5b3aee3-222c-7e8d-fb63-2034ed8871a0.htm
---
# Autodesk.Revit.DB.View.GetFilters Method

**中文**: 视图

Gets the filters applied to the view.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetFilters()
```

## Returns
The ElementIds of the Filters.

## Remarks
Note that this method returns filters in a set sorted according to their ids.
 To get filters in the order they are applied to the view use GetOrderedFilters () () () .

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

