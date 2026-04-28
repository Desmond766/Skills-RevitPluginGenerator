---
kind: method
id: M:Autodesk.Revit.DB.View.SetCategoryHidden(Autodesk.Revit.DB.ElementId,System.Boolean)
zh: 视图
source: html/87a1e1e2-ee81-1a73-19d7-895b1fa10158.htm
---
# Autodesk.Revit.DB.View.SetCategoryHidden Method

**中文**: 视图

Sets if elements of the given category will be visible in this view.

## Syntax (C#)
```csharp
public void SetCategoryHidden(
	ElementId categoryId,
	bool hide
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The ID of the category.
- **hide** (`System.Boolean`) - True to make elements of this category invisible, false to make them visible.

## Remarks
This affects only if the category is set visible or invisible individually. Other Revit mechanisms
 may also affect the visibility of elements of this category, including:
 The category classes settings for
 model categories, annotation categories, import categories or analytical model categories. View filters. Elements hidden individually in the view. 
 Thus setting this value may not affect the actual visibility of elements of this category in the view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - categoryId does not correspond to a Category.
 -or-
 Category cannot be hidden.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

