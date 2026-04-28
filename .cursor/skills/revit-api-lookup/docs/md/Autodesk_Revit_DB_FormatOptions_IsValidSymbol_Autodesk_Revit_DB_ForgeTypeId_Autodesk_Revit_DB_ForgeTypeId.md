---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.IsValidSymbol(Autodesk.Revit.DB.ForgeTypeId,Autodesk.Revit.DB.ForgeTypeId)
source: html/60d2e9b7-9f58-cab2-9a26-3ba2d57d1fd9.htm
---
# Autodesk.Revit.DB.FormatOptions.IsValidSymbol Method

Checks whether a symbol is valid for a given unit.

## Syntax (C#)
```csharp
public static bool IsValidSymbol(
	ForgeTypeId unitTypeId,
	ForgeTypeId symbolTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit.
- **symbolTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the symbol to check.

## Returns
True if the symbol is valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

