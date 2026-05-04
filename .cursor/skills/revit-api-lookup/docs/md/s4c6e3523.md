---
kind: method
id: M:Autodesk.Revit.DB.View.GetElementOverrides(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/af0a58fc-7bdf-02fb-4a20-944ffbe9057b.htm
---
# Autodesk.Revit.DB.View.GetElementOverrides Method

**中文**: 视图

Gets graphic overrides for an element in the view.

## Syntax (C#)
```csharp
public OverrideGraphicSettings GetElementOverrides(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The element.

## Returns
An object representing all graphic overrides of the element elementId in view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elementId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

