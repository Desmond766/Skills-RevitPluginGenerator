---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.TopFinishingTurns
source: html/131de72d-223e-239f-6522-c62738b96744.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.TopFinishingTurns Property

For a spiral, the number of finishing turns at the upper end of the spiral.

## Syntax (C#)
```csharp
public int TopFinishingTurns { get; set; }
```

## Remarks
Applies only to instances where RebarShape.Definition is of type
 RebarShapeDefinitionByArc, and its Type property is equal to the value
 RebarShapeDefinitionByArcType.Spiral.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: turns must be between 0 and 100.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor is not an instance of a spiral shape.
 -or-
 This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

