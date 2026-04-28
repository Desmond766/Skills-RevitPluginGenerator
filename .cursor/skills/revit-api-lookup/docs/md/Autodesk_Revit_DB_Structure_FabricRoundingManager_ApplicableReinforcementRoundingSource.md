---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricRoundingManager.ApplicableReinforcementRoundingSource
source: html/183be200-494b-5add-c086-d4e57e08d64f.htm
---
# Autodesk.Revit.DB.Structure.FabricRoundingManager.ApplicableReinforcementRoundingSource Property

Identifies the source of the rounding settings for this element.

## Syntax (C#)
```csharp
public ReinforcementRoundingSource ApplicableReinforcementRoundingSource { get; }
```

## Remarks
For a FabricSheet or FabricArea element, this could be FabricArea, FabricSheetType, or ReinforcementSettings. For a FabricSheetType, this could be FabricSheetType or ReinforcementSettings.
 All FabricSheets hosted by common FabricArea must have common reinforcement rounding overrides so at instance level its overrides are in FabricArea, not in FabricSheets.

