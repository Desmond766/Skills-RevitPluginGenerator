---
kind: method
id: M:Autodesk.Revit.DB.View.HasViewTransforms
zh: 视图
source: html/a0a4e4d4-6b22-9948-f4ba-e19d1cdd47a2.htm
---
# Autodesk.Revit.DB.View.HasViewTransforms Method

**中文**: 视图

Returns true if the view reports model space to view projection space transforms.

## Syntax (C#)
```csharp
public bool HasViewTransforms()
```

## Returns
True if the view returns transforms, false otherwise.

## Remarks
Not all views return transforms. For example, schedules and legends
 do not report transforms.

