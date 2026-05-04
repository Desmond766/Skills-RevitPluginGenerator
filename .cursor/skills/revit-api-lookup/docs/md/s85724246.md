---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.CanSuppressLeadingZeros(Autodesk.Revit.DB.ForgeTypeId)
source: html/d1facba7-279c-7dde-4ceb-55f2e596737b.htm
---
# Autodesk.Revit.DB.FormatOptions.CanSuppressLeadingZeros Method

Checks whether leading zeros can be suppressed for a given unit.

## Syntax (C#)
```csharp
public static bool CanSuppressLeadingZeros(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit.

## Returns
True if leading zeros can be suppressed, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

