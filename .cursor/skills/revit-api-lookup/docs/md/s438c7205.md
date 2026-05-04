---
kind: method
id: M:Autodesk.Revit.DB.View.GetCategoryHidden(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/52ce4cea-6f27-9e85-f82a-115e308eebfc.htm
---
# Autodesk.Revit.DB.View.GetCategoryHidden Method

**中文**: 视图

Checks if elements of the given category are set to be invisible (hidden) in this view.

## Syntax (C#)
```csharp
public bool GetCategoryHidden(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The ID of the category.

## Returns
True if the category is invisible (hidden), false otherwise.

## Remarks
This checks only if the category is set visible or invisible individually. Other Revit mechanisms
 may also affect the visibility of elements of this category, including:
 The category classes settings for
 model categories, annotation categories, import categories or analytical model categories. View filters. Elements hidden individually in the view. 
 Thus the return value may not reflect the actual visibility of elements of this category in the view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - categoryId does not correspond to a Category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

