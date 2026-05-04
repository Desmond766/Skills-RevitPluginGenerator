---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarContainerItem.Height
zh: 高度
source: html/5e8dda08-99a3-3086-20eb-30aed04c08a8.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.Height Property

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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarContainerItem is not an instance of a spiral shape.

