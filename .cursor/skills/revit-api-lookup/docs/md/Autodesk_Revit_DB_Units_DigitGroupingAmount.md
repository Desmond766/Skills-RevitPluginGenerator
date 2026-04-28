---
kind: property
id: P:Autodesk.Revit.DB.Units.DigitGroupingAmount
source: html/03c48a42-726d-2ca7-64ae-79b851820fd1.htm
---
# Autodesk.Revit.DB.Units.DigitGroupingAmount Property

The number of digits in each group when numbers are formatted with digit grouping.

## Syntax (C#)
```csharp
public DigitGroupingAmount DigitGroupingAmount { get; set; }
```

## Remarks
This setting only has an effect when the UseDigitGrouping property
 is set to true in the FormatOptions object for the unit type being
 formatted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

