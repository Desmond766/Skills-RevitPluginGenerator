---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.BaseFinishingTurns
source: html/5bdafcc3-2ade-3169-83f4-40cd75f42b90.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.BaseFinishingTurns Property

For a spiral, the number of finishing turns at the lower end of the spiral.

## Syntax (C#)
```csharp
public int BaseFinishingTurns { get; set; }
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

