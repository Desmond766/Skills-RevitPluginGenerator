---
kind: property
id: P:Autodesk.Revit.DB.View.ViewDirection
zh: 视图
source: html/822149b4-d843-3370-286b-c3bc8c82abff.htm
---
# Autodesk.Revit.DB.View.ViewDirection Property

**中文**: 视图

The direction towards the viewer.

## Syntax (C#)
```csharp
public XYZ ViewDirection { get; }
```

## Remarks
In orthographic views, all objects are projected onto the screen along
this direction. In perspective views, the view target point is projected along
this direction, but other points are projected towards the eye along different
vectors.

