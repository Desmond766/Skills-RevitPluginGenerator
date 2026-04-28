---
kind: property
id: P:Autodesk.Revit.DB.SpacingRule.Distance
source: html/c9e2d38e-0c4b-6ed7-3219-9bf06d2b9a1c.htm
---
# Autodesk.Revit.DB.SpacingRule.Distance Property

The exact distance between layout
lines.

## Syntax (C#)
```csharp
public double Distance { get; set; }
```

## Remarks
This property is only available when
 Layout is equal to FixedDistance,
MaximumSpacing, or MinimumSpacing. Must be a positive
value less than 30000'.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown
when the Layout property is None or FixedNumber.

