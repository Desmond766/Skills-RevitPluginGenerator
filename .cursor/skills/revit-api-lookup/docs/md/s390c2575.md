---
kind: method
id: M:Autodesk.Revit.DB.View.IsCategoryOverridable(Autodesk.Revit.DB.ElementId)
zh: 视图
source: html/054346ac-ee60-2969-cdc6-8c2c17324abb.htm
---
# Autodesk.Revit.DB.View.IsCategoryOverridable Method

**中文**: 视图

Checks whether the category can have graphic overrides in this view.

## Syntax (C#)
```csharp
public bool IsCategoryOverridable(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - ElementId of the category.

## Returns
True if category can be overridden, false otherwise.

## Remarks
Categories can be allowed to be overridden in some view types and prohibited from being overridden in others.
 E.g., categories cannot be overridden in ProjectBrowser

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

