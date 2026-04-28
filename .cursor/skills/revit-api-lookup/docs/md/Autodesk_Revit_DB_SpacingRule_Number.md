---
kind: property
id: P:Autodesk.Revit.DB.SpacingRule.Number
source: html/be695e07-d921-1acb-3d96-7879f9fefeb2.htm
---
# Autodesk.Revit.DB.SpacingRule.Number Property

The exact number of lines in the
region.

## Syntax (C#)
```csharp
public int Number { get; set; }
```

## Remarks
This property is only available when
 Layout is equal to FixedNumber.
Lines will be placed exactly at the boundaries if
possible, so if your region is 100' long and you
specify Number = 11, your lines will be 10'
apart. Must be between 1 and 200.

