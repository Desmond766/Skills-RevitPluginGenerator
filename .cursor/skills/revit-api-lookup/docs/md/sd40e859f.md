---
kind: property
id: P:Autodesk.Revit.DB.Transform2D.IsConformal
source: html/2a9cdce4-7098-7718-5f66-0a5f3f0df768.htm
---
# Autodesk.Revit.DB.Transform2D.IsConformal Property

The boolean value that indicates whether this transformation is conformal.

## Syntax (C#)
```csharp
public bool IsConformal { get; }
```

## Remarks
This property is true if this transformation can be decomposed as the product
 of a rigid-body motion, uniform scale and reflection.
 Such transformation preserves angles between vectors.

