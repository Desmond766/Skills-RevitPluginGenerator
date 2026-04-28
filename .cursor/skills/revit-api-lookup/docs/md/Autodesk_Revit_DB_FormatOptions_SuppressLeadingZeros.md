---
kind: property
id: P:Autodesk.Revit.DB.FormatOptions.SuppressLeadingZeros
source: html/669988d4-c3fa-e9f6-0c15-f8a3a448c619.htm
---
# Autodesk.Revit.DB.FormatOptions.SuppressLeadingZeros Property

Indicates if leading zeros should be suppressed in feet and fractional inches.

## Syntax (C#)
```csharp
public bool SuppressLeadingZeros { get; set; }
```

## Remarks
This property is applicable to display units related to feet
 and fractional inches: DUT_FEET_FRACTIONAL_INCHES DUT_RISE_OVER_FOOT DUT_RISE_OVER_10_FEET When SuppressLeadingZeros is true: If the foot component of the value is zero (the value is less
 than one foot), it will not be displayed. For example, 0' - 2 3/4"
 will be displayed as 2 3/4". If both the foot and integer inch components of the value are
 zero (the value is less than one inch), neither will be displayed.
 For example, 0' - 0 3/4" will be displayed as 3/4". However, an integer inch component of zero will be displayed
 if the foot component is non-zero. For example 1' - 0 3/4" will be
 displayed as 1' - 0 3/4".

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.
 -or-
 When setting this property: SuppressLeadingZeros was set to true but leading zeros cannot be suppressed for the display unit in this FormatOptions.

