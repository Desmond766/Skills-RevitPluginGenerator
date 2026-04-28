---
kind: method
id: M:Autodesk.Revit.DB.FormatOptions.#ctor(Autodesk.Revit.DB.ForgeTypeId)
source: html/697d7092-cb0b-d6c4-8aa5-18e4da759534.htm
---
# Autodesk.Revit.DB.FormatOptions.#ctor Method

Creates a new FormatOptions object that represents custom formatting.

## Syntax (C#)
```csharp
public FormatOptions(
	ForgeTypeId unitTypeId
)
```

## Parameters
- **unitTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Identifier of the unit to display.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - unitTypeId is not a unit identifier. See UnitUtils.IsUnit(ForgeTypeId) and UnitUtils.GetUnitTypeId(DisplayUnitType).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

