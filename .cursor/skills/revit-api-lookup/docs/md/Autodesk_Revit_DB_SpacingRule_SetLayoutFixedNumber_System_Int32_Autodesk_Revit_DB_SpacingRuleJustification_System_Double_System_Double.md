---
kind: method
id: M:Autodesk.Revit.DB.SpacingRule.SetLayoutFixedNumber(System.Int32,Autodesk.Revit.DB.SpacingRuleJustification,System.Double,System.Double)
source: html/1c322ba1-30eb-1321-c005-d5bacb3803e0.htm
---
# Autodesk.Revit.DB.SpacingRule.SetLayoutFixedNumber Method

Set the Layout property to FixedNumber.

## Syntax (C#)
```csharp
public void SetLayoutFixedNumber(
	int number,
	SpacingRuleJustification just,
	double gridlinesRotation,
	double offset
)
```

## Parameters
- **number** (`System.Int32`)
- **just** (`Autodesk.Revit.DB.SpacingRuleJustification`)
- **gridlinesRotation** (`System.Double`)
- **offset** (`System.Double`)

## Remarks
When changing the Layout to FixedNumber,
you must also simultaneously set the Number,
Justification, GridlinesRotation, and Offset properties.

