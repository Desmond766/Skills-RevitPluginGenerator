---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarRoundingManager.ApplicableSegmentLengthRoundingMethod
source: html/d6eae9f7-9969-0236-0287-fe118fa839b4.htm
---
# Autodesk.Revit.DB.Structure.RebarRoundingManager.ApplicableSegmentLengthRoundingMethod Property

The applicable rounding method for shared parameters used by rebar.

## Syntax (C#)
```csharp
public RoundingMethod ApplicableSegmentLengthRoundingMethod { get; }
```

## Remarks
IsActiveOnElement property of ReinforcementSettings RebarRoundingManager has to be true.
 ApplicableSegmentLengthRoundingMethod is meaningless if ReinforcementSettings RebarRoundingManager IsActiveOnElement is false.

