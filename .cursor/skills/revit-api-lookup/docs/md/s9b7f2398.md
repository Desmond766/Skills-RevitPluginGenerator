---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricRoundingManager.ApplicableTotalLengthRounding
source: html/07e33ef6-56d4-fd21-559e-816a3dfb2a10.htm
---
# Autodesk.Revit.DB.Structure.FabricRoundingManager.ApplicableTotalLengthRounding Property

The applicable rounding for Cut Overall Length and Cut Overall Width parameters.

## Syntax (C#)
```csharp
public double ApplicableTotalLengthRounding { get; }
```

## Remarks
IsActiveOnElement property of ReinforcementSettings FabricRoundingManager has to be true.
 ApplicableTotalLengthRounding is meaningless if ReinforcementSettings FabricRoundingManager IsActiveOnElement is false.

