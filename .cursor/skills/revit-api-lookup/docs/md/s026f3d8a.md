---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.Height
zh: 高度
source: html/c51afe43-2b8d-35ef-245d-7e97b6a86057.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.Height Property

**中文**: 高度

For a spiral, the overall height.

## Syntax (C#)
```csharp
public double Height { get; set; }
```

## Remarks
Applies only to instances where RebarShape.Definition is of type
 RebarShapeDefinitionByArc, and its Type property is equal to the value
 RebarShapeDefinitionByArcType.Spiral.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: height must be positive.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor is not an instance of a spiral shape.
 -or-
 This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

