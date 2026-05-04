---
kind: property
id: P:Autodesk.Revit.DB.FormatOptions.Accuracy
source: html/bbba6604-8961-3a26-4e1f-73c2a2169464.htm
---
# Autodesk.Revit.DB.FormatOptions.Accuracy Property

The accuracy to which values will be rounded.

## Syntax (C#)
```csharp
public double Accuracy { get; set; }
```

## Remarks
Formatted values will be rounded to the nearest multiple of
 the accuracy value. Accuracy is specified in display units, not in Revit's
 internal units. For DUT_GENERAL, the accuracy value is always 0.000001 and
 cannot be set to another value. DUT_GENERAL is a special display
 unit that always rounds to six decimal places and suppresses
 trailing zeros, roughly equivalent to DUT_FIXED with the accuracy
 set to 0.000001 and SuppressTrailingZeros set to true. For other display units, a wide range of accuracy values may
 be specified. All values from 1.0e-12 to 1.0e12 will be accepted,
 but the specified value will be automatically adjusted to the
 nearest supported value if necessary. For best results, the
 accuracy value should be chosen to be compatible with the display
 unit: For most display units, the value is displayed as a decimal
 number, and the accuracy should typically be a power of 10, for
 example 1.0 to round to 0 decimal places or 0.001 to round to 3
 decimal places. Other values can be used, for example 0.25 to
 round to the nearest 0.25 (displayed with 2 decimal places) or
 2.0 to round to the nearest even integer (displayed with 0 decimal
 places). The specified accuracy will automatically be rounded to
 the nearest positive multiple of 1.0e-12. For DUT_FRACTIONAL_INCHES, DUT_RISE_OVER_INCHES, and
 DUT_RISE_OVER_120_INCHES, the accuracy should typically be a power
 of 2, for example 0.25 to round to the nearest 1/4". Other values
 can be used, for example 6.0 to round to the nearest 6" or 1.5 to
 round to the nearest 1 1/2". For DUT_FEET_FRACTIONAL_INCHES,
 DUT_RISE_OVER_FOOT, and DUT_RISE_OVER_10_FEET, similar accuracy
 values can be used but they must be divided by 12 because the
 accuracy is specified in feet. The specified accuracy will
 automatically be rounded to the nearest positive multiple of
 1/2^20 inches. For DUT_DEGREES_AND_MINUTES, the accuracy should typically
 be a power of 10 divided by 3600 to round seconds to a specific
 number of decimal places, for example 1.0 / 3600.0 to round seconds
 to 0 decimal places or 0.01 / 3600.0 to round seconds to 2 decimal
 places. The specified accuracy will automatically be rounded to
 the nearest positive multiple of 1.0e-8 seconds.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: accuracy is not a valid accuracy for the display unit in this FormatOptions.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.

