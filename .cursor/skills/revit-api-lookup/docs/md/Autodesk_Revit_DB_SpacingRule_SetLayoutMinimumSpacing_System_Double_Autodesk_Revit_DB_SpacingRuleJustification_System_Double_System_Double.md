---
kind: method
id: M:Autodesk.Revit.DB.SpacingRule.SetLayoutMinimumSpacing(System.Double,Autodesk.Revit.DB.SpacingRuleJustification,System.Double,System.Double)
source: html/fbb5437c-cea9-1d12-a3af-460612c1f015.htm
---
# Autodesk.Revit.DB.SpacingRule.SetLayoutMinimumSpacing Method

Set the Layout property to MinimumSpacing.

## Syntax (C#)
```csharp
public void SetLayoutMinimumSpacing(
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
When changing the Layout to MinimumSpacing,
you must also simultaneously set the Distance,
Justification, GridlinesRotation, and Offset properties.

