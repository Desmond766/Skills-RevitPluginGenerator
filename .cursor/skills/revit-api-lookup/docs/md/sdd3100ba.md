---
kind: method
id: M:Autodesk.Revit.DB.View.GetCategoryOverrides(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/ed267b82-56be-6e3b-0c6d-4de7df1ed312.htm
---
# Autodesk.Revit.DB.View.GetCategoryOverrides Method

**中文**: 视图

Gets graphic overrides for a category in view.

## Syntax (C#)
```csharp
public OverrideGraphicSettings GetCategoryOverrides(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - Category to be checked.

## Returns
Object representing all graphic overrides of the category categoryId in view. A default OverrideGraphicSettings object will be returned if it not previously been set for this view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The view type does not support Visibility/Graphics Overriddes.

