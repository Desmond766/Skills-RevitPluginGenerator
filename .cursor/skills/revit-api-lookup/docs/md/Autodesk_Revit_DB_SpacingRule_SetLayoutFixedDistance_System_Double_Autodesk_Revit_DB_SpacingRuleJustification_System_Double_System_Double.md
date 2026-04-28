---
kind: method
id: M:Autodesk.Revit.DB.SpacingRule.SetLayoutFixedDistance(System.Double,Autodesk.Revit.DB.SpacingRuleJustification,System.Double,System.Double)
source: html/edd66d59-402c-173b-a569-2c5dee2b2262.htm
---
# Autodesk.Revit.DB.SpacingRule.SetLayoutFixedDistance Method

Set the Layout property to FixedDistance.

## Syntax (C#)
```csharp
public void SetLayoutFixedDistance(
	double distance,
	SpacingRuleJustification just,
	double gridlinesRotation,
	double offset
)
```

## Parameters
- **distance** (`System.Double`)
- **just** (`Autodesk.Revit.DB.SpacingRuleJustification`)
- **gridlinesRotation** (`System.Double`)
- **offset** (`System.Double`)

## Remarks
When changing the Layout to FixedDistance,
you must also simultaneously set the Distance,
Justification, GridlinesRotation, and Offset properties.

