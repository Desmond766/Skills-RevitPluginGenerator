---
kind: method
id: M:Autodesk.Revit.DB.ScheduleField.SetFormatOptions(Autodesk.Revit.DB.FormatOptions)
source: html/853a134b-205d-5642-15cb-4e8d0db2ca86.htm
---
# Autodesk.Revit.DB.ScheduleField.SetFormatOptions Method

Sets the FormatOptions to optionally override the default settings in the Units class.

## Syntax (C#)
```csharp
public void SetFormatOptions(
	FormatOptions formatOptions
)
```

## Parameters
- **formatOptions** (`Autodesk.Revit.DB.FormatOptions`) - The FormatOptions.

## Remarks
See the UnitType property to determine the unit type of this field.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The display unit in formatOptions is not a valid display unit for the unit type of this ScheduleField, or the rounding method in formatOptions is not set to Nearest. See UnitUtils.IsValidDisplayUnit(UnitType, DisplayUnitType), UnitUtils.GetValidDisplayUnits(UnitType) and FormatOptions.RoundingMethod.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

