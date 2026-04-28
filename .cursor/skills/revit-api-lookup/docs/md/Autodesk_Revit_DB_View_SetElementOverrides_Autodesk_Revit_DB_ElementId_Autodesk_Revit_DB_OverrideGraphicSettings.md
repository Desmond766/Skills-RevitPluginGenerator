---
kind: method
id: M:Autodesk.Revit.DB.View.SetElementOverrides(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.OverrideGraphicSettings)
zh: 视图
source: html/a6f1ced3-1f1c-dd42-c0ca-f15f301d1cad.htm
---
# Autodesk.Revit.DB.View.SetElementOverrides Method

**中文**: 视图

Sets graphic overrides for an element in the view.

## Syntax (C#)
```csharp
public void SetElementOverrides(
	ElementId elementId,
	OverrideGraphicSettings overrideGraphicSettings
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Element to override.
- **overrideGraphicSettings** (`Autodesk.Revit.DB.OverrideGraphicSettings`) - An object representing all graphic overrides of the element in view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elementId is not a valid Element identifier.
 -or-
 Fill pattern must be a drafting pattern.
 -or-
 Fill pattern Id must be invalidElementId or point to a LinePattern element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The element "this View" does not belong to a project document.
 -or-
 The view type does not support Visibility/Graphics Overriddes.

