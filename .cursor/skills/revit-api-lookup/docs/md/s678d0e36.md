---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricRoundingManager.ApplicableTotalLengthRoundingMethod
source: html/404cde5c-2e56-eeeb-5844-0cc34d4d15da.htm
---
# Autodesk.Revit.DB.Structure.FabricRoundingManager.ApplicableTotalLengthRoundingMethod Property

The applicable rounding method for Cut Overall Length and Cut Overall Width parameters.

## Syntax (C#)
```csharp
public RoundingMethod ApplicableTotalLengthRoundingMethod { get; }
```

## Remarks
IsActiveOnElement property of ReinforcementSettings FabricRoundingManager has to be true.
 ApplicableTotalLengthRoundingMethod is meaningless if ReinforcementSettings FabricRoundingManager IsActiveOnElement is false.

