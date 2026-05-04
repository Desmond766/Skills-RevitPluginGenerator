---
kind: method
id: M:Autodesk.Revit.DB.View.GetFilterOverrides(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/764e7bf7-a852-95a3-4183-dc52a1caccaf.htm
---
# Autodesk.Revit.DB.View.GetFilterOverrides Method

**中文**: 视图

Gets graphic overrides that a filter applies to the view.

## Syntax (C#)
```csharp
public OverrideGraphicSettings GetFilterOverrides(
	ElementId filterElementId
)
```

## Parameters
- **filterElementId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the filter.

## Returns
Object representing all graphic overrides of the filter in the view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - ElementId is not associated with a FilterElement.
 -or-
 Filter is not applied to the view.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

