---
kind: method
id: M:Autodesk.Revit.DB.LayoutRuleClearSpacing.#ctor(System.Double,Autodesk.Revit.DB.BeamSystemJustifyType)
source: html/95ce95d2-f02e-70d2-8a45-e37cd5d5e30b.htm
---
# Autodesk.Revit.DB.LayoutRuleClearSpacing.#ctor Method

Constructor of LayoutRuleFixedDistance. Create LayoutRuleFixedDistance with the values passed in.

## Syntax (C#)
```csharp
public LayoutRuleClearSpacing(
	double spacing,
	BeamSystemJustifyType justifyType
)
```

## Parameters
- **spacing** (`System.Double`) - The value of spacing must be in [0, 30000).
- **justifyType** (`Autodesk.Revit.DB.BeamSystemJustifyType`) - The type of the justification, it's corresponding to the items in the element properties dialog.

## Remarks
The value of spacing must be in [0, 30000), but in fact the spacing should not be too small or too great.

