---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricRoundingManager.ApplicableSegmentLengthRoundingMethod
source: html/2b268449-e8ff-ffe4-a0f0-aa025c684524.htm
---
# Autodesk.Revit.DB.Structure.FabricRoundingManager.ApplicableSegmentLengthRoundingMethod Property

The applicable rounding method for fabric segments.

## Syntax (C#)
```csharp
public RoundingMethod ApplicableSegmentLengthRoundingMethod { get; }
```

## Remarks
IsActiveOnElement property of ReinforcementSettings RebarRoundingManager has to be true.
 ApplicableSegmentLengthRoundingMethod is meaningless if ReinforcementSettings RebarRoundingManager IsActiveOnElement is false.

