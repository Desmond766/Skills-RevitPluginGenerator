---
kind: method
id: M:Autodesk.Revit.DB.UnitUtils.ConvertFromInternalUnits(System.Double,Autodesk.Revit.DB.ForgeTypeId)
source: html/60c6aac3-8306-c56e-b62f-b7011b9ad7b6.htm
---
# Autodesk.Revit.DB.UnitUtils.ConvertFromInternalUnits Method

Converts a value from Revit's internal units to a given unit.

## Syntax (C#)
```csharp
public static double ConvertFromInternalUnits(
	double value,
	ForgeTypeId unitTypeId
)
```

## Parameters
- **value** (`System.Double`) - The value to convert.
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the desired unit.

## Returns
The converted value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value is not finite
 -or-
 unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

