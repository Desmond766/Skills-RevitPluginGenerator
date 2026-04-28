---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition
source: html/47a3135c-ce53-c041-f551-0795767eaa41.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeMultiplanarDefinition

A specification for a simple 3D rebar shape.

## Syntax (C#)
```csharp
public class RebarShapeMultiplanarDefinition : IDisposable
```

## Remarks
Simple 3D rebar shapes are supported by adding segments to a regular 2D shape definition.
 The added segments consist of three optional parts: a "duplicate shape" and two connectors.
 A "duplicate shape" is a second copy of the 2D shape, offset in a perpendicular direction,
 and connected at either the start or the end by a perpendicular connector segment. Also
 supported is adding one or both connector segments, without the duplicate shape.
 Fillets are applied to the connector segments with a diameter that is given by
 the OutOfPlaneBendDiameter property. The length of the connectors is given by the
 Rebar instance parameter "multiplanar depth." The MultiplanarDepth property of this
 class is the default value of the parameter.

