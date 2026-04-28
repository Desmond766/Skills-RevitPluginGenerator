---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.#ctor(Autodesk.Revit.DB.ForgeTypeId,Autodesk.Revit.DB.ForgeTypeId)
source: html/0806fd31-115e-7b7d-c2fb-721e4d304047.htm
---
# Autodesk.Revit.DB.FormatOptions.#ctor Method

Creates a new FormatOptions object that represents custom formatting.

## Syntax (C#)
```csharp
public FormatOptions(
	ForgeTypeId unitTypeId,
	ForgeTypeId symbolTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit to display.
- **symbolTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the symbol with which to render the unit.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
 -or-
 symbolTypeId is not a valid symbol for unitTypeId.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

