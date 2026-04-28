---
kind: property
id: P:Autodesk.Revit.DB.SpacingRule.BeltMeasurement
source: html/41ab13a2-7c5b-0a3d-354e-e801b1834950.htm
---
# Autodesk.Revit.DB.SpacingRule.BeltMeasurement Property

On a curved surface, BeltMeasurement specifies where the
grid's distances are measured.

## Syntax (C#)
```csharp
public double BeltMeasurement { get; set; }
```

## Remarks
On a conical surface, the distance between the radial gridlines is 
not constant. To interpret the Distance property, a circumferential
gridline is taken as the "belt." Distance is then measured along
the belt. The BeltMeasurement property gives the location of the 
belt relative to the extremes of the surface. The belt is used
whenever gridlines are not parallel. It defaults to 0.5.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when beltMeasurement is outside the range [ 0.0, 1.0 ].
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the gridlines are guaranteed to be parallel; check the
 HasBeltMeasurement property before using this property.

