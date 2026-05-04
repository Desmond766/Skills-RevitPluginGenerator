---
kind: method
id: M:Autodesk.Revit.DB.View.GetPrimaryViewId
zh: 视图
source: html/3ef30e6a-73e8-2d80-7f76-00fe1f42fed7.htm
---
# Autodesk.Revit.DB.View.GetPrimaryViewId Method

**中文**: 视图

Get the id of the primary view.

## Syntax (C#)
```csharp
public ElementId GetPrimaryViewId()
```

## Returns
The id of the primary view, or InvalidElementId if there is no primary view.

## Remarks
The primary view is the view from which a dependent view is created.

