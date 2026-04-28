---
kind: method
id: M:Autodesk.Revit.DB.View.RemoveFilter(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/073a4884-30b4-965f-ae11-db1123e7eb0a.htm
---
# Autodesk.Revit.DB.View.RemoveFilter Method

**中文**: 视图

Removes a filter from the view.

## Syntax (C#)
```csharp
public void RemoveFilter(
	ElementId filterElementId
)
```

## Parameters
- **filterElementId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the filter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Filter is not applied to the view.
 -or-
 ElementId is not associated with a FilterElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

