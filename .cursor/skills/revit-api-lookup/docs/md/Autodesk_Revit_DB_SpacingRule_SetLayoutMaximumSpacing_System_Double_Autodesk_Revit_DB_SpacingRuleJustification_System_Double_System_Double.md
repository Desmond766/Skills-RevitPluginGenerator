---
kind: method
id: M:Autodesk.Revit.DB.SpacingRule.SetLayoutMaximumSpacing(System.Double,Autodesk.Revit.DB.SpacingRuleJustification,System.Double,System.Double)
source: html/989559a9-dd62-1afc-8fd9-03e0090ae710.htm
---
# Autodesk.Revit.DB.SpacingRule.SetLayoutMaximumSpacing Method

Set the Layout property to MaximumSpacing.

## Syntax (C#)
```csharp
public void SetLayoutMaximumSpacing(
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
When changing the Layout to MaximumSpacing,
you must also simultaneously set the Distance,
Justification, GridlinesRotation, and Offset properties.

