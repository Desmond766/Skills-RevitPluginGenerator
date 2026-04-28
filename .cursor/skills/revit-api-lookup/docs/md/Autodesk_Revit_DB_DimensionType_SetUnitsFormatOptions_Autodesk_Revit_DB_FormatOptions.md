---
kind: method
id: M:Autodesk.Revit.DB.DimensionType.SetUnitsFormatOptions(Autodesk.Revit.DB.FormatOptions)
source: html/3589c9ad-24df-58ca-07a1-2b0c3e2ac157.htm
---
# Autodesk.Revit.DB.DimensionType.SetUnitsFormatOptions Method

Sets the FormatOptions to optionally override the default settings in the Units class for the units value.

## Syntax (C#)
```csharp
public void SetUnitsFormatOptions(
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

