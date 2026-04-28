---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.GetValidSymbols(Autodesk.Revit.DB.ForgeTypeId)
source: html/cfd145b8-4f10-9e89-8115-3ae21f1a8203.htm
---
# Autodesk.Revit.DB.FormatOptions.GetValidSymbols Method

Gets the identifiers of all valid symbols for a given unit.

## Syntax (C#)
```csharp
public static IList<ForgeTypeId> GetValidSymbols(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit.

## Returns
Identifiers of the valid symbols.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

