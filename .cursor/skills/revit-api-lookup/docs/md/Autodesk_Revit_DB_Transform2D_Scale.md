---
kind: property
id: P:Autodesk.Revit.DB.Transform2D.Scale
source: html/30a3e4d2-d70f-aace-95c1-001884d95e6c.htm
---
# Autodesk.Revit.DB.Transform2D.Scale Property

The real number that represents the scale of the conformal transformation.

## Syntax (C#)
```csharp
public double Scale { get; }
```

## Remarks
When the transformation is conformal and can be decomposed as the product of a rigid-body motion,
 uniform scale and reflection, this property returns the scale value of the uniform scale transformation.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This transformation is not conformal and the scale is undefined.

