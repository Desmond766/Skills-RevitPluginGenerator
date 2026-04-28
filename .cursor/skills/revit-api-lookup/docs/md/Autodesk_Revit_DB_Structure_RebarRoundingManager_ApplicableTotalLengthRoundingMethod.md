---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarRoundingManager.ApplicableTotalLengthRoundingMethod
source: html/dd650efc-83b0-ad01-4012-378aaee29d87.htm
---
# Autodesk.Revit.DB.Structure.RebarRoundingManager.ApplicableTotalLengthRoundingMethod Property

The applicable rounding method for Bar Length and Total Bar Length parameters.

## Syntax (C#)
```csharp
public RoundingMethod ApplicableTotalLengthRoundingMethod { get; }
```

## Remarks
IsActiveOnElement property of ReinforcementSettings RebarRoundingManager has to be true.
 ApplicableTotalLengthRoundingMethod is meaningless if ReinforcementSettings RebarRoundingManager IsActiveOnElement is false.

