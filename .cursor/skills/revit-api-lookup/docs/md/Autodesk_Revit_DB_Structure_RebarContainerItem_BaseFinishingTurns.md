---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarContainerItem.BaseFinishingTurns
source: html/db8f7048-da0b-878e-6eae-d1cb4c193f4e.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.BaseFinishingTurns Property

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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarContainerItem is not an instance of a spiral shape.

