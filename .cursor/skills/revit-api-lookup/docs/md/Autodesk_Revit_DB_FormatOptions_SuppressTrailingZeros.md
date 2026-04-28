---
kind: property
id: P:Autodesk.Revit.DB.FormatOptions.SuppressTrailingZeros
source: html/ef764b5a-89c3-551a-b1d5-16f40f374316.htm
---
# Autodesk.Revit.DB.FormatOptions.SuppressTrailingZeros Property

Indicates if trailing zeros after the decimal point should be
 suppressed.

## Syntax (C#)
```csharp
public bool SuppressTrailingZeros { get; set; }
```

## Remarks
This property is applicable to display units which are
 formatted as a decimal number. It is not applicable to the
 following display units which have specialized formatting: DUT_GENERAL DUT_FEET_FRACTIONAL_INCHES DUT_FRACTIONAL_INCHES DUT_METERS_CENTIMETERS DUT_DEGREES_AND_MINUTES DUT_RISE_OVER_INCHES DUT_RISE_OVER_120_INCHES DUT_RISE_OVER_FOOT DUT_RISE_OVER_10_FEET When SuppressTrailingZeros is true, trailing zeros to the
 right of the decimal point will not be displayed. For example,
 1.200 will be displayed as 1.2. Trailing zeros are always suppressed for DUT_GENERAL, and the
 SuppressTrailingZeros property is not used.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.
 -or-
 When setting this property: SuppressTrailingZeros was set to true but trailing zeros cannot be suppressed for the display unit in this FormatOptions.

