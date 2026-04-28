---
kind: property
id: P:Autodesk.Revit.DB.FormatOptions.SuppressSpaces
source: html/559fd4bd-df8f-5cdc-9202-3f7cf342053d.htm
---
# Autodesk.Revit.DB.FormatOptions.SuppressSpaces Property

Indicates if spaces around the dash should be suppressed in feet and fractional inches.

## Syntax (C#)
```csharp
public bool SuppressSpaces { get; set; }
```

## Remarks
This property is applicable to display units related to feet
 and fractional inches: DUT_FEET_FRACTIONAL_INCHES DUT_RISE_OVER_FOOT DUT_RISE_OVER_10_FEET When SuppressLeadingZeros is true, spaces will not be
 inserted before and after the dash separating feet from
 inches. For example, 1' - 2 3/4" will be displayed as
 1'-2 3/4".

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - UseDefault is true in this FormatOptions.
 -or-
 When setting this property: SuppressSpaces was set to true but spaces cannot be suppressed for the display unit in this FormatOptions.

