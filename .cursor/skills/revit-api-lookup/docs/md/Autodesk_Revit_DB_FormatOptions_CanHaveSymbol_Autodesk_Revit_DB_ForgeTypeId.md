---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.CanHaveSymbol(Autodesk.Revit.DB.ForgeTypeId)
source: html/6873325b-ab17-ab22-8c74-138582383ac7.htm
---
# Autodesk.Revit.DB.FormatOptions.CanHaveSymbol Method

Checks whether a symbol can be specified to display a given unit.

## Syntax (C#)
```csharp
public static bool CanHaveSymbol(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit.

## Returns
True if a symbol can be specified, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

