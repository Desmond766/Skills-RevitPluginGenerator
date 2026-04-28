---
kind: property
id: P:Autodesk.Revit.DB.Transform.Scale
zh: 变换
source: html/767a8668-6153-b003-1027-e8a9de3b2f7d.htm
---
# Autodesk.Revit.DB.Transform.Scale Property

**中文**: 变换

The real number that represents the scale of the transformation.

## Syntax (C#)
```csharp
public double Scale { get; }
```

## Remarks
When the transformation is conformal and can be decomposed as the product of
a rigid-body motion, uniform scale and reflection, this property returns the scale 
value of the uniform scale transformation.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this transformation is not conformal and the scale is undefined.

