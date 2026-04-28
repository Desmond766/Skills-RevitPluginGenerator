---
kind: method
id: M:Autodesk.Revit.DB.View.IsFilterApplied(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/a3e3590c-a990-be11-9478-693efc3579f6.htm
---
# Autodesk.Revit.DB.View.IsFilterApplied Method

**中文**: 视图

Indicates if a filter is applied to the view.

## Syntax (C#)
```csharp
public bool IsFilterApplied(
	ElementId filterElementId
)
```

## Parameters
- **filterElementId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the filter.

## Returns
True if the filter is applied to the view, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - ElementId is not associated with a FilterElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

