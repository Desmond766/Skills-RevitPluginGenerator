---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.CanSuppressTrailingZeros(Autodesk.Revit.DB.ForgeTypeId)
source: html/67f79d01-2e87-3b9c-b7a9-5269673587e3.htm
---
# Autodesk.Revit.DB.FormatOptions.CanSuppressTrailingZeros Method

Checks whether trailing zeros can be suppressed for a given unit.

## Syntax (C#)
```csharp
public static bool CanSuppressTrailingZeros(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit.

## Returns
True if trailing zeros can be suppressed, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

