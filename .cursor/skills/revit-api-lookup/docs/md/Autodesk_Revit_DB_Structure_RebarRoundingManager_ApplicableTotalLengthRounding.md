---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarRoundingManager.ApplicableTotalLengthRounding
source: html/b9f367b6-4711-f227-3b23-59cb60118619.htm
---
# Autodesk.Revit.DB.Structure.RebarRoundingManager.ApplicableTotalLengthRounding Property

The applicable rounding for Bar Length and Total Bar Length parameters.

## Syntax (C#)
```csharp
public double ApplicableTotalLengthRounding { get; }
```

## Remarks
IsActiveOnElement property of ReinforcementSettings RebarRoundingManager has to be true.
 ApplicableTotalLengthRounding is meaningless if ReinforcementSettings RebarRoundingManager IsActiveOnElement is false.

