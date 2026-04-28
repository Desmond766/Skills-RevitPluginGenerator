---
kind: property
id: P:Autodesk.Revit.DB.Transform.IsConformal
zh: 变换
source: html/e8d5bf2d-810b-5062-04c6-df09819dac47.htm
---
# Autodesk.Revit.DB.Transform.IsConformal Property

**中文**: 变换

The boolean value that indicates whether this transformation is conformal.

## Syntax (C#)
```csharp
public bool IsConformal { get; }
```

## Remarks
This property is true if this transformation can be decomposed as the product of
a rigid-body motion, uniform scale and reflection. Such transformation preserves 
angles between vectors.

