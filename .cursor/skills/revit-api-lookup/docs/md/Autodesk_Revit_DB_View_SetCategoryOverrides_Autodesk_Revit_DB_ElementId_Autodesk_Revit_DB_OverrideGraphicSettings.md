---
kind: method
id: M:Autodesk.Revit.DB.View.SetCategoryOverrides(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.OverrideGraphicSettings)
zh: 视图
source: html/ee90e635-7a78-3d14-9159-23a87f1655cc.htm
---
# Autodesk.Revit.DB.View.SetCategoryOverrides Method

**中文**: 视图

Sets graphic overrides for a category in view.

## Syntax (C#)
```csharp
public void SetCategoryOverrides(
	ElementId categoryId,
	OverrideGraphicSettings overrideGraphicSettings
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - Category to be overridden
- **overrideGraphicSettings** (`Autodesk.Revit.DB.OverrideGraphicSettings`) - Object representing all graphic overrides of the category categoryId in view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Category cannot be overridden.
 -or-
 Fill pattern must be a drafting pattern.
 -or-
 Fill pattern Id must be invalidElementId or point to a LinePattern element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The view type does not support Visibility/Graphics Overriddes.

