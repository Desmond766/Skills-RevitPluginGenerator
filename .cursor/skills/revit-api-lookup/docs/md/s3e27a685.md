---
kind: method
id: M:Autodesk.Revit.DB.UnitUtils.Convert(System.Double,Autodesk.Revit.DB.ForgeTypeId,Autodesk.Revit.DB.ForgeTypeId)
source: html/0573dcde-4f6d-4e4d-9d39-11fd61806a75.htm
---
# Autodesk.Revit.DB.UnitUtils.Convert Method

Converts a value from one unit to another, such as square feet to square meters.

## Syntax (C#)
```csharp
public static double Convert(
	double value,
	ForgeTypeId currentUnitTypeId,
	ForgeTypeId desiredUnitTypeId
)
```

## Parameters
- **value** (`System.Double`) - The value to convert.
- **currentUnitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the current unit.
- **desiredUnitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the desired unit.

## Returns
The converted value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for value is not finite
 -or-
 currentUnitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
 -or-
 desiredUnitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - currentUnitTypeId and desiredUnitTypeId have different dimensions.

