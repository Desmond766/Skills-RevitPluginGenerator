---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricRoundingManager.ApplicableSegmentLengthRounding
source: html/5d9f35bb-637d-8b8b-c2e5-816d08feea36.htm
---
# Autodesk.Revit.DB.Structure.FabricRoundingManager.ApplicableSegmentLengthRounding Property

The applicable rounding for fabric segments.

## Syntax (C#)
```csharp
public double ApplicableSegmentLengthRounding { get; }
```

## Remarks
IsActiveOnElement property of ReinforcementSettings RebarRoundingManager has to be true.
 ApplicableSegmentLengthRounding is meaningless if ReinforcementSettings RebarRoundingManager IsActiveOnElement is false.

