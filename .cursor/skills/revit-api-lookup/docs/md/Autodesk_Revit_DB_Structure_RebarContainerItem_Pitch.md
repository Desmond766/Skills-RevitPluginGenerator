---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarContainerItem.Pitch
source: html/e76fccf0-1b96-9732-6fcc-b1c3399c1b27.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.Pitch Property

For a spiral, the pitch, or vertical distance traveled in one rotation.

## Syntax (C#)
```csharp
public double Pitch { get; set; }
```

## Remarks
Applies only to instances where RebarShape.Definition is of type
 RebarShapeDefinitionByArc, and its Type property is equal to the value
 RebarShapeDefinitionByArcType.Spiral.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: pitch must be positive.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarContainerItem is not an instance of a spiral shape.

