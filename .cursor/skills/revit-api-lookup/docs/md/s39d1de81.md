---
kind: property
id: P:Autodesk.Revit.DB.Units.DigitGroupingSymbol
source: html/09e0547f-f950-b2aa-1f0c-52c4b62f1ced.htm
---
# Autodesk.Revit.DB.Units.DigitGroupingSymbol Property

The symbol used to separate groups of digits when numbers are formatted with digit grouping.

## Syntax (C#)
```csharp
public DigitGroupingSymbol DigitGroupingSymbol { get; set; }
```

## Remarks
This setting only has an effect when the UseDigitGrouping property
 is set to true in the FormatOptions object for the unit type being
 formatted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

