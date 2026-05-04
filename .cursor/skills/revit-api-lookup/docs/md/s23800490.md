---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarContainerItem.TopFinishingTurns
source: html/48be1e27-574c-6cba-1b98-c024823d301e.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.TopFinishingTurns Property

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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarContainerItem is not an instance of a spiral shape.

