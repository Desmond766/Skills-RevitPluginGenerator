---
kind: method
id: M:Autodesk.Revit.DB.UnitUtils.ConvertToInternalUnits(System.Double,Autodesk.Revit.DB.ForgeTypeId)
source: html/b5e8d065-d274-62f8-7b5d-89722f7c44f3.htm
---
# Autodesk.Revit.DB.UnitUtils.ConvertToInternalUnits Method

Converts a value from a given unit to Revit's internal units.

## Syntax (C#)
```csharp
public static double ConvertToInternalUnits(
	double value,
	ForgeTypeId unitTypeId
)
```

## Parameters
- **value** (`System.Double`) - The value to convert.
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit quantifying the value.

## Returns
The converted value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value is not finite
 -or-
 unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

