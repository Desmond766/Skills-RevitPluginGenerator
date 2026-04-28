---
kind: method
id: M:Autodesk.Revit.DB.DimensionType.SetAlternateUnitsFormatOptions(Autodesk.Revit.DB.FormatOptions)
source: html/a8203fee-0893-99fe-a279-950b80cd22ee.htm
---
# Autodesk.Revit.DB.DimensionType.SetAlternateUnitsFormatOptions Method

Sets the FormatOptions to optionally override the default settings in the Units class for the alternate units value.

## Syntax (C#)
```csharp
public void SetAlternateUnitsFormatOptions(
	FormatOptions formatOptions
)
```

## Parameters
- **formatOptions** (`Autodesk.Revit.DB.FormatOptions`) - The FormatOptions.

## Remarks
See the UnitType property to determine the unit type of this dimension style.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The display unit in formatOptions is not a valid display unit for the unit type of this DimensionType, or the rounding method in formatOptions is not set to Nearest. See UnitUtils.IsValidDisplayUnit(UnitType, DisplayUnitType), UnitUtils.GetValidDisplayUnits(UnitType) and FormatOptions.RoundingMethod.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

