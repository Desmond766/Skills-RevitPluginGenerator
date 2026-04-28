---
kind: property
id: P:Autodesk.Revit.DB.Structure.ReinforcementRoundingManager.IsActiveOnElement
source: html/c4210861-6b33-b2e4-8e1f-2684734eb770.htm
---
# Autodesk.Revit.DB.Structure.ReinforcementRoundingManager.IsActiveOnElement Property

Defines whether reinforcement rounding is activated for the particular element.

## Syntax (C#)
```csharp
public bool IsActiveOnElement { get; set; }
```

## Remarks
If these overrides relate to ReinforcementSettings, this property is shared for Rebar and Fabric related elements. Toggling this value will toggle the settings for both kinds of Reinforcement elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: Reinforcement rounding overrides for this element cannot be enabled because overrides are not enabled for ReinforcementSettings.

