---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.Pitch
source: html/af5eddc3-9560-eddc-e503-10815b4b01c6.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.Pitch Property

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
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor is not an instance of a spiral shape.
 -or-
 This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

