---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.RebarShapeFailures.DiagonalEdgesAreUnderconstrained
source: html/1d84e275-3faf-2ead-358b-bb9d21a7521d.htm
---
# Autodesk.Revit.DB.BuiltInFailures.RebarShapeFailures.DiagonalEdgesAreUnderconstrained Property

Shape is underconstrained. Please add additional dimension constraints to the shape's diagonal edges. (Diagonal segments with only one dimension constraint are automatically given a second constraint to lie at an angle of exactly 45 degrees, regardless of how they are drawn. The current shape has more than one such segment in sequence, and the resulting constrained edges are co-linear.)

## Syntax (C#)
```csharp
public static FailureDefinitionId DiagonalEdgesAreUnderconstrained { get; }
```

