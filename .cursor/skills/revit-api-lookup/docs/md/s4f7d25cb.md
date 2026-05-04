---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarRoundingManager.ApplicableSegmentLengthRounding
source: html/71e6d932-6b3a-3efb-70ac-5449898e4b06.htm
---
# Autodesk.Revit.DB.Structure.RebarRoundingManager.ApplicableSegmentLengthRounding Property

The applicable rounding for shared parameters used by rebar.

## Syntax (C#)
```csharp
public double ApplicableSegmentLengthRounding { get; }
```

## Remarks
IsActiveOnElement property of ReinforcementSettings RebarRoundingManager has to be true.
 ApplicableSegmentLengthRounding is meaningless if ReinforcementSettings RebarRoundingManager IsActiveOnElement is false.

