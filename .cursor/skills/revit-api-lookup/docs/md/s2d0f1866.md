---
kind: property
id: P:Autodesk.Revit.DB.View.Scale
zh: 视图
source: html/b59ad4e0-2835-49be-d1eb-5538f5bc3c89.htm
---
# Autodesk.Revit.DB.View.Scale Property

**中文**: 视图

The scale of the view.

## Syntax (C#)
```csharp
public int Scale { get; set; }
```

## Remarks
The scale is the ratio of true model size to paper size.
This property is meaningless for perspective views. When setting the scale if the
scale corresponds to a predefined scale, the predefined item will be applied. Otherwise,
a custom scale will be applied.

